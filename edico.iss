; ----------------------------------------------------
; -- edico.iss --
; Setup file for Edico
; Author : Alberto Zanella
;
; A part of Edico Targato Italia
; Copyright (C) 2023 Alberto Zanella - EdicoItalia.it
; This file is covered by the GNU General Public License.
; See the file LICENSE for more details.
; 
; ----------------------------------------------------

#define MyAppName "Edico Targato Italia"
#define MyAppVersion "2023"
#define MyAppPublisher "edicoitalia.it"
#define MyAppURL "https://www.edicoitalia.it/"

[Setup]
AppId={{063011E4-2319-4C02-894C-4AFAF29989CF}}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
;AppVerName={#MyAppName} {#MyAppVersion}
AppPublisher={#MyAppPublisher}
AppPublisherURL={#MyAppURL}
AppSupportURL={#MyAppURL}
AppUpdatesURL={#MyAppURL}
DefaultDirName={localappdata}\Programs\edicoTI
DisableDirPage=yes
DefaultGroupName=EDICO
; Uncomment the following line to run in non administrative install mode (install for current user only.)
PrivilegesRequired=lowest
OutputBaseFilename="edicoitalia"
OutputDir=".\"
Compression=lzma
SolidCompression=yes
AlwaysShowComponentsList=no
DisableWelcomePage=no
DisableProgramGroupPage=yes
UninstallDisplayIcon={app}\edicoTI.exe

[Languages]
Name: "it"; MessagesFile: "compiler:Languages\Italian.isl"

[Tasks]
Name: desktopicon; Description: "{cm:CreateDesktopIcon}"

[Files]
Source: ".\edicoti\bin\release\*"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs
; https://www.microsoft.com/en-US/download/details.aspx?id=42642
Source: ".\DotNetSetup.exe"; DestDir: {tmp}; Flags: deleteafterinstall; AfterInstall: InstallFramework; Check: FrameworkIsNotInstalled

[Icons]
Name: "{group}\Edico Italia"; Filename: "{app}\EdicoTI.exe"; IconFilename:{app}\EdicoTI.exe;
Name: {userdesktop}\Edico Italia; Filename: {app}\EdicoTI.exe; IconFilename:{app}\EdicoTI.exe;


[Code]
procedure InstallFramework;
var
  ResultCode: Integer;
begin
  if not Exec(ExpandConstant('{tmp}\dotNetFx40_Full_x86_x64.exe'), '/q /norestart', '', SW_SHOW, ewWaitUntilTerminated, ResultCode) then
  begin
    { you can interact with the user that the installation failed }
    MsgBox('Errore di installazione di .NET Framework: ' + IntToStr(ResultCode) + '.',
      mbError, MB_OK);
  end;
end;

function FrameworkIsNotInstalled: Boolean;
begin
  Result := not RegKeyExists(HKEY_LOCAL_MACHINE, 'SOFTWARE\Microsoft\NET Framework Setup\NDP\v4\Full');
end;

[Messages]
WelcomeLabel2=Benvenuti nel programma di installazione di EDICO Targato italia, il programma che rende facile l'installazione di EDICO per gli utenti italiani. Il sito web del progetto è www.edicoitalia.it .
