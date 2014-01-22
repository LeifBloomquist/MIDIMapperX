namespace SchemaFactor.Vst.MidiMapperX
{
    using System.Collections.ObjectModel;
    using System.Windows.Forms;

    using SchemaFactor.Vst.MidiMapperX;

    /// <summary>
    /// Represents one note mapping.
    /// </summary>
    public class MapNoteItem
    {
      

        /// <summary>
        /// Gets or sets a readable name for this mapping item.
        /// </summary>
        public string KeyName { get; set; }

        /// <summary>
        /// Stores the strings of MIDI hex bytes that are sent to the output when this item is triggered.  Could use C# Indexers here, but this is simpler.
        /// </summary>
        public string OutputBytesStringOn { get; set; }
        public string OutputBytesStringOff { get; set; }
        public string OutputBytesStringCC { get; set; }      

        /// <summary>
        /// Constructor.
        /// </summary>
        public MapNoteItem()
        {
            KeyName = "Uninitialized";
            OutputBytesStringOn = "";
            OutputBytesStringOff = "";
            OutputBytesStringCC = "";
        }

        /// <summary>
        /// Determine if this mapping has been defined.
        /// </summary>
        /// <param name="type">Set to type to check</param>
        /// <returns>True is defined (non-empty)</returns>
        public bool isDefined(Constants.MapTypes type)
        {
            switch (type)
            {
                case Constants.MapTypes.ON:
                {
                    if (OutputBytesStringOn == null)
                    {
                        return false;
                    }

                    if (OutputBytesStringOn.Equals(""))
                    {
                        return false;
                    }
                }
                break;

                case Constants.MapTypes.OFF:
                {
                    if (OutputBytesStringOff == null)
                    {
                        return false;
                    }

                    if (OutputBytesStringOff.Equals(""))
                    {
                        return false;
                    }
                }
                break;

                case Constants.MapTypes.CC:
                {
                    if (OutputBytesStringCC == null)
                    {
                        return false;
                    }

                    if (OutputBytesStringCC.Equals(""))
                    {
                        return false;
                    }
                }
                break;

                default:
                    return false;
            }

            return true;
        }



        /// <summary>
        /// Gets the value for the "pulse" effect, 1.0 to 0.0 ON
        /// </summary>
        public double TriggerPulseOn { get; private set; }
        public double TriggerPulseOff { get; private set; }
        public double TriggerPulseCC { get; private set; }

        public void Triggered(Constants.MapTypes type)
        {
            switch (type)
            {
                case Constants.MapTypes.ON:
                    TriggerPulseOn  = 1.0;
                    break;

                case Constants.MapTypes.OFF:
                    TriggerPulseOff = 1.0;
                    break;

                case Constants.MapTypes.CC:
                    TriggerPulseCC = 1.0;
                    break;
            }
            return;
        }
  
        public void Pulse()
        {           
            TriggerPulseOn  *= 0.9;
            TriggerPulseOff *= 0.6;
            TriggerPulseCC  *= 0.6;
        }   

        public void ClearPulse()
        {           
            TriggerPulseOn  = 0;
            TriggerPulseOff = 0;
            TriggerPulseCC  = 0;
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
            lastOutputString = "";

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
}
