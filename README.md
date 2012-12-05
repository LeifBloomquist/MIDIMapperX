MIDIMapperX
===========

The ultimate MIDI Mapping &amp; Translation VST plugin.  For FL Studio and other Windows DAW users.

![Screenshot](https://raw.github.com/LeifBloomquist/MIDIMapperX/master/Screenshots/MidiMapperX_V2.png)

*Please Note* Only the 32-bit version is properly working at this time.

Installation
------------
These instructions are targeted at FL Studio 10 users, as that's what I have.

You need:

1. Microsoft's .NET Framework 4.5   http://www.microsoft.com/en-us/download/details.aspx?id=30653  
2. Visual Studio 2008 Runtimes      http://www.microsoft.com/en-us/download/details.aspx?id=29
3. The MidiMapperX files            https://github.com/LeifBloomquist/MIDIMapperX/tree/master/Binaries/32bit

Install .NET 4.5 and the VS2008 runtimed, then copy the files under 32bit/ to your VST folder (i.e.  C:\Program Files (x86)\VstPlugins) and rescan within your DAW.

Please note that for FL Studio, I also had to put the file FL.exe.config (under Support/) in the same folder as FL.exe for it to work.  May be optional.


Credits
-------
This VST was developed using the excellent VST.NET Library from Jacobi Software (see http://vstnet.codeplex.com/).

In fact, the MidiMapper sample program included with VST.NET was used as the basis, so thany thanks to 'obiwanjacobi' from Jacobi Software.

License
-------
Please refer to the LICENSE files in both the root and Binaries directories.
