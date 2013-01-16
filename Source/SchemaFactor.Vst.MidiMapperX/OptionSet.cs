namespace SchemaFactor.Vst.MidiMapperX
{
    using System.Collections.ObjectModel;
    using System.Windows.Forms;

    /// <summary>
    /// Represents the various options that are settable.
    /// </summary>
    class OptionSet
    {
        public bool MidiThru { get; set; }
        public bool MidiThruAll { get; set; }
        public bool AlwaysSysEx { get; set; }
    }        
}
