$global:WORKINGDIR = get-location
$global:SCRIPTDIR = split-path $MyInvocation.MyCommand.Definition -parent
Set-Location $global:SCRIPTDIR

$global:sourcefile = '&sourcefile&' # keep it in a pair of single quotes. Any single quote must be doubled (replace ' with '')
$global:targetfile = '&targetfile&'
$global:app = '.\xdelta3.exe'
$global:changes = 'changes.vcdiff'
$global:sourcefiletmp = 'sourcefile.tmp'
$global:targetfiletmp = 'targetfile.tmp'
$global:movesourcefile = 0
$global:movetargetfile = 0
$global:olddir = 'old'

function check_sanity {
    $re = $true
    If (!(Test-Path -LiteralPath $global:app)) {
        Write-Host "Error: The required application '$global:app' is missing."
        $re = $false
    }
    if (!(Test-Path -LiteralPath "$global:changes")) {
        Write-Host "Error: The delta file '$global:changes' is missing."
        $re = $false
    }
    if (!$re) {
        Write-Host "Can't continue. Please extract everything from the archive."
    }
    return $re
}

function find_inputs ([String] $dropin = "") {
    if ($dropin) {
        if (Test-Path -LiteralPath $dropin) {
            $global:sourcefile = $dropin
        } else {
            Write-Host "Warning: Input file '$dropin' not found. Ignored."
        }
    }

    if (!(Test-Path -LiteralPath $global:sourcefile)) {
        if (Test-Path -LiteralPath ('..\' + $global:sourcefile)) {
            $global:sourcefile = '..\' + $global:sourcefile
        } elseif (Test-Path -LiteralPath ('..\..\' + $global:sourcefile)) {
            $global:sourcefile = '..\..\' + $global:sourcefile
        } elseif (Test-Path -LiteralPath ('..\..\..\' + $global:sourcefile)) {
            $global:sourcefile = '..\..\..\' + $global:sourcefile
        } else {
            Write-Host "Error: Source file '$global:sourcefile' not found."
            Write-Host "You must put it in the same folder as this script."
            return $false
        }
    }

    $parent = Split-Path $global:sourcefile -Parent
    if ($parent) {
        $global:targetfile = Join-Path $parent $global:targetfile
        $global:sourcefiletmp = Join-Path $parent $global:sourcefiletmp
        $global:targetfiletmp = Join-Path $parent $global:targetfiletmp
        $global:olddir = Join-Path $parent $global:olddir
    }

    return $true
}

function run_patch {
    Write-Host "Attempting to patch '$sourcefile' ..."

    if ($global:movesourcefile -eq 1) {
        Move-Item -literalPath $global:sourcefile $global:sourcefiletmp -force
    } else {
        $global:sourcefiletmp = $global:sourcefile
    }

    if ($global:movetargetfile -eq 0) {
        $global:targetfiletmp = $global:targetfile
    }

    Start-Process -FilePath "$global:app" -ArgumentList "-d -f -s `"$global:sourcefiletmp`" `"$global:changes`" `"$global:targetfiletmp`"" -NoNewWindow -Wait

    if ($global:movesourcefile -eq 1) {
        Move-Item -literalPath $global:sourcefiletmp $global:sourcefile -force
    }
    if ($global:movetargetfile -eq 1) {
        Move-Item -literalPath $global:targetfiletmp $global:targetfile -force
    }

    if (Test-Path -LiteralPath $global:targetfile) {
        if ( -Not (Test-Path -LiteralPath $global:olddir)) {
            New-Item -Path $global:olddir -ItemType Directory | out-null
        }
        Move-Item -literalPath $global:sourcefile $global:olddir -force
        Write-Host "Done."
        return $true
    } else {
        Write-Host "Error occured! Patching wasn't successful!"
        return $false
    }
}

if (((check_sanity) -eq $true) -and ((find_inputs $args[0]) -eq $true)) {
    $dummy = run_patch
}

Set-Location($global:WORKINGDIR)
exit 0
