@echo off
REM Copy the freshly built libmodloader.so (BOTH ABIs) into the LSPosed module's
REM jniLibs. arm64-v8a for 64-bit titles, armeabi-v7a for 32-bit titles.
setlocal
set SRC64=%~dp0..\modloader\build\libmodloader.so
set DST64=%~dp0app\src\main\jniLibs\arm64-v8a\libmodloader.so
set SRC32=%~dp0..\modloader\build32\libmodloader.so
set DST32=%~dp0app\src\main\jniLibs\armeabi-v7a\libmodloader.so

if not exist "%SRC64%" (
    echo [sync-payload] ERROR: %SRC64% not found. Build the modloader first ^(modloader\build.bat^).
    exit /b 1
)
if not exist "%SRC32%" (
    echo [sync-payload] ERROR: %SRC32% not found. Build the modloader first ^(modloader\build.bat builds BOTH ABIs^).
    exit /b 1
)

if not exist "%~dp0app\src\main\jniLibs\arm64-v8a" mkdir "%~dp0app\src\main\jniLibs\arm64-v8a"
if not exist "%~dp0app\src\main\jniLibs\armeabi-v7a" mkdir "%~dp0app\src\main\jniLibs\armeabi-v7a"

copy /Y "%SRC64%" "%DST64%" >nul || (echo [sync-payload] ERROR: arm64 copy failed. & exit /b 1)
copy /Y "%SRC32%" "%DST32%" >nul || (echo [sync-payload] ERROR: arm32 copy failed. & exit /b 1)
echo [sync-payload] Copied libmodloader.so -^> jniLibs\arm64-v8a\ and jniLibs\armeabi-v7a\
endlocal
