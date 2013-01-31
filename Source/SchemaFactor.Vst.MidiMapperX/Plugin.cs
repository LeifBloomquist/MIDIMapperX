namespace SchemaFactor.Vst.MidiMapperX
{
    using Jacobi.Vst.Core;
    using Jacobi.Vst.Framework;
    using Jacobi.Vst.Framework.Common;
    using Jacobi.Vst.Framework.Plugin;
    using System;

    /// <summary>
    /// The Plugin root class that implements the interface manager and the plugin midi source.
    /// </summary>
    class Plugin : VstPluginWithInterfaceManagerBase, IVstPluginMidiSource
    {
        public long callCount = 0;
        public long eventCount = 0;
        public long midiCount = 0;
        public long hitCount = 0;

        public bool presetsLoaded = false;  // This is a flag from the PluginPersistence Class to the GUI to notify it when presets were (re)loaded.

        /// <summary>
        /// Gets or sets the options set.
        /// </summary>
        public OptionSet Options { get; set; }

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public Plugin()
            : base("MIDIMapperX", new VstProductInfo("MIDIMapperX", "Leif Bloomquist 2013 / Jacobi Software 2012", 1005),
                VstPluginCategory.Synth, VstPluginCapabilities.NoSoundInStop, 0, 0x323)
        {
            NoteMap = new MapNoteItemList();
            Options = new OptionSet();   
        }

        /// <summary>
        /// Creates a default instance and reuses that for all threads.
        /// </summary>
        /// <param name="instance">A reference to the default instance or null.</param>
        /// <returns>Returns the default instance.</returns>
        protected override IVstPluginAudioProcessor CreateAudioProcessor(IVstPluginAudioProcessor instance)
        {
            if (instance == null) return new AudioProcessor(this);

            return instance;
        }

        /// <summary>
        /// Creates a default instance and reuses that for all threads.
        /// </summary>
        /// <param name="instance">A reference to the default instance or null.</param>
        /// <returns>Returns the default instance.</returns>
        protected override IVstPluginEditor CreateEditor(IVstPluginEditor instance)
        {
            if (instance == null) return new PluginEditor(this);

            return instance;
        }

        /// <summary>
        /// Creates a default instance and reuses that for all threads.
        /// </summary>
        /// <param name="instance">A reference to the default instance or null.</param>
        /// <returns>Returns the default instance.</returns>
        protected override IVstMidiProcessor CreateMidiProcessor(IVstMidiProcessor instance)
        {
            if (instance == null) return new MidiProcessor(this);

            return instance;
        }

        /// <summary>
        /// Creates a default instance and reuses that for all threads.
        /// </summary>
        /// <param name="instance">A reference to the default instance or null.</param>
        /// <returns>Returns the default instance.</returns>
        protected override IVstPluginPersistence CreatePersistence(IVstPluginPersistence instance)
        {
            if (instance == null) return new PluginPersistence(this);

            return instance;
        }

        /// <summary>
        /// Always returns <b>this</b>.
        /// </summary>
        /// <param name="instance">A reference to the default instance or null.</param>
        /// <returns>Returns the default instance <b>this</b>.</returns>
        protected override IVstPluginMidiSource CreateMidiSource(IVstPluginMidiSource instance)
        {
            return this;
        }

        #region IVstPluginMidiSource Members

        /// <summary>
        /// Returns the channel count as reported by the host
        /// </summary>
        public int ChannelCount
        {
            get
            {
                IVstMidiProcessor midiProcessor = null;
                
                if(Host != null)
                {
                    midiProcessor = Host.GetInstance<IVstMidiProcessor>();
                }

                if (midiProcessor != null)
                {
                    return midiProcessor.ChannelCount;
                }

                return 0;
            }
        }

        #endregion

        /// <summary>
        /// Gets the map where all the note map items are stored.
        /// </summary>
        public MapNoteItemList NoteMap { get; private set; }

    }
}
