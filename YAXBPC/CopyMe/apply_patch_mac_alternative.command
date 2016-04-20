#!/bin/sh
set -o nounset
set -o errexit

# Roses are red, violets are blue, sugar is sweet, and so are you.
# Enjoy your usual ratio: 5% of lines do the actual work, and the rest are there to make sure they work. (It's like 1%, actually)
# Alternative scripts don't need know about what source/target files are; 
# they let xdelta3 use the default filenames stored in vcdiff file 
# (might not be correct, like tempSource.file, ???, or in the encoding it doesn't understand)

WORKINGDIR=$(pwd)
SCRIPTDIR="$(cd "$(dirname "$0")" && pwd)"
cd "$SCRIPTDIR"
args="$@"

sourcefile=''
targetfile=''
changes="changes.vcdiff"
olddir="old"

find_xdelta3() {
	chmod +x ./xdelta3_mac 2>/dev/null
	if [ "x`uname -s`" = "xDarwin" ] && [ -x ./xdelta3_mac ] && file ./xdelta3_mac | grep -q "Mach-O"; then
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
	found=0
	if [ ! -z "$args" ] && [ ! "$args" = " " ]; then
		if [ -f "$args" ]; then
			sourcefile=$@
			found=1
		else
			echo "Warning: Input file \"$args\" is not found. Ignored."
			found=0
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
	echo "Attempting to patch..."
	if [ ! -z "$sourcefile" ] && [ ! "$sourcefile" = " " ]; then
		`$app -d -f -s "$sourcefile" "$changes"`
		return $?
	else
		`$app -d -f "$changes"`
		return $?
	fi
}

if find_xdelta3 && find_inputs; then
	if run_patch; then
		echo "Done."
		cd "$WORKINGDIR"
		return 0 2>/dev/null || exit 0
	else
		echo "Error: Patching wasn't successful!"
	fi
fi

cd "$WORKINGDIR"
return 1 2>/dev/null || exit 1