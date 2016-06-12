#!/bin/sh
# Do not use nounset here
# Do not use errexit here

# Roses are red, violets are blue, sugar is sweet, and so are you.
# Enjoy your usual ratio: 5% of lines do the actual work, and the rest are there to make sure they work. (It's like 1%, actually)
# Alternative scripts don't need know about what source/target files are; 
# they let xdelta3 use the default filenames stored in vcdiff file 
# (might not be correct, like tempSource.file, ???, or in the encoding it doesn't understand)

WORKINGDIR=$(pwd)
SCRIPTDIR="$(cd "$(dirname "$0")" && pwd)"
cd "$SCRIPTDIR"
args="$@"
dropin="$1"

sourcefile=''
targetfile=''
changes="changes.vcdiff"
olddir="old"

find_xdelta3() {
	chmod +x ./xdelta3 2>/dev/null
	chmod +x ./xdelta3.x86_64 2>/dev/null
	case $(uname -m) in
		i*86) arch=x86;;
		Pentium*|AMD?Athlon*) arch=x86;;
		amd64|x86_64) arch=x86_64;;
		*) arch=other;;
	esac
	if [ "$(uname)" = "Linux" ] && [ "$arch" = "x86_64" ] && [ -x ./xdelta3.x86_64 ] && file ./xdelta3.x86_64 | grep -q "GNU/Linux"; then
		app="./xdelta3.x86_64"
	elif [ "$(uname)" = "Linux" ] && [ "$arch" = "x86" ] && [ -x ./xdelta3 ] && file ./xdelta3 | grep -q "GNU/Linux"; then
		app="./xdelta3"
	elif hash xdelta3 2>/dev/null; then
		app="xdelta3"
	elif hash wine 2>/dev/null && [ -f "xdelta3.exe" ]; then
		app="wine ./xdelta3.exe"
	else
		echo "Error: The required application is not found or inaccessible."
		echo "Please either make sure the file \"xdelta3\" has execute rights, install xdelta3 [recommended], or install WinE."
		cd "$WORKINGDIR"
		return 1
	fi
	return 0
}

find_inputs() {
	if [ ! -z "$dropin" ] && [ ! "$dropin" = " " ]; then
		if [ -f "$dropin" ]; then
			sourcefile="$dropin"
		else
			echo "Warning: Input file \"$dropin\" is not found. Ignored."
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