param
(
    [string] $version = "0.0.1"
)

ls -Filter *.nupkg | rm -Force

$nuget = Join-Path $PSScriptRoot "\nuget.exe" -Resolve

$nuspecs = @(
".\Eco.Tools.Sources.nuspec", 
".\Eco.Tools.Core.nuspec", 
".\Eco.Tools.Recycling.nuspec"
".\Eco.Tools.nuspec")

foreach($nuspec in $nuspecs)
{
    $nuspecLocation = ls -Path $PSScriptRoot -Filter $nuspec
    
    & $nuget Pack $nuspecLocation -version $version -NonInteractive
}