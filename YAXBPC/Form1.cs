/*
   Copyright 2012 - 2014 © Nguyen Hung Quy (dreamer2908)

   Licensed under the Apache License, Version 2.0 (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

       http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.
 * */

/*
TODO:
 * Improve getDirectoryName. See comment there
 * Make killAOption less dirty
 * Work on chbNewAutoName
 * Do something with btnBatchLoadDirs
 * Take care of addNewPatchToApplyAllScripts part in createApplyingScripts. It might not work with long paths
 * */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using Microsoft.Experimental.IO;

namespace YAXBPC
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();

            // Check OS
            useLongPath = needLongPathSupport();
            runningInWindows = isThisWindows();

            // Load settings
            programPath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            settingsFile = System.IO.Path.ChangeExtension(programPath, "ini");
            programDir = getDirectoryName(programPath);
            settings = new Database(settingsFile);
            if (settings.Load() == null) loadSettings();

            run64bitxdelta = chbRun64bitxdelta3.Checked;
            dist64bitxdelta = chbDist64bitxdelta3.Checked;
            funnyMode = chbFunnyMode.Checked;

            // debug mode
            debugMode = false;
            forceUnicodeMode = false;
            forceLongPath = false;

            // test getDirectoryName()
            if (false)
            {
                string result = "getDirectoryName() tests: \n\n";
                string[] test = new string[] { @"C:\Users\Yumi\Desktop\404.htm", @"C:\", @"C:\a.txt", @"C:", @"C:\bla", @"C:\bla\", @"/var/www", @"/var/www/", @"/var", @"/", "" };
                foreach (string tmp in test)
                {
                    result += "\"" + tmp + "\" => \"" + getDirectoryName(tmp) + "\"\n";
                }
                MessageBox.Show(result);
                MessageBox.Show("\"" + programDir + "\" vs. \"" + Path.GetDirectoryName(programPath) + "\"\n" + programDir.Equals(Path.GetDirectoryName(programPath)).ToString()); 
            }
        }

        #region Global variables & type defs

        // runtime environment & debug mode
        Boolean debugMode = false;
        Boolean forceUnicodeMode = false;
        Boolean forceLongPath = false;
        String settingsFile = "";
        String programPath = "";
        String programDir = "";
        Boolean runningInWindows = false;
        Boolean useLongPath;

        Database settings;
        String quote = '"'.ToString();
        Int32 outputPlace = 0;
        Int32 currentlySelectedTab = 0;
        Int32 currentlyBeingEditedJob = 0;
        Boolean tryDetectingEpisodeNumber = false;
        Boolean useCustomParamenter = false;
        String customParamenter = "";
        Boolean run64bitxdelta = false;
        Boolean dist64bitxdelta = false;
        Boolean funnyMode = false;
        Boolean batchProcessingMode = false;
        Boolean addNewPatchToApplyAllScripts = false;

        // shared variables for batch processing
        Int32 jobsCount = 0;
        Boolean thisJobDone = false;
        String sourceFile_currentJob = "";
        String targetFile_currentJob = "";
        String outputDir_currentJob = "";

        public delegate void Int32_Delegate(Int32 index);
        public delegate void String_Delegate(String log);
        public delegate void Void_Delegate();

        struct EpNum
        {
            public String text;// = "";
            public Int32 number;// = -1;
            public Int32 length;// = 0;
            public Int32 priority;// = 0; 
        }

        #endregion

        #region Delegate methods

        private void AddText2Log(string log)
        {
            if (this.rtbLog.InvokeRequired)
            {
                String_Delegate d = new String_Delegate(rtbLog.AppendText);
                this.Invoke
                    (d, new object[] { log });
            }
            else
            {
                rtbLog.AppendText(log);
            }
        }

        private void AddText2ApplyLog(string log)
        {
            if (this.rtbLog.InvokeRequired)
            {
                String_Delegate d = new String_Delegate(rtbApplyLog.AppendText);
                this.Invoke
                    (d, new object[] { log });
            }
            else
            {
                rtbApplyLog.AppendText(log);
            }
        }

        private bool copyTask(int index)
        {
            thisJobDone = false;
            if (this.listView1.InvokeRequired)
            {
                Int32_Delegate d = new Int32_Delegate(_CopyTask);
                this.Invoke
                    (d, new object[] { index });
            }
            else
            {
                _CopyTask(index);
            }
            return !thisJobDone;
        }

        private void _CopyTask(int index)
        {
            if (listView1.Items[index].ImageIndex != 0)
            {
                thisJobDone = false;
                sourceFile_currentJob = listView1.Items[index].SubItems[0].Text;
                targetFile_currentJob = listView1.Items[index].SubItems[1].Text;
                outputDir_currentJob = listView1.Items[index].SubItems[2].Text;
                listView1.Items[index].ImageIndex = 1;
            }
            else thisJobDone = true;
        }

        private void setTaskFinished(int index)
        {
            if (this.listView1.InvokeRequired)
            {
                Int32_Delegate d = new Int32_Delegate(_SetTaskFinished);
                this.Invoke
                    (d, new object[] { index });
            }
            else
            {
                _SetTaskFinished(index);
            }
        }

        private void _SetTaskFinished(int index)
        {
            listView1.Items[index].ImageIndex = 0;
        }

        private void getNumOfTask()
        {
            if (this.listView1.InvokeRequired)
            {
                Void_Delegate d = new Void_Delegate(_GetNumOfTask);
                this.Invoke
                    (d, new object[] { });
            }
            else
            {
                _GetNumOfTask();
            }
        }

        private void _GetNumOfTask()
        {
            jobsCount = listView1.Items.Count;
        }

        #endregion

        #region Core methods

        // Checks if the string contains non-ASCII characters. 
        // Simply strip non-ASCII characters from the string using Regex or Encoding.ASCII.GetString.
        // Or, convert the input string into ASCII; non-ASCII chars will become "?". 
        // EncoderReplacementFallback is marked as TODO in Mono, so just use regex for now.
        private Boolean containNonASCIIChar(string inputString)
        {
            if (forceUnicodeMode) return true;
            string asAscii = "";

            // Strip non-ASCII characters from the string using Regex
            asAscii = Regex.Replace(inputString, @"[^\u0000-\u007F]", string.Empty);

            /* // Alternative solutions
            // use Encoding.ASCII.GetString to change non-ASCII chars into ??
            asAscii = System.Text.Encoding.ASCII.GetString(System.Text.Encoding.ASCII.GetBytes(inputString)); 
            
            // Strip non-ASCII characters from the string using a pure .NET solution
            asAscii = Encoding.ASCII.GetString(
             Encoding.Convert(
                 Encoding.UTF8,
                 Encoding.GetEncoding(
                     Encoding.ASCII.EncodingName,
                     new EncoderReplacementFallback(string.Empty),
                     new DecoderExceptionFallback()
                     ),
                 Encoding.UTF8.GetBytes(inputString)
             )); 
            */

            //MessageBox.Show("\"" + inputString + "\" => \"" + asAscii + "\"");
            if (inputString != asAscii) return true;
            else return false;
        }

        private Boolean isThisWindows()
        {
            System.OperatingSystem osInfo = System.Environment.OSVersion;
            switch (osInfo.Platform)
            {
                case System.PlatformID.Win32Windows:
                    {
                        // Windows 95, Windows 98, Windows 98 Second Edition, or Windows Me.
                        return true;
                    }
                case System.PlatformID.Win32NT:
                    {
                        // Windows NT 3.51, Windows NT 4.0, Windows 2000, Windows XP, Windows Vista, Windows 7, Windows 8, or later
                        return true;
                    }
                default: return false;
            }
        }

        /// <summary>
        /// Checks if we need the experimental long settingsFilePath support. Only Windows versions ealier than 6.2 need it.
        /// </summary>
        private Boolean needLongPathSupport()
        {
            // Only Windows versions ealier than 6.2 (Windows 8) need it.
            System.OperatingSystem osInfo = System.Environment.OSVersion;
            switch (osInfo.Platform)
            {
                case System.PlatformID.Win32Windows:
                    {
                        // Windows 95, Windows 98, Windows 98 Second Edition, or Windows Me.
                        return true;
                    }
                case System.PlatformID.Win32NT:
                    {
                        // Windows NT 3.51, Windows NT 4.0, Windows 2000, Windows XP, Windows Vista, Windows 7, or Windows 8
                        // Windows 8 (NT version 6.2) or later supports long settingsFilePath
                        if (osInfo.Version.Major >= 7 || (osInfo.Version.Major == 6 && osInfo.Version.Minor >= 2)) return false;
                        else return true;
                    }
                default: return false;
            }
        }

        /// <summary>
        /// Checks if the settingsFilePath specified in fullPath is long (more than 255 chars for file, or 247 for directory) 
        /// and/or needs special treatment (if any parent directory's name is longer than 247 chars - specified in those methods for long paths).
        ///  Positive results are valid for Windows earlier than 6.2 only while negative results are always valid, or at least I think so.
        /// </summary>
        private Boolean isLongPath(string fullPath, Boolean isDir)
        {
            if (forceLongPath) return true;
            Boolean pathIsLong = false;
            if ((fullPath.Length > 255) || getDirectoryName(fullPath).Length > 247 || (fullPath.Length > 247 && isDir)) pathIsLong = true;
            else
            {
                string[] path = fullPath.Split(new[] { Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar });
                foreach (string tmp in path) if (tmp.Length > 247) pathIsLong = true;
                for (int i = 0; i < path.Length; i++)
                {
                    if ((path[i].Length > 247) && ((i == path.Length - 1) || isDir || path[i].Length > 255)) pathIsLong = true;
                }
            }
            return pathIsLong;
        }

        /// <summary>
        /// Trims the names of each folder in fullPath to meet Windows' limit. This method is currently NOT in use.
        /// See https://en.wikipedia.org/wiki/Filename 
        /// http://stackoverflow.com/questions/265769/maximum-filename-length-in-ntfs-windows-xp-and-windows-vista 
        /// or http://msdn.microsoft.com/en-us/library/aa365247.aspx
        /// </summary>
        private string trimPath(string fullPath)
        {
            string[] path = fullPath.Split(new[] { Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar });
            string currentPath = "";
            for (int i = 0; i < path.Length; i++)
            {
                string currentName = path[i];
                if (currentName.Length > 247) currentName = currentName.Substring(0, 247);
                currentPath = Path.Combine(currentPath, currentName);
            }
            return currentPath;
        }

        // A simple alternative to System.IO.Path.GetDirectoryName with slightly different behaviour. 
        // This won't throw any exception, including PathTooLongException, 
        // which System.IO.Path.GetDirectoryName throws (I do deal with long path so it's not acceptable). 
        // Just remove the last name in the path and it's good to go, right? 
        // It doesn't support Linux path when running on Windows: getDirectoryName(@"/root/a/b") returns "/root\a". 
        // It also doesn't support Windows path when running on Linux lol. 
        // TL;DR: cross checking not supported. 
        // Expected behaviour: 
        // getDirectoryName("C:\mydir\myfile.ext") returns "C:\mydir"
        // getDirectoryName("C:\mydir\") returns "C:\mydir"
        // getDirectoryName("C:\") returns "C:" while System.IO.Path.GetDirectoryName("C:\") returns ""
        private string getDirectoryName(string fullFilename)
        {
            string[] path = fullFilename.Split(new[] { Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar },  StringSplitOptions.None);
            string currentPath = "";
            if (path.Length > 0)
            {
                if (runningInWindows && path[0].EndsWith(":") && path.Length > 2) currentPath = path[0] + "\\";
                else currentPath = path[0];
                for (int i = 1; i < path.Length - 1; i++)
                {
                    currentPath = Path.Combine(currentPath, path[i]);
                    //MessageBox.Show(currentPath);
                }
            }
            if (fullFilename.StartsWith("/") && !currentPath.StartsWith("/")) currentPath = "/" + currentPath; // use this dirty hack until a proper solution is make, that is, soon™
            return currentPath;
        }

        private void generateOutputDirName(string sourceFile, string targetFile, int outputPlace, string customOutputDir)
        {
            string outputDir = generateOutputDirNameSub(sourceFile, targetFile, outputPlace, customOutputDir);
            txtOutputDir.Text = outputDir;
        }

        private string generateOutputDirNameSub(string sourceFile, string targetFile, int outputPlace, string customOutputDir)
        {
            string episodeNumber = "";
            string outputDir = "";
            string baseOutputDir = "";
            string name2Detect = "";

            // Generate parent dir
            switch (outputPlace)
            {
                case 0:
                    if (File.Exists(sourceFile))
                    {
                        baseOutputDir = Path.GetDirectoryName(sourceFile);
                        name2Detect = Path.GetFileName(sourceFile);
                    }
                    break;
                case 1:
                    if (File.Exists(targetFile))
                    {
                        baseOutputDir = Path.GetDirectoryName(targetFile);
                        name2Detect = Path.GetFileName(targetFile);
                    }
                    break;
                case 2:
                    baseOutputDir = customOutputDir;
                    if (File.Exists(sourceFile)) name2Detect = Path.GetFileName(sourceFile);
                    break;
            }

            // Generate the name
            if (!chbNewAutoName.Checked)
            {
                if (chbDetEpNum.Checked)
                {
                    episodeNumber = getEpisodeNumber(name2Detect);
                    outputDir = System.IO.Path.Combine(baseOutputDir, ((episodeNumber.Length > 0) ? episodeNumber : "patch"));
                }
                else
                {
                    outputDir = System.IO.Path.Combine(baseOutputDir, "patch");
                }
            }
            else if (sourceFile.Length > 0 && targetFile.Length > 0)
            {
                // Already disabled, but just for safe
                if (chbDetEpNum.Checked)
                {
                    episodeNumber = getEpisodeNumber(name2Detect);
                    outputDir = System.IO.Path.Combine(baseOutputDir, ((episodeNumber.Length > 0) ? episodeNumber : "patch"));
                }
                else
                {
                    outputDir = System.IO.Path.Combine(baseOutputDir, "patch");
                }
            }
            return outputDir;
        }

        // I don't remember how I did this, but apparently it works well enough
        private string getEpisodeNumber(string sourceFile)
        {
            string episodeNumber = "";
            int[] pos = new int[sourceFile.Length];
            string SP = "_-[] v.";
            string[] SPC = { "_", "-", " ", "[", "]" };
            int length = sourceFile.Length;

            EpNum[] text2Parse = new EpNum[length];
            int found = 0;
            int count = 0;
            for (int cur = 0; cur < length; cur++)
            {
                if (SP.Contains(sourceFile.Substring(cur, 1)))
                {
                    string strFound = sourceFile.Substring(found, cur - found + 1);
                    int _length = strFound.Length;
                    int _prio = 0;
                    int _number = 0;
                    if (length < 1 || SP.Contains(strFound)) continue;
                    bool valid = int.TryParse(strFound.Substring(1, _length - 2), out _number);

                    if (valid)
                    {
                        // Set its priority accoding to the patern
                        if (strFound.Substring(_length - 1, 1) == "v") _prio += 1; // 02v (2) will get higher priority
                        else
                        {
                            if (strFound.Substring(_length - 1, 1) == strFound.Substring(0, 1)) // _02_ too
                            {
                                if (strFound.Substring(0, 1) == "v") _prio -= 1; // but not v02v 
                                else _prio += 1;
                            }
                        }
                        //else _prio -= 1; // No reason to reduce its priotity

                        if (found > 0) { if (_length == 4) _prio += 1; } else { if (_length == 3) _prio += 1; } // An episode number usually contains 2 characters

                        text2Parse[count] = new EpNum();
                        text2Parse[count].text = strFound;
                        text2Parse[count].length = _length - 2;

                        if (found == 0) text2Parse[count].length = _length - 1;

                        text2Parse[count].priority = _prio;
                        text2Parse[count].number = _number;

                        count++;
                    }
                    found = cur;
                }
            }

            if (count > 0)
            {
                if (count > 1)
                {
                    // Use priority to choose the best number
                    int right = 0;
                    int max = -10;
                    for (int i = 0; i < count; i++)
                    {
                        if (text2Parse[i].priority > max)
                        {
                            right = i;
                            max = text2Parse[i].priority;
                        }
                    }
                    text2Parse[0] = text2Parse[right]; //Copy to the beginning
                }
                episodeNumber = text2Parse[0].number.ToString(); // Take the first one
                while (episodeNumber.Length < text2Parse[0].length) episodeNumber = "0" + episodeNumber; // Add "0" to get "01", and "02" instead of "1", and "2"
            }
            return episodeNumber;
        }

        // Temporary solution. It looks dirty to me, really >_>
        private string killAOption(string options)
        {
            string result = options;
            if (options.Contains("-A="))
            {
                int i = options.IndexOf("-A=");
                result = options.Substring(0, i);
                string tmp = options.Substring(i + 3);
                if (tmp.Length > 0)
                {
                    if (tmp[0] == '"')
                    {
                        // kill string in quotes
                        if (tmp.Length > 1)
                        {
                            int quote = tmp.IndexOf('"', 1);
                            if (quote >= 1 && quote + 1 < tmp.Length) result += " " + tmp.Substring(quote + 1);
                        }
                    }
                    else
                    {
                        // kill string before the first white space. If no space found, kill all
                        tmp = tmp.TrimEnd();
                        int space = tmp.IndexOf(' ');
                        if (space >= 0 && space + 1 < tmp.Length)
                        {
                            result += " " + tmp.Substring(space + 1);
                        }
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// Creates dir with long settingsFilePath. It's expected to run this on Windows without long settingsFilePath support. 
        /// </summary>
        private string createDirLong(string dir)
        {
            string[] path = dir.Split(new[] { Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar });
            string currentPath = "";
            for (int i = 0; i < path.Length; i++)
            {
                string currentName = path[i];
                if (currentName.Length > 247)
                {
                    Exception e = new Exception("The directory name must be less than 248 characters.");
                    throw e;
                }
                currentPath = Path.Combine(currentPath, currentName);
                if (!LongPathDirectory.Exists(currentPath)) LongPathDirectory.Create(currentPath);
            }
            return currentPath; // Return created directory. For future usage
        }

        private void createOutputDir(string dir)
        {
            Boolean pathIsLong = isLongPath(dir, true);

            if (useLongPath && pathIsLong)
            {
                if (!LongPathDirectory.Exists(dir)) createDirLong(dir);
            }
            else
            {
                if (!System.IO.Directory.Exists(dir)) System.IO.Directory.CreateDirectory(dir);
            }
        }

        private void createPatch(string _sourceFile, string _targetFile, string _outDir)
        {
            Boolean useRelativePath = false;
            useRelativePath = chbOnlyStoreFileNameInVCDIFF.Checked || containNonASCIIChar(Path.GetFileName(_sourceFile)) || containNonASCIIChar(Path.GetFileName(_targetFile));
            string sourceFile = _sourceFile;
            string targetFile = _targetFile;
            string outputDir = _outDir;
            string target = System.IO.Path.Combine(outputDir, "changes.vcdiff");

            Process xdelta = new Process();
            xdelta.StartInfo.CreateNoWindow = true;
            if (runningInWindows && run64bitxdelta) xdelta.StartInfo.FileName = "xdelta3.x86_64.exe";
            else xdelta.StartInfo.FileName = "xdelta3"; // Works with xdelta3.exe and xdelta3 package, doesn't work with ./xdelta3
            xdelta.StartInfo.UseShellExecute = false;
            xdelta.StartInfo.RedirectStandardOutput = false;
            xdelta.StartInfo.RedirectStandardError = false;

            if (!useCustomParamenter)
            {
                xdelta.StartInfo.Arguments = "-D -R -f -e -s %source% %patched% %vcdiff%";
            }
            else
            {
                xdelta.StartInfo.Arguments = customParamenter;
            }
            
            if (true) xdelta.StartInfo.Arguments = "-D -R " + xdelta.StartInfo.Arguments; // to avoid decompression and recompression on certain format like gz. Can be overriden

            // Use StandardOutput if the path is long
            if (useLongPath && isLongPath(target, false))
            {
                xdelta.StartInfo.Arguments = "-c " + xdelta.StartInfo.Arguments;
                xdelta.StartInfo.RedirectStandardOutput = true;
            }

            // Needs to kill -A option first 'cause xdelta3 always takes the last one
            xdelta.StartInfo.Arguments = killAOption(xdelta.StartInfo.Arguments);
            if (useRelativePath) xdelta.StartInfo.Arguments = "-A=\"" + Path.GetFileName(targetFile) + "//" + Path.GetFileName(sourceFile) + "/\" " + xdelta.StartInfo.Arguments;
            else if (funnyMode)
                xdelta.StartInfo.Arguments = "-A=\"" + "Don't be lazy like this, d1st" + "//" + "Type the full command instead" + "/\" " + xdelta.StartInfo.Arguments;

            xdelta.StartInfo.Arguments = xdelta.StartInfo.Arguments.Replace("%source%", quote + sourceFile + quote).Replace("%patched%", quote + targetFile + quote).Replace("%vcdiff%", quote + target + quote);

            if (debugMode) MessageBox.Show(xdelta.StartInfo.Arguments);
            xdelta.Start();

            // Start BinaryWriter if the path is long
            if (useLongPath && isLongPath(target, false))
            {
                if (debugMode) MessageBox.Show("createOutputFolder: Using StandardOutput & BinaryWriter.");
                FileStream stream = LongPathFile.Open(target, FileMode.Create, FileAccess.Write);
                BinaryWriter binaryWriter = new BinaryWriter(stream);
                BinaryReader binaryReader = new BinaryReader(xdelta.StandardOutput.BaseStream);
                try {
                    while (true) binaryWriter.Write(binaryReader.ReadByte()); // Read and write byte by byte. Not efficient but it works and I'm too lazy to invest more
                }
                catch (Exception) {  /* Do nothing. An exception will occur when the stream ends. Don't use EndOfStream 'cause it will break the binary reader. */ }
                binaryWriter.Flush();
                binaryWriter.Close();
            }
            xdelta.WaitForExit();
        }

        /// <summary>
        /// Copies the file specified in sourcePath to destinationPath. Existing file, if any, will be overwritten without prompt.
        /// </summary>
        private void copyFile(string sourcePath, string destinationPath)
        {
            FileStream fsSource, fsTarget;
            if (useLongPath && (isLongPath(sourcePath, false) || isLongPath(destinationPath, false))) // save me one line lol
            {
                fsSource = LongPathFile.Open(sourcePath, FileMode.Open, FileAccess.Read);
                fsTarget = LongPathFile.Open(destinationPath, FileMode.Create, FileAccess.Write);
            }
            else
            {
                fsSource = System.IO.File.Open(sourcePath, FileMode.Open, FileAccess.Read);
                fsTarget = System.IO.File.Open(destinationPath, FileMode.Create, FileAccess.Write);
            }

            BinaryReader brSource = new BinaryReader(fsSource);
            BinaryWriter bwTarget = new BinaryWriter(fsTarget); 

            try
            {
                while (true) bwTarget.Write(brSource.ReadByte());
            }
            catch (Exception) { /* Do nothing */ }
            finally
            {
                brSource.Close();
                bwTarget.Flush();
                bwTarget.Close();
            }
        }

        private void copyXdeltaBinaries(string outputFolder)
        {
            string source = System.IO.Path.Combine(programDir, (dist64bitxdelta) ? "xdelta3.x86_64.exe" : "xdelta3.exe");
            string source2 = System.IO.Path.Combine(programDir, "xdelta3");
            string source3 = System.IO.Path.Combine(programDir, "xdelta3.x86_64");
            string source4 = System.IO.Path.Combine(programDir, "xdelta3_mac");
            string target = System.IO.Path.Combine(outputFolder, "xdelta3.exe");
            string target2 = System.IO.Path.Combine(outputFolder, "xdelta3");
            string target3 = System.IO.Path.Combine(outputFolder, "xdelta3.x86_64");
            string target4 = System.IO.Path.Combine(outputFolder, "xdelta3_mac");

            if (debugMode)
            {
                MessageBox.Show("Source = \"" + source + "\" (" + LongPathFile.Exists(source).ToString() 
                    + ")\nTarget = \"" + target + "\" (" + LongPathFile.Exists(target).ToString() + ")\n" 
                    + "Source2 = \"" + source2 + "\" (" + LongPathFile.Exists(source2).ToString() 
                    + ")\nTarget2 = \"" + target2 + "\" (" + LongPathFile.Exists(target2).ToString() + ")");
            }

            if (useLongPath && (isLongPath(target2, false) || isLongPath(target, false)))
            {
                if (debugMode) MessageBox.Show("copyXdeltaBinaries: long.");
                copyFile(source, target);
                copyFile(source2, target2);
                copyFile(source3, target3);
                // In case xdelta3_mac is provided
                if (LongPathFile.Exists(source4)) copyFile(source4, target4);
            }
            else
            {
                System.IO.File.Copy(source, target, true);
                System.IO.File.Copy(source2, target2, true);
                System.IO.File.Copy(source3, target3, true);
                if (LongPathFile.Exists(source4)) System.IO.File.Copy(source4, target4, true);
            }
        }

        // # %^& must be escaped. \/<>"*:?| are forbidden in win32 filenames. []()!=,;`' work, so not needed
        private string escapeStringForBatch(string text)
        {
            string result = "";
            for (int i = 0; i < text.Length; i++)
            {
                char chr = text[i];
                switch (chr)
                {
                    case '%': result += "%%"; break;
                    case '&': result += "^&"; break;
                    case '^': result += "^^"; break;
                    default: result += chr; break;
                }
            }

            return result;
        }

        private void writeTextToFile(string text, string path)
        {
            if (useLongPath && (isLongPath(path, false)))
            {
                using (FileStream stream = LongPathFile.Open(path, FileMode.Create, FileAccess.Write))
                {
                    using (StreamWriter writer = new StreamWriter(stream))
                    {
                        writer.Write(text);
                        writer.Flush();
                        writer.Close();
                    }
                }
            }
            else
            {
                System.IO.File.WriteAllText(path, text);
            }
        }

        private void appendTextToFile(string text, string path)
        {
            if (useLongPath && (isLongPath(path, false)))
            {
                using (FileStream stream = LongPathFile.Open(path, FileMode.Append, FileAccess.Write))
                {
                    using (StreamWriter writer = new StreamWriter(stream))
                    {
                        writer.Write(text);
                        writer.Flush();
                        writer.Close();
                    }
                }
            }
            else
            {
                System.IO.File.AppendAllText(path, text);
            }
        }

        private void createApplyingScripts(string sourceFile, string targetFile, string outputDir)
        {
            // directly copy these alternative scripts to output dir
            string[] alternativeScripts = { "apply_patch_windows_alternative.bat", "apply_patch_mac_alternative.command", "apply_patch_linux_alternative.sh" };
            foreach (string s in alternativeScripts)
            {
                copyFile(System.IO.Path.Combine(programDir, s), System.IO.Path.Combine(outputDir, s));
            }

            // Linux & Mac scripts work with non-ascii filenames
            string linuxScript = System.IO.File.ReadAllText(System.IO.Path.Combine(programDir, "apply_patch_linux.sh"));
            string macScript = System.IO.File.ReadAllText(System.IO.Path.Combine(programDir, "apply_patch_mac.command"));
            string readMe = System.IO.File.ReadAllText(System.IO.Path.Combine(programDir, "how_to_apply_this_patch.txt"));

            readMe = readMe.Replace("&sourcefile&", sourceFile).Replace("&targetfile&", targetFile);
            linuxScript = linuxScript.Replace("&sourcefile&", sourceFile.Replace("'", "'\"'\"'")).Replace("&targetfile&", targetFile.Replace("'", "'\"'\"'"));
            macScript = macScript.Replace("&sourcefile&", sourceFile.Replace("'", "'\"'\"'")).Replace("&targetfile&", targetFile.Replace("'", "'\"'\"'"));

            // Unified both scripts. Now only apply_patch_windows.bat
            string winScript = System.IO.File.ReadAllText(System.IO.Path.Combine(programDir, "apply_patch_windows.bat"));

            winScript = winScript.Replace("&sourcefile&", escapeStringForBatch(sourceFile)).Replace("&targetfile&", escapeStringForBatch(targetFile));
            if (containNonASCIIChar(Path.GetFileName(sourceFile)))
            {
                winScript = winScript.Replace("set movesourcefile=0", "set movesourcefile=1");
            }
            if (containNonASCIIChar(Path.GetFileName(sourceFile)))
            {
                winScript = winScript.Replace("set movetargetfile=0", "set movetargetfile=1");
            }
            if (!(containNonASCIIChar(Path.GetFileName(sourceFile) + Path.GetFileName(sourceFile))))
            {
                winScript = winScript.Replace("chcp 65001", "");
            }

            // Generate output file paths
            string macPath = System.IO.Path.Combine(outputDir, "apply_patch_mac.command");
            string winPath = System.IO.Path.Combine(outputDir, "apply_patch_windows.bat");
            string linuxPath = System.IO.Path.Combine(outputDir, "apply_patch_linux.sh");
            string readMePath = System.IO.Path.Combine(outputDir, "how_to_apply_this_patch.txt");

            // write outputs
            writeTextToFile(winScript, winPath);
            writeTextToFile(linuxScript, linuxPath);
            writeTextToFile(macScript, macPath);
            writeTextToFile(readMe, readMePath);

            // "Apply all" scripts
            if (addNewPatchToApplyAllScripts)
            {
                string parentDirPath = System.IO.Directory.GetParent(outputDir).FullName;
                string outputDirName = new DirectoryInfo(outputDir).Name;
                
                string applyAllWinPath = System.IO.Path.Combine(parentDirPath, "apply_all_patches_windows.bat");
                string applyAllLinuxPath = System.IO.Path.Combine(parentDirPath, "apply_all_patches_linux.sh");
                string applyAllMacPath = System.IO.Path.Combine(parentDirPath, "apply_all_patches_mac.command");

                if (!System.IO.File.Exists(applyAllLinuxPath))
                {
                    writeTextToFile("#!/bin/bash\ncd \"$( cd \"$( dirname \"${BASH_SOURCE[0]}\" )\" && pwd )\"", applyAllLinuxPath);
                }
                if (!System.IO.File.Exists(applyAllMacPath))
                {
                    writeTextToFile("#!/bin/bash\ncd \"$( cd \"$( dirname \"${BASH_SOURCE[0]}\" )\" && pwd )\"", applyAllMacPath);
                }
                if (!System.IO.File.Exists(applyAllWinPath))
                {
                    writeTextToFile("chdir /d %~dp0", applyAllWinPath);
                }
                appendTextToFile("\r\ncall \".\\" + outputDirName + "\\apply_patch_windows.bat\"", applyAllWinPath); // use "call blablah.bat"
                appendTextToFile("\nbash './" + outputDirName + "/apply_patch_linux.sh'", applyAllLinuxPath);
                appendTextToFile("\nbash './" + outputDirName + "/apply_patch_mac.command'", applyAllMacPath);
            }
        } 
 
        private void createOnePatch(string sourceFile, string targetFile, string outputDir)
        {
            Boolean ShowError = false;

            try
            {
                AddText2Log("Creating output directory...\n");
                createOutputDir(outputDir);
            }
            catch (Exception e)
            {
                AddText2Log("Task failed: " + e.Message + "\n");
                if (ShowError) MessageBox.Show(e.Message);
                //return;
            }
            
            try
            {
                AddText2Log("Creating patch...\n");
                createPatch(sourceFile, targetFile, outputDir);
            }
            catch (Exception e)
            {
                AddText2Log("Task failed: " + e.Message + "\n");
                if (ShowError) MessageBox.Show(e.Message);
                //return;
            }

            createApplyingScripts(Path.GetFileName(sourceFile), Path.GetFileName(targetFile), outputDir);
            try
            {
                AddText2Log("Creating applying scripts...\n");
            }
            catch (Exception e)
            {
                AddText2Log("Task failed: " + e.Message + "\n");
                if (ShowError) MessageBox.Show(e.Message);
                //return;
            }
            
            try
            {
                AddText2Log("Copying xdelta3 to output directory...\n");
                copyXdeltaBinaries(outputDir);
            }
            catch (Exception e)
            {
                AddText2Log("Task failed: " + e.Message + "\n");
                if (ShowError) MessageBox.Show(e.Message);
                //return;
            }
            
            AddText2Log("Done.\n\n");
        }

        private void createPatchBackground(object sender, DoWorkEventArgs e)
        {
            if (!batchProcessingMode)
            {
                // Single job
                if (txtSourceFile.Text.Trim().Equals(String.Empty)) AddText2Log("Please specify the source file.\n\n");
                else if (txtTargetFile.Text.Trim().Equals(String.Empty)) AddText2Log("Please specify the target file.\n\n");
                else if (txtOutputDir.Text.Trim().Equals(String.Empty)) AddText2Log("Please specify the output directory.\n\n"); 
                else createOnePatch(txtSourceFile.Text, txtTargetFile.Text, txtOutputDir.Text);
            }
            else
            {
                // Batch processing
                if (currentlySelectedTab == 1)
                {
                    getNumOfTask();
                    int old = jobsCount;
                    if (jobsCount > 0)
                        for (int n = 0; n < jobsCount; n++)
                        {
                            if (copyTask(n))
                            {
                                createOnePatch(sourceFile_currentJob, targetFile_currentJob, outputDir_currentJob);
                                setTaskFinished(n);
                            }
                            getNumOfTask(); // Re-get the number of task(s) in case task(s) added/removed
                            if (old != jobsCount) n = 0; // Re-start the queue. Currently, i's safe to assume this, because changing task order is not supported.
                        }
                }
            }
        }

        private void applyPatchBackground(object sender, DoWorkEventArgs e)
        {
            if (txtApplySource.Text.Trim().Equals(String.Empty))
            {
                AddText2ApplyLog("Please specify the source file.\n\n");
                return;
            }
            else if (txtApplyVcdiffFile.Text.Trim().Equals(String.Empty))
            {
                AddText2ApplyLog("Please specify the vcdiff file.\n\n");
                return;
            }
            else if (txtApplyOutput.Text.Trim().Equals(String.Empty))
            {
                AddText2ApplyLog("Please specify the output file.\n\n");
                return;
            }

            string inputFile = txtApplySource.Text;
            try
            {
                AddText2ApplyLog("Attempting to patch \"" + Path.GetFileName(inputFile) + "\"...\n");
                applyOnePatch(txtApplySource.Text, txtApplyVcdiffFile.Text, txtApplyOutput.Text);
            }
            catch (Exception ex)
            {
                AddText2ApplyLog("Task failed: " + ex.Message + "\n");
                return;
            }
            AddText2ApplyLog("Done. \n\n");
        }

        private void applyOnePatch(string sourceFile, string vcdiffFile, string outputFile)
        {
            Process xdelta = new Process();
            xdelta.StartInfo.CreateNoWindow = true;
            if (runningInWindows && run64bitxdelta) xdelta.StartInfo.FileName = "xdelta3.x86_64.exe"; 
            else xdelta.StartInfo.FileName = "xdelta3"; // Works with xdelta3.exe and xdelta3 package, doesn't work with ./xdelta3
            xdelta.StartInfo.UseShellExecute = false;
            xdelta.StartInfo.RedirectStandardOutput = xdelta.StartInfo.RedirectStandardError = false;

            string paramenters = (chbUseCustomXdeltaParamsForApplying.Checked) ? txtCustomXdeltaParamsForApplying.Text : "-d -f -s %source% %vcdiff% %output%";
            xdelta.StartInfo.Arguments = paramenters.Replace("%source%", quote + sourceFile + quote).Replace("%vcdiff%", quote + vcdiffFile + quote).Replace("%output%", quote + outputFile + quote);

            xdelta.Start();
            xdelta.WaitForExit();
        }

        #endregion

        #region Buttons and events
        
        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            saveSettings();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentlySelectedTab = tabControl1.SelectedIndex;
            switch (currentlySelectedTab)
            {
                case 0: btnStart.Text = "&Create Patch"; break;
                case 1: btnStart.Text = "&Start Processing"; break;
                case 2: btnStart.Text = "&Apply Patch"; break;
                default: btnStart.Text = "&Create Patch"; break;
            }
            batchProcessingMode = (currentlySelectedTab == 1);
        }

        #region File Patcher tab

        private void btnBrowseSourceFile_Click(object sender, EventArgs e)
        {
            if (ofdFileBrowser.ShowDialog() == DialogResult.OK)
            {
                txtSourceFile.Text = ofdFileBrowser.FileName;
                generateOutputDirName(txtSourceFile.Text, txtTargetFile.Text, outputPlace, txtDefaultOutDir.Text); // Generate a new output folder
            }
        }

        private void btnBrowseTargetFile_Click(object sender, EventArgs e)
        {
            if (ofdFileBrowser.ShowDialog() == DialogResult.OK) txtTargetFile.Text = ofdFileBrowser.FileName;

            if (chbNewAutoName.Checked || rdbTargetDir.Checked)
            {
                generateOutputDirName(txtSourceFile.Text, txtTargetFile.Text, outputPlace, txtDefaultOutDir.Text);  // Generate a new output folder again
            }
        }

        private void btnBrowseOutputDir_Click(object sender, EventArgs e)
        {
            if (fbdDirBrowser.ShowDialog() == DialogResult.OK) txtOutputDir.Text = fbdDirBrowser.SelectedPath;
        }

        private void txtSourceFile_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) // File only, you faggots!
                e.Effect = DragDropEffects.All;
            else
                e.Effect = DragDropEffects.None;
        }

        private void txtSourceFile_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            txtSourceFile.Text = files[0];
            generateOutputDirName(txtSourceFile.Text, txtTargetFile.Text, outputPlace, txtDefaultOutDir.Text); // generate a new output folder whenever dropping
        }

        private void txtTargetFile_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            txtTargetFile.Text = files[0]; 
            if (chbNewAutoName.Checked || rdbTargetDir.Checked)
            {
                generateOutputDirName(txtSourceFile.Text, txtTargetFile.Text, outputPlace, txtDefaultOutDir.Text); // Generate a new output folder and again, whenever a file is dropped
            }
        }

        private void txtTargetFile_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) // File only, you faggots!
                e.Effect = DragDropEffects.All;
            else
                e.Effect = DragDropEffects.None;
        }

        private void txtOutputDir_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                if (System.IO.Directory.Exists(files[0])) e.Effect = DragDropEffects.All; // Check if the first one is an existing folder
            }
            else
                e.Effect = DragDropEffects.None;
        }

        private void txtOutputDir_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            txtOutputDir.Text = files[0]; // Take the first one
        }
        
        private void btnSwapSnT_Click(object sender, EventArgs e)
        {
            string temp = txtSourceFile.Text;
            txtSourceFile.Text = txtTargetFile.Text;
            txtTargetFile.Text = temp;
            
            if (chbAddTextWhenSwap.Checked && txtOutputDir.Text.Length > 0 && !txtOutputDir.Text.EndsWith(txtAddTextWhenSwap.Text)) txtOutputDir.Text += txtAddTextWhenSwap.Text; // check if already added
            if (chbNewAutoName.Checked)
            {
                generateOutputDirName(txtSourceFile.Text, txtTargetFile.Text, outputPlace, txtDefaultOutDir.Text); // Again!
            }
        }

        private void btnResetForms_Click(object sender, EventArgs e)
        {
            if (btnResetForms.Text == "&Reset Forms")
            {
                txtSourceFile.Text = txtOutputDir.Text = txtTargetFile.Text = "";
            }
            else
            {
                // Restore buttons
                btnResetForms.Text = "&Reset Forms";
                btnAddEditJob.Text = "&Add to batch";
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            switch (currentlySelectedTab)
            {
                case 0: if (!bgwCreatePatch.IsBusy) bgwCreatePatch.RunWorkerAsync(); break;
                case 1: if (!bgwCreatePatch.IsBusy) bgwCreatePatch.RunWorkerAsync(); break;
                case 2: if (!bgwApplyPatch.IsBusy) bgwApplyPatch.RunWorkerAsync(); break;
                default: if (!bgwCreatePatch.IsBusy) bgwCreatePatch.RunWorkerAsync(); break;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();       
        }

        private void btnAddEditJob_Click(object sender, EventArgs e)
        {
            if (btnAddEditJob.Text == "&Add to batch") // Check if this is an edit or a new
            {
                // Add a new job
                if (txtTargetFile.Text.Length > 0 && txtOutputDir.Text.Length > 0 && txtSourceFile.Text.Length > 0) // Validate all fields
                {
                    ListViewItem temp = listView1.Items.Add(txtSourceFile.Text); // Add to listview
                    temp.SubItems.Add(txtTargetFile.Text);
                    temp.SubItems.Add(txtOutputDir.Text);
                    temp.ImageIndex = 2;
                }
            }
            else
            {
                // Save changes to listview 
                ListViewItem temp = listView1.Items[currentlyBeingEditedJob];
                temp.SubItems[0].Text = txtSourceFile.Text;
                temp.SubItems[1].Text = txtTargetFile.Text;
                temp.SubItems[2].Text = txtOutputDir.Text;
                btnAddEditJob.Text = "&Add to batch";
                btnResetForms.Text = "&Reset Forms";
            }
        }

        private void txtBatchSourceDir_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                if (System.IO.Directory.Exists(files[0])) e.Effect = DragDropEffects.All; // Check if the first one is an existing folder
            }
            else
                e.Effect = DragDropEffects.None;
        }

        private void txtBatchSourceDir_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            txtBatchSourceDir.Text = files[0]; // Take the first one
        }

        private void txtBatchTargetDir_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                if (System.IO.Directory.Exists(files[0])) e.Effect = DragDropEffects.All; // Check if the first one is an existing folder
            }
            else
                e.Effect = DragDropEffects.None;
        }

        private void txtBatchTargetDir_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            txtBatchTargetDir.Text = files[0]; // Take the first one
        }

        #endregion

        #region Batch Worker tab

        private void btnRemove_Click(object sender, EventArgs e)
        {
            RemoveTask();
        }

        private void RemoveTask()
        {
            foreach (ListViewItem temp in listView1.SelectedItems)
            {
                temp.Remove();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.listView1.Items.Clear(); // Goodbye~       
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            EditTask();
        }

        private void EditTask()
        {
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem temp = listView1.SelectedItems[0]; // Get the first pair
                currentlyBeingEditedJob = listView1.SelectedItems[0].Index;
                txtSourceFile.Text = temp.SubItems[0].Text;
                txtTargetFile.Text = temp.SubItems[1].Text;
                txtOutputDir.Text = temp.SubItems[2].Text;
                btnAddEditJob.Text = "&Save";
                btnResetForms.Text = "&Cancel";

                // Switch to File Patch tab
                tabControl1.SelectedTab = tabControl1.TabPages[0];
                txtSourceFile.Focus();
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditTask();
        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RemoveTask();
        }

        private void resetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem temp in this.listView1.SelectedItems)
            {
                temp.ImageIndex = 2;
            }
        }

        private void btnBrowseBatchSourceDir_Click(object sender, EventArgs e)
        {
            if (fbdDirBrowser.ShowDialog() == DialogResult.OK) txtBatchSourceDir.Text = fbdDirBrowser.SelectedPath;
        }

        private void btnBrowseBatchTargetDir_Click(object sender, EventArgs e)
        {
            if (fbdDirBrowser.ShowDialog() == DialogResult.OK) txtBatchTargetDir.Text = fbdDirBrowser.SelectedPath;
        }

        private void btnBatchLoadDirs_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This function hasn't been implemented!");
        }

        #endregion

        #region Settings tab

        private void chbUseCusXdelPara_CheckedChanged(object sender, EventArgs e)
        {
            useCustomParamenter = chbUseCustomXdeltaParams.Checked;
        }

        private void txtCusXdelta_TextChanged(object sender, EventArgs e)
        {
            customParamenter = txtCustomXdeltaParams.Text;
        }

        private void chbDetEpNum_CheckedChanged(object sender, EventArgs e)
        {
            tryDetectingEpisodeNumber = chbDetEpNum.Checked;
        }

        private void btnSetxdeltaHighCompression_Click(object sender, EventArgs e)
        {
            txtCustomXdeltaParams.Text = "-e -f -7 -B536870912 -S djw -s %source% %patched% %vcdiff%";
        }

        private void btnSetxdeltaHighMem_Click(object sender, EventArgs e)
        {
            txtCustomXdeltaParams.Text = "-e -f -B536870912 -s %source% %patched% %vcdiff%";
        }

        private void btnSetxdeltaDefault_Click(object sender, EventArgs e)
        {
            txtCustomXdeltaParams.Text = "-e -f -s %source% %patched% %vcdiff%";
        }

        private void btnCusXdelHelp_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"https://code.google.com/p/xdelta/w/list");
        }

        private void btnBrowseDefaultOutDir_Click(object sender, EventArgs e)
        {
            if (fbdDirBrowser.ShowDialog() == DialogResult.OK)
            {
                txtDefaultOutDir.Text = fbdDirBrowser.SelectedPath;
            }
        }

        private void rdbSourceDir_CheckedChanged(object sender, EventArgs e)
        {
            outputPlace = 0;
        }

        private void rdbTargetDir_CheckedChanged(object sender, EventArgs e)
        {
            outputPlace = 1;
        }

        private void rdbThisFol_CheckedChanged(object sender, EventArgs e)
        {
            outputPlace = 2;
        }

        private void chbRun64bitxdelta3_CheckedChanged(object sender, EventArgs e)
        {
            run64bitxdelta = chbRun64bitxdelta3.Checked;
        }

        private void chbDist64bitxdelta3_CheckedChanged(object sender, EventArgs e)
        {
            dist64bitxdelta = chbDist64bitxdelta3.Checked;
        }

        private void btnApplySetxdeltaDefault_Click(object sender, EventArgs e)
        {
            txtCustomXdeltaParamsForApplying.Text = "-d -f -s %source% %vcdiff% %output%";
        }

        private void chbFunnyMode_CheckedChanged(object sender, EventArgs e)
        {
            funnyMode = chbFunnyMode.Checked;
            chbOnlyStoreFileNameInVCDIFF.Checked = !chbFunnyMode.Checked;
        }

        private void chbAddNewPatchToApplyAllScripts_CheckedChanged(object sender, EventArgs e)
        {
            addNewPatchToApplyAllScripts = chbAddNewPatchToApplyAllScripts.Checked;
        }

        #endregion

        #region Apply tab

        private void txtApplySource_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) // File only, you faggots!
                e.Effect = DragDropEffects.All;
            else
                e.Effect = DragDropEffects.None;
        }

        private void txtApplyVcdiffFile_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) // File only, you faggots!
                e.Effect = DragDropEffects.All;
            else
                e.Effect = DragDropEffects.None;
        }

        private void txtApplyOutput_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) // File only, you faggots!
                e.Effect = DragDropEffects.All;
            else
                e.Effect = DragDropEffects.None;
        }

        private void txtApplySource_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            txtApplySource.Text = files[0];
        }

        private void txtApplyVcdiffFile_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            txtApplyVcdiffFile.Text = files[0];
        }

        private void txtApplyOutput_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            txtApplyOutput.Text = files[0];
        }
        
        private void btnBrowseApplySource_Click(object sender, EventArgs e)
        {
            if (openFileDialog2.ShowDialog() == DialogResult.OK) txtApplySource.Text = openFileDialog2.FileName;
        }

        private void btnBrowseApplyVcdiffFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog2.ShowDialog() == DialogResult.OK) txtApplyVcdiffFile.Text = openFileDialog2.FileName;
        }

        private void btnBrowseApplyOutput_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.InitialDirectory.Length < 1) saveFileDialog1.InitialDirectory = openFileDialog2.InitialDirectory;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK) txtApplyOutput.Text = saveFileDialog1.FileName;
        }

        #endregion

        #endregion

        #region Setting methods

        private void loadSettings()
        {
            customParamenter = txtCustomXdeltaParams.Text = settings.Read("Setting.CustomParamenter");
            useCustomParamenter = chbUseCustomXdeltaParams.Checked = (settings.Read("Setting.UseCustomParamenter") == "true") ? true : false;
            txtCustomXdeltaParamsForApplying.Text = settings.Read("Setting.CustomApplyingParamenter");
            chbUseCustomXdeltaParamsForApplying.Checked = (settings.Read("Setting.UseCustomApplyingParamenter") == "true") ? true : false;
            tryDetectingEpisodeNumber = chbDetEpNum.Checked = (settings.Read("Setting.DetectEpNum") == "true") ? true : false;
            txtAddTextWhenSwap.Text = settings.Read("Setting.AddThisTextWhenSwap");
            chbAddTextWhenSwap.Checked = (settings.Read("Setting.AddTextWhenSwap") == "true") ? true : false;
            chbNewAutoName.Checked = (settings.Read("Setting.chbNewAutoName") == "true") ? true : false;
            run64bitxdelta = chbRun64bitxdelta3.Checked = (settings.Read("Setting.chbRun64bitxdelta3") == "true") ? true : false;
            dist64bitxdelta = chbDist64bitxdelta3.Checked = (settings.Read("Setting.chbDist64bitxdelta3") == "true") ? true : false;
            string text = settings.Read("OutDir.Place2Go");
            int number = 0;
            if (int.TryParse(text, out number)) this.outputPlace = number;
            switch (outputPlace)
            {
                case 0: rdbSourceDir.Checked = true; break;
                case 1: rdbTargetDir.Checked = true; break;
                case 2: rdbThisFol.Checked = true; break;
                default: rdbSourceDir.Checked = true; break;
            }
            txtDefaultOutDir.Text = settings.Read("OutDir.txtDefaultOutDir");
            chbOnlyStoreFileNameInVCDIFF.Checked = (settings.Read("Setting.chbOnlyStoreFileNameInVCDIFF") == "true") ? true : false;
            funnyMode = chbFunnyMode.Checked = (settings.Read("Setting.chbFunnyMode") == "true") ? true : false;
            addNewPatchToApplyAllScripts = chbAddNewPatchToApplyAllScripts.Checked = (settings.Read("Setting.chbAddNewPatchToApplyAllScripts") == "true") ? true : false;
        }

        private void saveSettings()
        {
            settings.Write("Setting.CustomParamenter", txtCustomXdeltaParams.Text);
            settings.Write("Setting.UseCustomParamenter", (useCustomParamenter) ? "true" : "false");
            settings.Write("Setting.CustomApplyingParamenter", txtCustomXdeltaParamsForApplying.Text);
            settings.Write("Setting.UseCustomApplyingParamenter", (chbUseCustomXdeltaParamsForApplying.Checked) ? "true" : "false");
            settings.Write("Setting.DetectEpNum", (tryDetectingEpisodeNumber) ? "true" : "false");
            settings.Write("Setting.AddThisTextWhenSwap", txtAddTextWhenSwap.Text);
            settings.Write("Setting.AddTextWhenSwap", (chbAddTextWhenSwap.Checked) ? "true" : "false");
            settings.Write("Setting.chbNewAutoName", (chbNewAutoName.Checked) ? "true" : "false");
            settings.Write("Setting.chbRun64bitxdelta3", (chbRun64bitxdelta3.Checked) ? "true" : "false");
            settings.Write("Setting.chbDist64bitxdelta3", (chbDist64bitxdelta3.Checked) ? "true" : "false"); 
            settings.Write("OutDir.Place2Go", this.outputPlace.ToString());
            settings.Write("OutDir.txtDefaultOutDir", this.txtDefaultOutDir.Text);
            settings.Write("Setting.chbOnlyStoreFileNameInVCDIFF", (chbOnlyStoreFileNameInVCDIFF.Checked) ? "true" : "false");
            settings.Write("Setting.chbFunnyMode", (chbFunnyMode.Checked) ? "true" : "false");
            settings.Write("Setting.chbAddNewPatchToApplyAllScripts", (chbAddNewPatchToApplyAllScripts.Checked) ? "true" : "false"); 
            settings.Close();
        }

        #endregion 

    }
}
 