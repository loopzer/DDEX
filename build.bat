@if exist "%ProgramFiles%\MSBuild\12.0\bin" set PATH=%ProgramFiles%\MSBuild\12.0\bin;%PATH%
@if exist "%ProgramFiles(x86)%\MSBuild\12.0\bin" set PATH=%ProgramFiles(x86)%\MSBuild\12.0\bin;%PATH%
exec clean.bat
msbuild DDEX.sln /t:DDEX;DDEX_DX9;DDEX_DX11;DDEXNet;DDEXNetCPP;DDEXNetApp;DDEXToolKit /p:Configuration="Debug" /p:Platform="Win32" /p:BuildProjectReferences=false /p:ToolVersion="12.0"
copy /Y DXKit\lib\*.dll Output\