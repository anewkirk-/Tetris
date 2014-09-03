;dotTetris install script
;@author anewkirk
;--------------------------------
Name "dotTetrisInstaller"
OutFile "DotTetrisSetup.exe"
InstallDir $PROGRAMFILES\dotTetris

RequestExecutionLevel admin
;--------------------------------
Page directory
Page instfiles
;--------------------------------

Section ""
  SetOutPath $INSTDIR
    
  File /r bin\Debug
  File /r Sound
  File /r Images
SectionEnd ; end the section
