#!/bin/sh
# Do not use nounset here
# Do not use errexit here

# Roses are red, violets are blue, sugar is sweet, and so are you.
# Enjoy your usual ratio: 5% of lines do the actual work, and the rest are there to make sure they work. (It's like 1%, actually)

WORKINGDIR=$(pwd)
SCRIPTDIR="$(cd "$(dirname "$0")" && pwd)"
cd "$SCRIPTDIR"
args="$@"
dropin="$1"

sourcefile='&sourcefile&'
targetfile='&targetfile&'
changes="changes.vcdiff"
olddir="old"

find_xdelta3() {
	chmod +x ./xdelta3_mac 2>/dev/null
	case $(uname -m) in
		i*86) arch=x86;;
		Pentium*|AMD?Athlon*) arch=x86;;
		amd64|x86_64) arch=x86_64;;
		*) arch=other;;
	esac
	if [ "x`uname -s`" = "xDarwin" ] && [ "$arch" = "x86_64" ] && [ -x ./xdelta3_mac ] && file ./xdelta3_mac | grep -q "Mach-O"; then
		app="./xdelta3_mac"
	elif hash xdelta3 2>/dev/null; then
		app="xdelta3"
	elif hash wine 2>/dev/null && [ -f "xdelta3.exe" ]; then
		app="wine ./xdelta3.exe"
	else
		echo "Error: The required application is not found or inaccessible."
		echo "Please either make sure the file \"xdelta3_mac\" has execute rights, install xdelta3 [recommended], or install WinE."
		cd "$WORKINGDIR"
		return 1
	fi
	return 0
}

find_inputs() {
	if [ ! -z "$dropin" ] && [ ! "$dropin" = " " ]; then
		if [ -f "$dropin" ]; then
			sourcefile="$dropin"
            targetfile="$(dirname "$sourcefile")/$targetfile"
            olddir="$(dirname "$sourcefile")/$olddir"
		else
			echo "Warning: Input file \"$dropin\" is not found. Ignored."
		fi
	fi
	if [ ! -f "$sourcefile" ]; then
		if [ -f "../$sourcefile" ]; then
			sourcefile="../$sourcefile"
			targetfile="../$targetfile"
			olddir="../$olddir"
		else
			if [ -f "../../$sourcefile" ]; then
				sourcefile="../../$sourcefile"
				targetfile="../../$targetfile"
				olddir="../../$olddir"
			else
				if [ -f "../../../$sourcefile" ]; then
					sourcefile="../../../$sourcefile"
					targetfile="../../../$targetfile"
					olddir="../../../$olddir"
				else
					echo "Error: Source file not found."
					echo "The file \"$sourcefile\" must be in the same folder as this script."
					cd "$WORKINGDIR"
					return 1
				fi
			fi
		fi
	fi
	if [ ! -f "$changes" ]; then
		echo "Error: VCDIFF file \"$changes\" is missing."
		echo "Please extract everything from the archive."
		cd "$WORKINGDIR"
		return 1
	fi
	return 0
}

run_patch () {
	echo "Attempting to patch \"$sourcefile\"..."
	`$app -d -f -s "$sourcefile" "$changes" "$targetfile"`
	return $?
}

move_old_file () {
	if [ -f "$targetfile" ] && [ ! -f "do_not_move_old_file.txt" ]; then
		mkdir -p "$olddir" >/dev/null
		if mv "$sourcefile" "$olddir/"; then
			echo "Moved the old file to directory \"$olddir\"."
			return 0
		else
			echo "Warning: Couldn't moved the old file."
			return 1
		fi
	fi
	return 0
}

if find_xdelta3 && find_inputs; then
	if run_patch; then
		if ! move_old_file; then
			ignore=1
		fi
		echo "Done."
		cd "$WORKINGDIR"
		return 0 2>/dev/null || exit 0
	else
		echo "Error: Patching wasn't successful!"
	fi
fi

cd "$WORKINGDIR"
return 1 2>/dev/null || exit 1