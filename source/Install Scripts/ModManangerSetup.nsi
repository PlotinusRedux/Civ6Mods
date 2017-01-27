!define PRODUCT_NAME "ModManager"
!define PRODUCT_VERSION "0.7"
!define PRODUCT_PUBLISHER "PlotinusRedux"
!define OUT_PATH "..\..\publish"
!define BIN_PATH "..\..\bin\ModManager\Release\x64"
!define SOURCE_PATH "..\..\Source"
!define SQLITE3_FILE "sqlite3.dll"
!define SCINTILLA_FILE "ScintillaNET.dll"
!define KDIFF3_PATH "..\..\Source\3rdParty\KDiff3"

Name "${PRODUCT_NAME} ${PRODUCT_VERSION}"
OutFile "${OUT_PATH}\${PRODUCT_NAME}_Setup_v${PRODUCT_VERSION}.exe"
InstallDir $PROGRAMFILES64\${PRODUCT_NAME}

LoadLanguageFile "${NSISDIR}\Contrib\Language files\English.nlf"
;--------------------------------
;Version Information

  VIProductVersion "${PRODUCT_VERSION}.0.0"
  VIAddVersionKey /LANG=${LANG_ENGLISH} "ProductName" "${PRODUCT_NAME}"
  VIAddVersionKey /LANG=${LANG_ENGLISH} "FileDescription" "${PRODUCT_NAME}"
  VIAddVersionKey /LANG=${LANG_ENGLISH} "LegalCopyright" "Copyright 2017"
  VIAddVersionKey /LANG=${LANG_ENGLISH} "FileVersion" "${PRODUCT_VERSION}.0.0"


; Registry key to check for directory (so if you install again, it will 
; overwrite the old one automatically)
InstallDirRegKey HKLM "Software\${PRODUCT_NAME}" "Install_Dir"

; Request application privileges for Windows Vista
RequestExecutionLevel admin

;--------------------------------

; Pages

Page components
Page directory
Page instfiles


UninstPage uninstConfirm
UninstPage instfiles

;--------------------------------

; The stuff to install
Section "ModManager (required)"

  SectionIn RO
  
  ; Set output path to the installation directory.
  SetOutPath $INSTDIR
  
  ; Put file there
  File "${BIN_PATH}\${PRODUCT_NAME}.exe"
  File "${BIN_PATH}\sqlite3.dll"
  File "${BIN_PATH}\ScintillaNET.dll"
  File "${BIN_PATH}\ReadMe.md"  
  File "${SOURCE_PATH}\3rdParty\NDP462-KB3151802-Web.exe"
  
  
  ; Write the installation path into the registry
  WriteRegStr HKLM SOFTWARE\${PRODUCT_NAME} "Install_Dir" "$INSTDIR"
  
  ; Write the uninstall keys for Windows
  WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\${PRODUCT_NAME}" "DisplayName" "${PRODUCT_NAME}"
  WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\${PRODUCT_NAME}" "UninstallString" '"$INSTDIR\uninstall.exe"'
  WriteRegDWORD HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\${PRODUCT_NAME}" "NoModify" 1
  WriteRegDWORD HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\${PRODUCT_NAME}" "NoRepair" 1
  WriteUninstaller "uninstall.exe"
  
  CreateDirectory "$SMPROGRAMS\${PRODUCT_NAME}"
  CreateShortcut "$SMPROGRAMS\${PRODUCT_NAME}\${PRODUCT_NAME}.lnk" "$INSTDIR\${PRODUCT_NAME}.exe" "" "$INSTDIR\${PRODUCT_NAME}.exe" 0  
  CreateDirectory "$SMPROGRAMS\${PRODUCT_NAME}\Utilities"
  CreateShortcut "$SMPROGRAMS\${PRODUCT_NAME}\Utilities\Uninstall.lnk" "$INSTDIR\uninstall.exe" "" "$INSTDIR\uninstall.exe" 0
  CreateShortCut "$DESKTOP\${PRODUCT_NAME}.lnk" "$INSTDIR\${PRODUCT_NAME}.exe" "" "$INSTDIR\${PRODUCT_NAME}.exe" 0

  
SectionEnd

Section "KDiff3"
 
  ; Set output path to the installation directory.
  SetOutPath "$INSTDIR\KDiff3"
  
  File /r "${KDIFF3_PATH}\*.*"
  
  CreateShortcut "$SMPROGRAMS\${PRODUCT_NAME}\Utilities\KDiff3.lnk" "$INSTDIR\KDiff3\kdiff3.exe" "" "$INSTDIR\KDiff3\kdiff3.exe" 0
SectionEnd

;--------------------------------

; Uninstaller

Section "Uninstall"
  
  ; Remove registry keys
  DeleteRegKey HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\${PRODUCT_NAME}"
  DeleteRegKey HKLM "SOFTWARE\${PRODUCT_NAME}"

  ; Remove directories used
  RMDir /r "$SMPROGRAMS\${PRODUCT_NAME}"
  
  Delete "$DESKTOP\${PRODUCT_NAME}.lnk"

  ; Remove files and uninstaller
  RMDir /r /REBOOTOK "$INSTDIR"

SectionEnd

Function .onInstSuccess
	Var /GLOBAL dotNET45IsThere
	
	ReadRegDWORD $dotNET45IsThere HKLM "SOFTWARE\Microsoft\NET Framework Setup\NDP\v4\Full" "Release"
	IntCmp $dotNET45IsThere 378389 is_equal is_less is_greater
	is_equal:
		Goto done_compare_not_needed
	is_greater:
		Goto done_compare_not_needed
	is_less:
		ExecWait "$INSTDIR\NDP462-KB3151802-Web.exe"
		
	done_compare_not_needed:
	
	ExecShell "" "$SMPROGRAMS\${PRODUCT_NAME}\${PRODUCT_NAME}.lnk"
FunctionEnd
