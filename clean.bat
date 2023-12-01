@if exist "%ProgramFiles%\MSBuild\12.0\bin" set PATH=%ProgramFiles%\MSBuild\12.0\bin;%PATH%
@if exist "%ProgramFiles(x86)%\MSBuild\12.0\bin" set PATH=%ProgramFiles(x86)%\MSBuild\12.0\bin;%PATH%

msbuild DDEX.sln /t:DDEX:clean;DDEX_DX9:clean;DDEX_DX11:clean;DDEXNet:clean;DDEXNetCPP:clean;DDEXNetApp:clean;DDEXToolKit:clean /p:Configuration="Debug" /p:Platform="Win32" /p:BuildProjectReferences=false /p:ToolVersion="12.0"