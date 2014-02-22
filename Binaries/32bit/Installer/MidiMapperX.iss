; Script generated by the Inno Setup Script Wizard.
; SEE THE DOCUMENTATION FOR DETAILS ON CREATING INNO SETUP SCRIPT FILES!

[Setup]
; NOTE: The value of AppId uniquely identifies this application.
; Do not use the same AppId value in installers for other applications.
; (To generate a new GUID, click Tools | Generate GUID inside the IDE.)
AppID={{503B35CA-D053-4D7D-966C-E0B51E7D4973}
AppName=MidiMapperX
AppVersion=2.0.0.0
AppPublisher=Schema Factor
AppPublisherURL=http://www.schemafactor.com/midimapperx
AppSupportURL=http://www.schemafactor.com/midimapperx
AppUpdatesURL=http://www.schemafactor.com/midimapperx
DefaultDirName=c:\Program Files (x86)\VstPlugins\MidiMapperX
DefaultGroupName=MidiMapperX
DisableProgramGroupPage=yes
OutputBaseFilename=setup
Compression=lzma/Max
SolidCompression=true
AppVerName=MidiMapperX 2.0.0.0
MinVersion=5.1.2600sp1
WizardImageFile=C:\Users\Leif\Documents\GitHub\MIDIMapperX\Binaries\32bit\Installer\image2.bmp
WizardImageStretch=false
ShowLanguageDialog=no

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"

[Files]
Source: C:\Users\Leif\Documents\GitHub\MIDIMapperX\Binaries\32bit\Jacobi.Vst.Core.dll; DestDir: {dotnet4032}; Flags: gacinstall; StrongAssemblyName: "Jacobi.Vst.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=fa678e13c1efc859"; 
Source: C:\Users\Leif\Documents\GitHub\MIDIMapperX\Binaries\32bit\Jacobi.Vst.Framework.dll; DestDir:  {dotnet4032}; Flags: gacinstall;    StrongAssemblyName: "Jacobi.Vst.Framework, Version=1.0.0.0, Culture=neutral, PublicKeyToken=fa678e13c1efc859"
Source: "C:\Users\Leif\Documents\GitHub\MIDIMapperX\Binaries\32bit\MidiMapperX.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\Leif\Documents\GitHub\MIDIMapperX\Binaries\32bit\MidiMapperX.net.vstdll"; DestDir: "{app}"; Flags: ignoreversion
; NOTE: Don't use "Flags: ignoreversion" on any shared system files

[Icons]
Name: "{group}\{cm:ProgramOnTheWeb,MidiMapperX}"; Filename: "http://www.schemafactor.com/midimapperx"
Name: "{group}\{cm:UninstallProgram,MidiMapperX}"; Filename: "{uninstallexe}"


[Messages]
FinishedLabel=Setup has finished installing [name] on your computer. %n%nPlease rescan your VST list within your DAW to use the plugin.
