namespace SchemaFactor.Vst.MidiMapperX
{
    using Jacobi.Vst.Core;
    using Jacobi.Vst.Framework;

    using System.Collections;
    using System.Collections.Generic;

    /// <summary>
    /// Implements the incoming Midi event handling for the plugin.
    /// </summary>
    class MidiProcessor : IVstMidiProcessor
    {
        private Plugin _plugin = null;

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        /// <param name="plugin">Must not be null.</param>
        public MidiProcessor(Plugin plugin)
        {
            _plugin = plugin;
            Events = new VstEventCollection();
        }

        /// <summary>
        /// Gets the midi inputEvents that should be processed in the current cycle.
        /// </summary>
        public VstEventCollection Events { get; private set; }

#region IVstMidiProcessor Members

        public int ChannelCount
        {
            get { return _plugin.ChannelCount; }
        }

        // Process the incoming VST events.  *** This is the core of the VST right here. ***
        public void Process(VstEventCollection inputEvents)
        {
            if (_plugin == null) return;

            _plugin.callCount++;

            foreach (VstEvent evnt in inputEvents)
            {
                _plugin.eventCount++;

                // Skip non-MIDI Events
                if (evnt.EventType != VstEventTypes.MidiEvent)
                {
                    continue;
                }

                _plugin.midiCount++;

                VstMidiEvent midiInputEvent = (VstMidiEvent)evnt;
                byte command = (byte)(midiInputEvent.Data[0] & 0xF0);
                byte channel = (byte)(midiInputEvent.Data[0] & 0x0F);
                byte trigger = midiInputEvent.Data[1];
                byte velocity = midiInputEvent.Data[2];

                // If set in options, keep the original event
                if (_plugin.Options.MidiThruAll)
                {
                    Events.Add(evnt);
                }

                MapNoteItem map = _plugin.NoteMaps[trigger];
                byte[] midiData = null;

                // Filter out everything except Note On/Note Off events
                switch (command)
                {
                    case 0x90: // Note On
                        map.TriggeredOn();

                        if (map.isDefined(true))
                        {
                            _plugin.hitCount++;
                            midiData = MapNoteItem.StringToBytes(map.OutputBytesStringOn, channel, velocity);
                           
                        }
                        break;

                    case 0x80: // Note Off
                        map.TriggeredOff();

                        if (map.isDefined(false))
                        {
                            _plugin.hitCount++;
                            midiData = MapNoteItem.StringToBytes(map.OutputBytesStringOff, channel, velocity);                           
                        }
                        break;

                    default:
                        // Do nothing
                        continue;
                }

                // Check that we got a sane result
                if (midiData == null) continue;

                // Trick: Use VstMidiSysExEvent in place of VstMidiEvent, since this seems to allow arbitary bytes.                        
                VstMidiSysExEvent mappedEvent = new VstMidiSysExEvent(midiInputEvent.DeltaFrames, midiData);
                Events.Add(mappedEvent);


                //if (_plugin.Options.MidiThru)
                //{
                //// add original event
                //Events.Add(evnt);
                //}
            } // foreach
        } // Process
#endregion 
     
    }
}
