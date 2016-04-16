/*
   Copyright 2013 © Nguyen Hung Quy (dreamer2908)

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

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace YAXBPC
{
    class Database
    {
        public Database(string filePath)
        {
            this.filePath = filePath;            
        }

        private string filePath = "";

        // We store the name in /names/ and data in /data/
        List<string> names = new List<string>();
        List<string> data = new List<string>();

        public string FilePath
        {
            get { return this.filePath; }
            set { this.filePath = value; }
        }

        /// <summary>
        /// Adds a new variable to database or updates an existing variable.
        /// </summary>
        /// <param name="name">The name of the variable you want to store. It mustn't contain any '=' or newline character</param>
        /// <param name="value">Its value</param>
        /// <returns>True if writing sucessfully, else false</returns>
        public Boolean Write(string name, string value)
        {
            if (name.Contains("=") || name.Contains("\r") || name.Contains("\n")) return false;
            int i = names.IndexOf(name);
            if (i < 0)
            {
                // add new item
                names.Add(name);
                data.Add(value);
            }
            else
            {
                // update item
                data[i] = value;
            }
            return true;
        }

        /// <summary>
        /// Reads a variable in database
        /// </summary>
        /// <param name="name">The name of the variable you want to read</param>
        /// <returns>Its value if found, else null</returns>
        public string Read(string name)
        {
            int i = names.IndexOf(name);
            if (i >= 0)
            {
                return data[i];
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Loads data from file
        /// </summary>
        /// <returns>Error message if any</returns>
        public string Load()
        {
            try
            {
                string[] fileContent = System.IO.File.ReadAllLines(filePath);
                foreach (string t in fileContent)
                {
                    int pos = t.IndexOf("=");
                    if (pos > 0)
                    {
                        string name = t.Substring(0,pos);
                        string value = (t.Length > pos + 1) ? t.Substring(pos + 1) : "";
                        this.Write(name, value);
                    }
                }
            }
            catch (Exception e)
            {
                return e.Message;
            }
            return null;
        }

        /// <summary>
        /// Writes data in cache to disk
        /// </summary>
        /// <returns>Error message if any</returns>
        public string Flush()
        {
            try
            {
                System.IO.File.WriteAllText(filePath, this.ToString());
            }
            catch(Exception e)
            {
                return e.Message;
            }
            return null;
        }

        /// <summary>
        /// Returns all data currently storing in string format
        /// </summary>
        /// <returns>Data in string format</returns>
        public override string ToString()
        {
            string output = "";
            int n = names.Count;
            for (int i = 0; i < n; i++)
            {
                output += names[i] + "=" + data[i] + "\n";
            }
            return output;
        }

        /// <summary>
        /// Flushes data cache and closes. *Incomplete*
        /// </summary>
        public void Close()
        {
            this.Flush();
        }
    }
}
