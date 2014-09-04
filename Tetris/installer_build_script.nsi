;dotTetris install script
;@author anewkirk
;--------------------------------
!define APPNAME "DotTetris"
!define COMPANYNAME "Team dotTetris"
!define VERSIONMAJOR 1
!define VERSIONMINOR 1
!define VERSIONBUILD 1
;--------------------------------
Name "dotTetrisInstaller"
Icon "Icon.ico"
OutFile "DotTetrisSetup.exe"
InstallDir $PROGRAMFILES\dotTetris
LicenseData "License.rtf"
RequestExecutionLevel admin
;--------------------------------
Page license
Page directory
Page instfiles
;--------------------------------

Section ""
  SetOutPath $INSTDIR
    
  File /r bin
  File /r Images
  
  createDirectory "$SMPROGRAMS\${COMPANYNAME}"
  createShortCut "$SMPROGRAMS\${COMPANYNAME}\${APPNAME}.lnk" "$INSTDIR\bin\Release\Tetris.exe" "" "$INSTDIR\Images\Icon.ico"
  
SectionEnd ; end the section
