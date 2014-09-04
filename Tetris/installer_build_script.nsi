;dotTetris install script
;@author anewkirk
;--------------------------------
!define APPNAME "DotTetris"
!define COMPANYNAME "Team dotTetris"
!define VERSIONMAJOR 1
!define VERSIONMINOR 1
!define VERSIONBUILD 1
;--------------------------------
Name "dotTetris"
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

Section "install"
  SetOutPath $INSTDIR
  
  File /r bin
  File /r Images
  
  writeUninstaller "$INSTDIR\uninstall.exe"
  
  createDirectory "$SMPROGRAMS\${COMPANYNAME}"
  createShortCut "$SMPROGRAMS\${COMPANYNAME}\${APPNAME}.lnk" "$INSTDIR\bin\Release\Tetris.exe" "" "$INSTDIR\Images\Icon.ico"
  
	WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\${COMPANYNAME} ${APPNAME}" "DisplayName" "${APPNAME}"
	WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\${COMPANYNAME} ${APPNAME}" "UninstallString" "$\"$INSTDIR\uninstall.exe$\""
	WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\${COMPANYNAME} ${APPNAME}" "QuietUninstallString" "$\"$INSTDIR\uninstall.exe$\" /S"
	WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\${COMPANYNAME} ${APPNAME}" "InstallLocation" "$\"$INSTDIR$\""
	WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\${COMPANYNAME} ${APPNAME}" "DisplayIcon" "$\"$INSTDIR\Images\Icon.ico$\""
	WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\${COMPANYNAME} ${APPNAME}" "Publisher" "$\"${COMPANYNAME}$\""
	WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\${COMPANYNAME} ${APPNAME}" "DisplayVersion" "$\"${VERSIONMAJOR}.${VERSIONMINOR}.${VERSIONBUILD}$\""
	WriteRegDWORD HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\${COMPANYNAME} ${APPNAME}" "VersionMajor" ${VERSIONMAJOR}
	WriteRegDWORD HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\${COMPANYNAME} ${APPNAME}" "VersionMinor" ${VERSIONMINOR}
	WriteRegDWORD HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\${COMPANYNAME} ${APPNAME}" "NoModify" 1
	WriteRegDWORD HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\${COMPANYNAME} ${APPNAME}" "NoRepair" 1
SectionEnd
;--------------------------------
 function un.onInit
	SetShellVarContext all
	MessageBox MB_OKCANCEL "Permanantly remove ${APPNAME}?" IDOK
functionEnd
 ;--------------------------------
section "uninstall"
 
	delete "$SMPROGRAMS\${COMPANYNAME}\${APPNAME}.lnk"
	rmDir "$SMPROGRAMS\${COMPANYNAME}"
 
	delete $INSTDIR\bin\Release\highscores.sqlite
	delete $INSTDIR\bin\Release\Tetris.exe
	delete $INSTDIR\bin\Release\Tetris.exe.config
	delete $INSTDIR\bin\Release\Tetris.pdb
	delete $INSTDIR\bin\Release\Tetris.vshost.exe
	delete $INSTDIR\bin\Release\Tetris.vshost.exe.config
	delete $INSTDIR\bin\Release\Tetris.vshost.exe.manifest
	delete $INSTDIR\Images\dotTetris.png
	delete $INSTDIR\Images\dotTetrisLogo.png
	delete $INSTDIR\Images\highScoreLogo.png
	delete $INSTDIR\Images\Icon.ico
	delete $INSTDIR\Images\MousePointer.png
	delete $INSTDIR\Images\soloLogo.png
	delete $INSTDIR\Images\sound_music.png
	delete $INSTDIR\Images\sound_music_muted.png
	delete $INSTDIR\Images\sound_sfx.png
	delete $INSTDIR\Images\sound_sfx_muted.png
	delete $INSTDIR\Images\Thumbs.db
	delete $INSTDIR\Images\vsLogo.png
	delete $INSTDIR\Sound\Music\TetrisThemeSong-old1.wav
	delete $INSTDIR\Sound\Music\TetrisThemeSong.wav
	delete $INSTDIR\Sound\SoundEffects\Tetris_Collission.wav
	delete $INSTDIR\Sound\SoundEffects\Tetris_Countdown.wav
	delete $INSTDIR\Sound\SoundEffects\Tetris_Dominating.wav
	delete $INSTDIR\Sound\SoundEffects\Tetris_DoubleLineClear.wav
	delete $INSTDIR\Sound\SoundEffects\Tetris_GameOver.wav
	delete $INSTDIR\Sound\SoundEffects\Tetris_GameStart.wav
	delete $INSTDIR\Sound\SoundEffects\Tetris_HighScore.wav

	rmDir "$INSTDIR\bin\Release\"
	rmDir "$INSTDIR\Images\"
	rmDir "$INSTDIR\Sound\Music\"
	rmDir "$INSTDIR\Sound\SoundEffects\"
	rmDir "$INSTDIR\Sound\"
	
	delete $INSTDIR\uninstall.exe
	rmDir /r $INSTDIR
	DeleteRegKey HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\${COMPANYNAME} ${APPNAME}"
sectionEnd
 ;--------------------------------