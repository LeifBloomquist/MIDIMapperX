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
            if (_plugin == null) return;

            bool headerok = false;
            BinaryReader reader = new BinaryReader(stream, _encoding);

            // Header
            try
            {
                String header = reader.ReadString();
                if (header.Equals(Constants.MIDIMAPPERX))
                {
                    headerok = true;
                }
            }
            catch (Exception)
            {
                ;
            }

            if (!headerok)  // Version 1?
            {
                ReadOldPreset(reader);
                return;
            }

            // Version Number
            int version = reader.ReadInt32();

            if (version < Constants.VERSION)
            {
                // TODO: Special handling here in future.
            }

            // Number of maps 
            int count = reader.ReadInt32();

            if (count != Constants.MAXNOTES)
            {
                MessageBox.Show("Invalid number of maps stored: " + count, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Each map
            for (int n = 0; n < count; n++)
            {
                MapNoteItem map = _plugin.NoteMaps[n];
                map.KeyName = reader.ReadString();
                map.OutputBytesStringOn = reader.ReadString();
                map.OutputBytesStringOff = reader.ReadString();
            }

            // Options
            try  // In case the preset was written with an older version that didn't have all these options yet.
            {
                _plugin.Options.MidiThru = reader.ReadBoolean();
                _plugin.Options.MidiThruAll = reader.ReadBoolean();
                _plugin.Options.AlwaysSysEx = reader.ReadBoolean();
            }
            catch // all, i.e. (System.IO.EndOfStreamException e)
            {
                // Note: This catch block never seems to be reached, investigate (Low priority)
                MessageBox.Show("No Options block in preset", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            // CCs
            for (int n = 0; n < count; n++)
            {
                MapNoteItem map = _plugin.NoteMaps[n];
                map.OutputBytesStringCC = reader.ReadString();
            }

            _plugin.presetsLoaded = true;
        }

        public void WritePrograms(Stream stream, VstProgramCollection programs)
        {
            if (_plugin == null) return;

            BinaryWriter writer = new BinaryWriter(stream, _encoding);

            // Header
            writer.Write(Constants.MIDIMAPPERX);

            // Version Number
            writer.Write(_plugin.ProductInfo.Version);

            // Number of maps (always MAXNOTES in this version, was flexible in version 1)
            writer.Write(Constants.MAXNOTES);

            // Each map
            for (int note = 0; note < Constants.MAXNOTES; note++)
            {
                MapNoteItem map = _plugin.NoteMaps[note];
                writer.Write(map.KeyName);
                writer.Write(map.OutputBytesStringOn);
                writer.Write(map.OutputBytesStringOff);
            }

            // Options
            writer.Write(_plugin.Options.MidiThru);
            writer.Write(_plugin.Options.MidiThruAll);
            writer.Write(_plugin.Options.AlwaysSysEx);

            // CCs
            for (int note = 0; note < Constants.MAXNOTES; note++)
            {
                MapNoteItem map = _plugin.NoteMaps[note];
                writer.Write(map.OutputBytesStringCC);
            }

            writer.Close();
        }

#endregion

        // Works!
        private void ReadOldPreset(BinaryReader reader)
        {
            _plugin.ResetMaps();

            reader.BaseStream.Position = 0;
            reader.BaseStream.Seek(0, SeekOrigin.Begin);

            int count = reader.ReadInt32();

            for (int n = 0; n < count; n++)
            {
                MapNoteItem item = new MapNoteItem();

                item.KeyName = reader.ReadString();
                int trigger = reader.ReadByte();
                item.OutputBytesStringOn = reader.ReadString();
                item.OutputBytesStringOff = reader.ReadString();

                _plugin.NoteMaps[trigger] = item;
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
                ;
            }

            _plugin.olderpresetswarning = true;
            _plugin.presetsLoaded = true;
        }
    }
}
