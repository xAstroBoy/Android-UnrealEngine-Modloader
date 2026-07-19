@echo off
setlocal EnableDelayedExpansion

REM ── One build command, BOTH ABIs ────────────────────────────────────────
REM arm64-v8a  -> build\         (64-bit titles: RE4, Pinball FX, ...)
REM armeabi-v7a-> build32\       (32-bit titles: Face Your Fears 1/2, ...)
REM One source tree; an ELF is single-arch, so we emit one libmodloader.so per
REM ABI and the installer drops the matching one into the APK's lib\<abi>\.

set "NDK=C:\Android\AndroidNDK\android-ndk-r23c"
if not exist "%NDK%\build\cmake\android.toolchain.cmake" (
    set "NDK=C:\Program Files (x86)\Android\AndroidNDK\android-ndk-r23c"
)
if not exist "%NDK%\build\cmake\android.toolchain.cmake" (
    echo Android NDK r23c not found.
    echo Checked:
    echo   C:\Android\AndroidNDK\android-ndk-r23c
    echo   "C:\Program Files (x86)\Android\AndroidNDK\android-ndk-r23c"
    exit /b 1
)
set API=24
set "TOOLCHAIN=%NDK%\build\cmake\android.toolchain.cmake"

call :build arm64-v8a   build
if errorlevel 1 exit /b 1
call :build armeabi-v7a build32
if errorlevel 1 exit /b 1

echo.
echo === BUILD SUCCEEDED (both ABIs) ===
echo   arm64-v8a   : %CD%\build\libmodloader.so
echo   armeabi-v7a : %CD%\build32\libmodloader.so
echo Unstripped deploy copies: build\deploy\ and build32\deploy\
echo.
echo addr2line (pick the ABI's dir):
echo   %NDK%\toolchains\llvm\prebuilt\windows-x86_64\bin\llvm-addr2line -e build\libmodloader.so -f 0xADDR
goto :eof

:build
REM %1 = ABI, %2 = output dir
set "ABI=%~1"
set "OUT=%~2"
echo.
echo === Configuring %ABI% -^> %OUT% ===
if not exist "%OUT%" mkdir "%OUT%"
if exist "%OUT%\CMakeCache.txt" del /q "%OUT%\CMakeCache.txt"
if exist "%OUT%\CMakeFiles" rmdir /s /q "%OUT%\CMakeFiles"
pushd "%OUT%"
cmake -G Ninja ^
    "-DCMAKE_TOOLCHAIN_FILE=%TOOLCHAIN%" ^
    -DANDROID_ABI=%ABI% ^
    -DANDROID_PLATFORM=android-%API% ^
    -DANDROID_STL=c++_static ^
    -DCMAKE_BUILD_TYPE=Release ^
    .. || (popd & exit /b 1)
ninja -j%NUMBER_OF_PROCESSORS% || (popd & exit /b 1)
popd
echo === Built %ABI% ===
goto :eof
