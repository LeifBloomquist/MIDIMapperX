using System.Collections.ObjectModel;
using System.Windows.Forms;

#pragma warning disable 1591

namespace SchemaFactor.Vst.MidiMapperX
{
    /// <summary>
    /// Represents the various options that are settable.
    /// </summary>
    public class OptionSet
    {
        public bool MidiThru { get; set; }
        public bool MidiThruAll { get; set; }
        public bool AlwaysSysEx { get; set; }
    }        
}

#pragma warning restore 1591