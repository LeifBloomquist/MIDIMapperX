namespace SchemaFactor.Vst.MidiMapperX
{
    using System;
    using System.IO;
    using System.Text;

    using Jacobi.Vst.Core;
    using Jacobi.Vst.Framework;
    using System.Windows.Forms;

    class PluginPersistence : IVstPluginPersistence
    {
        private Plugin _plugin;
        private Encoding _encoding = Encoding.ASCII;

        public PluginPersistence(Plugin plugin)
        {
            _plugin = plugin;
        }

        #region IVstPluginPersistence Members

        public bool CanLoadChunk(VstPatchChunkInfo chunkInfo)
        {
            return true;
        }

        public void ReadPrograms(Stream stream, VstProgramCollection programs)
        {
            BinaryReader reader = new BinaryReader(stream, _encoding);

            _plugin.NoteMap.Clear();
            int count = reader.ReadInt32();

            for (int n = 0; n < count; n++)
            {
                MapNoteItem item = new MapNoteItem();

                item.KeyName = reader.ReadString();
                item.TriggerNoteNumber = reader.ReadByte();
                item.OutputBytesStringOn = reader.ReadString();
                item.OutputBytesStringOff = reader.ReadString();

                _plugin.NoteMap.Add(item);
            }

            try  // In case the preset was written with an older version that didn't have all these options yet.
            {
                _plugin.Options.MidiThru = reader.ReadBoolean();
                _plugin.Options.MidiThruAll = reader.ReadBoolean();
                _plugin.Options.AlwaysSysEx = reader.ReadBoolean();                             
            }
            catch // all, i.e. (System.IO.EndOfStreamException e)
            {
                // Note: This catch block never seems to be reached, investigate (Low priority)
                MessageBox.Show("This map was created with an older version of the plugin.\n\nPlease check your options.");
            }            

            _plugin.presetsLoaded = true;
        }

        public void WritePrograms(Stream stream, VstProgramCollection programs)
        {
            BinaryWriter writer = new BinaryWriter(stream, _encoding);

            writer.Write(_plugin.NoteMap.Count);

            foreach (MapNoteItem item in _plugin.NoteMap)
            {
                writer.Write(item.KeyName);
                writer.Write(item.TriggerNoteNumber);
                writer.Write(item.OutputBytesStringOn);
                writer.Write(item.OutputBytesStringOff);
            }

            writer.Write(_plugin.Options.MidiThru);
            writer.Write(_plugin.Options.MidiThruAll);
            writer.Write(_plugin.Options.AlwaysSysEx);

            writer.Close();
        }

        #endregion
    }
}
