namespace SchemaFactor.Vst.MidiMapperX
{
    using System.Collections.ObjectModel;
    using System.Windows.Forms;

    /// <summary>
    /// Represents one note mapping.
    /// </summary>
    class MapNoteItem
    {
        /// <summary>
        /// Gets or sets a readable name for this mapping item.
        /// </summary>
        public string KeyName { get; set; }

        /// <summary>
        /// Gets or sets the note number that triggers this mapping item.
        /// </summary>
        public byte TriggerNoteNumber { get; set; }

        /// <summary>
        /// Stores the strings of MIDI hex bytes that are sent to the output when this item is triggered.  Could use C# Indexers here, but this is simpler.
        /// </summary>
        public string OutputBytesStringOn { get; set; }
        public string OutputBytesStringOff { get; set; }

        /// <summary>
        /// Gets the value for the "pulse" effect, 1.0 to 0.0 ON
        /// </summary>
        public double TriggerPulseOn { get; set; }

        /// <summary>
        /// Gets the value for the "pulse" effect, 1.0 to 0.0 OFF
        /// </summary>
        public double TriggerPulseOff { get; private set; }

        public void TriggeredOn()
        {
            TriggerPulseOn  = 1.0;
            TriggerPulseOff = 0.0;
        }

        public void TriggeredOff()
        {
            TriggerPulseOff = 1.0;
            TriggerPulseOn  = 0.0;
        } 
  
        public void Pulse()
        {
            TriggerPulseOff *= 0.8;
            TriggerPulseOn  *= 0.7;
        }   

        /// <summary>
        /// Stores the result of the last conversion, for debugging.
        /// </summary>
        public static string lastOutputString { get; private set; }

        /// <summary>
        /// Static member used to convert the hex strings into bytes.  Used by the mapping code, as well as the entry dialog box for validation.
        /// </summary>
        public static byte[] StringToBytes(string OutputBytesString, byte channel, byte velocity)
        {
            // Null string case - Return null
            if (OutputBytesString == null) return null;

            // Empty string case - Return null
            if (OutputBytesString.Equals("")) return null;

            // Limit channel
            channel = (byte)(channel & 0x0F);

            // Temporary array since BitConverter works on arrays.  
            byte[] temp = new byte[2];
            temp[0] = channel;
            temp[1] = velocity;

            // Replace N with channel and VV with velocity (uppercase is forced by dialog box)
            OutputBytesString = OutputBytesString.Replace(  "N", System.BitConverter.ToString(temp, 0, 1).Substring(1,1) );
            OutputBytesString = OutputBytesString.Replace( "VV", System.BitConverter.ToString(temp, 1, 1) );

            // Store result for debugging
            lastOutputString = OutputBytesString;            

            // Update byte representation
            string[] array_hex = OutputBytesString.Split(' ');
            byte[] array_bytes = new byte[array_hex.Length];

            for (int i = 0; i < array_hex.Length; i++)
            {
                // This could potentially throw a parsing exception.  Ignore here so it bubbles up to caller.
                array_bytes[i] = System.Convert.ToByte(array_hex[i], 16);
            }
            return array_bytes;               
        }      
    }

    /// <summary>
    /// Manages a list of <see cref="MapNoteItem"/> instances.
    /// </summary>
    class MapNoteItemList : KeyedCollection<byte, MapNoteItem>
    {
        // This parameterless constructor calls the base class constructor 
        // that specifies a dictionary threshold of -1 to disable creation of the dictionary.
        public MapNoteItemList() : base(null, -1) { } 

        /// <summary>
        /// Returns <see cref="MapNoteItem.TriggerNoteNumber"/>.
        /// </summary>
        /// <param name="item">Must not be null.</param>
        /// <returns>Returns the key for the <paramref name="item"/>.</returns>
        protected override byte GetKeyForItem(MapNoteItem item)
        {
            return item.TriggerNoteNumber;
        }
    }
}
