$nuget = Join-Path $PSScriptRoot "\NuGet-Signed.exe" -Resolve
$nuspecs = ls -Path $PSScriptRoot -Filter *.nuspec

foreach($nuspec in $nuspecs)
{
    & $nuget Pack $nuspec
}