; InnoSetup installer creation script for Trigram Generator.
; Change all references to C:\Users\Xangis\code to match your working directory.
;
; Script generated by the Inno Setup Script Wizard.
; SEE THE DOCUMENTATION FOR DETAILS ON CREATING INNO SETUP SCRIPT FILES!

#define MyAppName "Lambda Trigram Generator"
#define MyAppVersion "2.0"
#define MyAppPublisher "Lambda Centauri"
#define MyAppURL "https://lambdacentauri.com/software_trigram.htm"
#define MyAppExeName "TrigramGenerator.exe"
#define CodeDir "E:\code\TrigramGenerator"

[Setup]
; NOTE: The value of AppId uniquely identifies this application.
; Do not use the same AppId value in installers for other applications.
; (To generate a new GUID, click Tools | Generate GUID inside the IDE.)
AppId={{8C570AD8-4DF8-4356-B0C2-01D450380327}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
AppPublisher={#MyAppPublisher}
AppPublisherURL={#MyAppURL}
AppSupportURL={#MyAppURL}
AppUpdatesURL={#MyAppURL}
DefaultDirName={pf}\{#MyAppPublisher}\{#MyAppName}
DefaultGroupName={#MyAppPublisher}
LicenseFile={#CodeDir}\LICENSE.TXT
OutputDir={#CodeDir}\installer
OutputBaseFilename=LambdaTrigramGenerator{#MyAppVersion}Setup
SetupIconFile={#CodeDir}\images\trigram.ico
UninstallDisplayIcon={app}\trigram.ico
Compression=lzma
SolidCompression=yes

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked

[Files]
Source: "{#CodeDir}\images\trigram.ico"; DestDir: "{app}"; Flags: ignoreversion
Source: "{#CodeDir}\bin\Release\{#MyAppExeName}"; DestDir: "{app}"; Flags: ignoreversion
Source: "{#CodeDir}\LICENSE.TXT"; DestDir: "{app}"; Flags: ignoreversion
Source: "{#CodeDir}\starnames.txt"; DestDir: "{app}"; Flags: ignoreversion
Source: "{#CodeDir}\stormnames.txt"; DestDir: "{app}"; Flags: ignoreversion

[Icons]
Name: "{group}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"
Name: "{commondesktop}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; Tasks: desktopicon; WorkingDir: "{app}"
Name: "{group}\{cm:ProgramOnTheWeb,Lambda Trigram Generator}"; Filename: "{#MyAppURL}"

[Run]
Filename: "{app}\{#MyAppExeName}"; Description: "{cm:LaunchProgram,Trigram Generator}"; Flags: nowait postinstall skipifsilent

