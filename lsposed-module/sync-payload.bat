@echo off
REM Copy the freshly built libmodloader.so into the LSPosed module's jniLibs.
setlocal
set SRC=%~dp0..\modloader\build\libmodloader.so
set DST=%~dp0app\src\main\jniLibs\arm64-v8a\libmodloader.so
if not exist "%SRC%" (
    echo [sync-payload] ERROR: %SRC% not found. Build the modloader first ^(modloader\build.bat^).
    exit /b 1
)
copy /Y "%SRC%" "%DST%" >nul
if errorlevel 1 (
    echo [sync-payload] ERROR: copy failed.
    exit /b 1
)
echo [sync-payload] Copied libmodloader.so -^> jniLibs\arm64-v8a\
endlocal
