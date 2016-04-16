
@echo off
setlocal

rem Roses are red, violets are blue, sugar is sweet, and so are you.
rem Enjoy your usual ratio: 5% of lines do the actual work, and the rest are there to make sure they work. (It's like 1%, actually)

for /f "tokens=2 delims=:." %%x in ('chcp') do set cp=%%x
chcp 65001>nul
set sourcefile=&sourcefile&
set targetfile=&targetfile&
set app=xdelta3.exe
set changes=changes.vcdiff
set sourcefiletmp=sourcefile.tmp
set targetfiletmp=targetfile.tmp
set movesourcefile=0
set movetargetfile=0
set olddir=old
set WORKINGDIR=%CD%
chdir /d %~dp0
(call )

call :find_xdelta3 && call :find_inputs && call :run_patch
call :gtfo
goto :eof


:find_xdelta3
(call)
if exist "%changes%" (
	(call )
) else (
	echo The required application "%app%" can't be found!
)
goto :eof

:find_inputs
(call)
if exist "%~1" (
    set sourcefile=%~1
	(call )
)
if not exist "%sourcefile%" (
	if exist "..\%sourcefile%" (
		set "sourcefile=..\%sourcefile%"
		set "targetfile=..\%targetfile%"
		set "sourcefiletmp=..\sourcefile.tmp"
		set "targetfiletmp=..\targetfile.tmp"
		set "olddir=..\%olddir%"
		(call )
	) else (
		if exist "..\..\%sourcefile%" (
			set "sourcefile=..\..\%sourcefile%"
			set "targetfile=..\..\%targetfile%"
			set "sourcefiletmp=..\..\sourcefile.tmp"
			set "targetfiletmp=..\..\targetfile.tmp"
			set "olddir=..\..\%olddir%"
			(call )
		) else ( 
			if exist "..\..\..\%sourcefile%" (
				set "sourcefile=..\..\..\%sourcefile%"
				set "targetfile=..\..\..\%targetfile%"
				set "sourcefiletmp=..\..\..\sourcefile.tmp"
				set "targetfiletmp=..\..\..\targetfile.tmp"
				set "olddir=..\..\..\%olddir%"
				(call )
			) else ( 
				echo Error: Source file "%sourcefile%" not found.
				echo You must put it in the same folder as this script.
				(call)
			)
		)
	)
) else (
	(call )
)
if not exist "%changes%" (
	echo Error: VCDIFF file \"$changes\" is missing.
	echo Please extract everything from the archive.
	(call)
)
goto :eof

:run_patch
echo Attempting to patch "%sourcefile%"...
if %movesourcefile% equ 1 (
	move "%sourcefile%" "%sourcefiletmp%" > nul
) else (
	set "sourcefiletmp=%sourcefile%"
)
if %movetargetfile% equ 0 set "targetfiletmp=%targetfile%"
%app% -d -f -s "%sourcefiletmp%" "%changes%" "%targetfiletmp%"
if %movesourcefile% equ 1 move "%sourcefiletmp%" "%sourcefile%" > nul
if %movetargetfile% equ 1 move "%targetfiletmp%" "%targetfile%" > nul
if exist "%targetfile%" (
	mkdir %olddir% 2>nul
	move "%sourcefile%" %olddir%
	echo Done.
	(call )
	goto :eof
)
echo Error occured! Patching wasn't successful!
(call)
pause
goto :eof

:gtfo
chdir /d %WORKINGDIR%
chcp %cp%>nul
(call )
goto :eof
