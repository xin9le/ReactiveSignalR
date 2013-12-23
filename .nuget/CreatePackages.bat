@echo off


set Startup=%~dp0
set Output=%Startup%Packages

if exist "%Output%" (
	rmdir	/s /q	"%Output%"
)
mkdir	"%Output%"

NuGet.exe	pack	ReactiveSignalR.Client.nuspec	-OutputDirectory "%Output%"
NuGet.exe	pack	ReactiveSignalR.Server.nuspec	-OutputDirectory "%Output%"

pause