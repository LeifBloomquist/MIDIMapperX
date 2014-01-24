namespace SchemaFactor.Vst.MidiMapperX
{
    using Jacobi.Vst.Core;
    using Jacobi.Vst.Framework;

    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

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

            bool thrudone = false;

            foreach (VstEvent evnt in inputEvents)
            {
                _plugin.eventCount++;

                // Skip non-MIDI Events
                if (evnt.EventType != VstEventTypes.MidiEvent)
                {
                    continue;
                }

                _plugin.midiCount++;

                // If set in options, keep the original event as well
                if (_plugin.Options.MidiThruAll)
                {
                    Events.Add(evnt);
                    thrudone = true;
                }

                // Don't do any more if we aren't running.
                if (_plugin.CurrentMode != Constants.Modes.RUN) continue;

                // Construct a MIDI event and act on it
                VstMidiEvent midiInputEvent = (VstMidiEvent)evnt;
                byte command = (byte)(midiInputEvent.Data[0] & 0xF0);
                byte channel = (byte)(midiInputEvent.Data[0] & 0x0F);
                byte note = midiInputEvent.Data[1];
                byte velocity = midiInputEvent.Data[2];

                MapNoteItem map = _plugin.NoteMaps[note];
                byte[] midiData = null;

                // Filter out everything except Note On/Note Off and CC events
                switch (command)
                {
                    case 0x90: // Note On
                        map.Triggered(Constants.MapTypes.ON);

                        if (map.isDefined(Constants.MapTypes.ON))
                        {
                            _plugin.hitCount++;
                            midiData = MapNoteItem.StringToBytes(map.OutputBytesStringOn, channel, velocity);                           
                        }
                        break;

                    case 0x80: // Note Off
                        map.Triggered(Constants.MapTypes.OFF);

                        if (map.isDefined(Constants.MapTypes.OFF))
                        {
                            _plugin.hitCount++;
                            midiData = MapNoteItem.StringToBytes(map.OutputBytesStringOff, channel, velocity);                           
                        }
                        break;

                    case 0xB0: // Continuous Controller
                        map.Triggered(Constants.MapTypes.CC);

                        if (map.isDefined(Constants.MapTypes.CC))
                        {
                            _plugin.hitCount++;
                            midiData = MapNoteItem.StringToBytes(map.OutputBytesStringCC, channel, velocity);                           
                        }
                        break;

                    default:
                        // Ignore everything else, but keep going below
                        break;
                }

                // Check that we got a result.  If not - no match.
                if (midiData == null)
                {
                    if (_plugin.Options.MidiThru)
                    {
                        // add original event, if not added already.
                        if (!thrudone)
                        {
                            Events.Add(evnt);
                        }
                    }
                    continue;
                }

                // In most cases, use VstMidiSysExEvent in place of VstMidiEvent, since this seems to allow arbitary bytes.      
                if (_plugin.Options.AlwaysSysEx)
                {
                    VstMidiSysExEvent mappedEvent = new VstMidiSysExEvent(midiInputEvent.DeltaFrames, midiData);
                    Events.Add(mappedEvent);
                }
                else  // Ugly!  Split message into three-byte chunks and send them all.
                {
                    List<byte[]> midichunks = new List<byte[]>();

                    for (int i = 0; i < midiData.Length; i += 3)
                    {
                        midichunks.Add(midiData.Skip(i).Take(3).ToArray());
                    }

                    foreach (byte[] midi in midichunks)
                    {
                        VstMidiEvent mappedEvent = new VstMidiEvent(midiInputEvent.DeltaFrames, midiInputEvent.NoteLength, midiInputEvent.NoteOffset, midi, midiInputEvent.Detune, midiInputEvent.NoteOffVelocity);
                        Events.Add(mappedEvent);
                    }
                }
            } // foreach
        } // Process
#endregion 
     
    }
}
