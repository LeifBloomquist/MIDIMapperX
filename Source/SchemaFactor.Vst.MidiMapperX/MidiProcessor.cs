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
        private Plugin _plugin;

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


        // Process the incoming VST events.  This is the core of the app right here.  !!!!
        public void Process(VstEventCollection inputEvents)
        {
            _plugin.callCount++;
            
            foreach (VstEvent evnt in inputEvents)
            {
                _plugin.eventCount++;

                // Skip non-MIDI Events
                if (evnt.EventType != VstEventTypes.MidiEvent) continue;

                _plugin.midiCount++;

                VstMidiEvent midiInputEvent = (VstMidiEvent)evnt;

                // Filter out everything except Note On/Note Off events
                byte midiCommand = (byte)(midiInputEvent.Data[0] & 0xF0);  
              
                if ((midiCommand == 0x90) || (midiCommand == 0x80))
                {                          
                    byte triggerNoteNum = midiInputEvent.Data[1];                  

                    if (_plugin.NoteMap.Contains(triggerNoteNum))
                    {
                        _plugin.hitCount++;

                        // If set in options, keep the original event
                        if (_plugin.Options.MidiThruAll)
                        {
                            Events.Add(evnt);
                        }

                        byte channel = (byte)(midiInputEvent.Data[0] & 0x0F);    
                        byte velocity = midiInputEvent.Data[2];

                        MapNoteItem item = _plugin.NoteMap[triggerNoteNum];                       

                        byte[] midiData = null;
                        if (midiCommand == 0x90)
                        {
                            midiData = MapNoteItem.StringToBytes(item.OutputBytesStringOn, channel, velocity);
                            item.TriggeredOn();
                        }
                        else if (midiCommand == 0x80)
                        {
                            midiData = MapNoteItem.StringToBytes(item.OutputBytesStringOff, channel, velocity);
                            item.TriggeredOff();
                        }
                        // else midiData remains null, which should never happen

                        // If OutputBytes was empty, ignore this event.
                        if (midiData == null) continue;
                        
                        // Trick: Use VstMidiSysExEvent in place of VstMidiEvent, since this seems to allow arbitary bytes.                        
                        VstMidiSysExEvent mappedEvent = new VstMidiSysExEvent(midiInputEvent.DeltaFrames, midiData);

                        Events.Add(mappedEvent);
                    }
                    else if (_plugin.Options.MidiThru)
                    {
                        // add original event
                        Events.Add(evnt);
                    }
                    // Otherwise ignore silently
                }
            }
        }

        #endregion      
    }
}
