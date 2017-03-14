@ECHO OFF
SET Arbor.X.Build.Bootstrapper.AllowPrerelease=true
SET Arbor.X.Tools.External.MSpec.Enabled=true
SET Arbor.X.MSBuild.NuGetRestore.Enabled=true

CALL "%~dp0\Build.exe"

EXIT /B %ERRORLEVEL%
