param
(
    [string] $version = "0.0.1"
)

ls -Filter *.nupkg | rm -Force

$nuget = Join-Path $PSScriptRoot "\NuGet-Signed.exe" -Resolve
$nuspecs = ls -Path $PSScriptRoot -Filter *.nuspec

foreach($nuspec in $nuspecs)
{
    & $nuget Pack $nuspec -version $version -NonInteractive
}