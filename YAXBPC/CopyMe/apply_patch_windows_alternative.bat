@echo off
setlocal

rem Roses are red, violets are blue, sugar is sweet, and so are you.
rem Enjoy your usual ratio: 5% of lines do the actual work, and the rest are there to make sure they work. (It's like 1%, actually)

set app=xdelta3.exe
set changes=changes.vcdiff
set WORKINGDIR=%CD%
chdir /d "%~dp0"

if exist "%~1" (
    echo Attempting to patch %~1...
    %app% -d -f -s "%~1" "%changes%"
) else (
    echo Attempting to patch...
    %app% -d -f "%changes%"
)
echo Done. Press enter to exit.
chdir /d "%WORKINGDIR%"
pause
exit /b

