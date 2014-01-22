﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SchemaFactor.Vst.MidiMapperX
{
    /// GUI Test 
    partial class MainWindow : DoubleBufferedUserControl
    {        
        private Plugin _plugin = null;

        Timer myTimer = new Timer();

        MapperTextBox[] MapNums = new MapperTextBox[Constants.MAXNOTES];
        MapperTextBox[] MapNames = new MapperTextBox[Constants.MAXNOTES];
        MapperTextBox[] OnMaps = new MapperTextBox[Constants.MAXNOTES];
        MapperTextBox[] OffMaps = new MapperTextBox[Constants.MAXNOTES];
        MapperTextBox[] CCMaps = new MapperTextBox[Constants.MAXNOTES];

        /// <summary>
        /// Main Form Constructor.  Must be parameterless to avoid error CS0310.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            InitializeGrid();
            FillList();

            typeof(Panel).InvokeMember("DoubleBuffered", BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic, null, MainPanel, new object[] { true });
        }

        public void setPlugin(Plugin plugin)
        {
            _plugin = plugin;            
            FillList();
            SwitchToRunMode();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            // Sets the timer interval to 50 milliseconds.
            myTimer.Tick += TimerEventProcessor;            
            myTimer.Interval = 50;
        }

        private void InitializeGrid()
        {
            int XNudge = MainPanel.Location.X + 1;
            int YSpacing = MapperTextBox.OCRFont.Height + 6;
            int YSize = 16;

            for (int note = 0; note < Constants.MAXNOTES; note++)
            {
                int Yloc = 2 + note * YSpacing;

                // Note Number                
                MapperTextBox tb = new MapperTextBox(NoteNumber.Location.X - XNudge - 10, Yloc, NoteNumber.Size.Width, YSize, "Note # that triggers this map.", true);                                
                tb.Text = note.ToString("000");
                MapNums[note] = tb;
                MainPanel.Controls.Add(tb);

                // Map Name
                tb = new MapperTextBox(MapName.Location.X - XNudge, Yloc, MapName.Size.Width, YSize, "Enter a name for this mapping.");
                tb.Text = "Undefined " + note;                
                MapNames[note] = tb;
                tb.nocheck = true;
                MainPanel.Controls.Add(tb);
        
                // Note On
                tb = new MapperTextBox(MIDIDataOn.Location.X - XNudge, Yloc, MIDIDataOn.Size.Width, YSize, "Enter bytes to send in hexadecimal in the form ## ## ##...\nUse N for Channel and VV for Velocity from original note.\nLeave blank to ignore Note On events.");
                tb.CharacterCasing = CharacterCasing.Upper;
                OnMaps[note] = tb;
                MainPanel.Controls.Add(tb);

                // Note Off
                tb = new MapperTextBox(MIDIDataOff.Location.X - XNudge, Yloc, MIDIDataOff.Size.Width, YSize, "Enter bytes to send in hexadecimal in the form ## ## ##...\nUse N for Channel and VV for Velocity from original note.\nLeave blank to ignore Note Off events.");
                tb.CharacterCasing = CharacterCasing.Upper;
                OffMaps[note] = tb;
                MainPanel.Controls.Add(tb);

                // New!  CCs
                tb = new MapperTextBox(MIDIDataCC.Location.X - XNudge, Yloc, MIDIDataCC.Size.Width, YSize, "Enter bytes to send in hexadecimal in the form ## ## ##...\nUse N for Channel and VV for Value from original CC.\nLeave blank to ignore CC events.");
                tb.CharacterCasing = CharacterCasing.Upper;
                CCMaps[note] = tb;
                MainPanel.Controls.Add(tb);
            }
        }

        private void FillList()
        {
           if (_plugin == null) return;
           if ((!this.Created) || (_plugin.NoteMaps == null)) return;    

            for (int note = 0; note < Constants.MAXNOTES; note++)
            {
                MapNoteItem map = _plugin.NoteMaps[note];

                if (map == null) return;

                MapNames[note].Text = map.KeyName;
                OnMaps[note].Text = map.OutputBytesStringOn;
                OffMaps[note].Text = map.OutputBytesStringOff;
                CCMaps[note].Text = map.OutputBytesStringCC;
            }
        }

        // This is the method to run when the timer is raised.
        // Animates the background of the textbox items.
        private void TimerEventProcessor(Object myObject, EventArgs myEventArgs)
        {
            if (_plugin == null) return;
            if ((!this.Created) || (_plugin.NoteMaps == null)) return;

            if (_plugin.CurrentMode != Constants.Modes.RUN) return;

            for (int note = 0; note < Constants.MAXNOTES; note++)
            {
                MapNoteItem map = _plugin.NoteMaps[note];

                if (map == null) return;

                int green = (int)(map.TriggerPulseOn * 255);
                int red = (int)(map.TriggerPulseOff * 255);
                int blue = (int)(map.TriggerPulseCC * 255);

                MapNums[note].BackColor = Color.FromArgb(red, green, 0);
                OnMaps[note].BackColor = Color.FromArgb(0, green, 0);
                OffMaps[note].BackColor = Color.FromArgb(red, 0, 0);
                CCMaps[note].BackColor = Color.FromArgb(0, 0, blue);

                map.Pulse();
            }
        }

        /// <summary>
        /// Updates the UI
        /// </summary>
        public void ProcessIdle()
        {
            if (_plugin == null) return;

            _plugin.idleCount++;          

            // Act on the presets loaded flag.
            if (_plugin.presetsLoaded == true)
            {
                FillList();
                _plugin.presetsLoaded = false;
            }

            // Debug info
            if (DebugLabel.Visible)
            {
                DebugLabel.Text = "Idle:   " + _plugin.idleCount + "\n" +
                                  "Calls:  " + _plugin.callCount + "\n" +
                                  "Events: " + _plugin.eventCount + "\n" +
                                  "MIDI:   " + _plugin.midiCount + "\n" +
                                  "Hits:   " + _plugin.hitCount + "\n" +
                                  "Last Output: [" + MapNoteItem.lastOutputString + "]";
            }
        }

        // "About" Button
        private void AboutButton_Click(object sender, EventArgs e)
        {
            if (_plugin == null) return;

            AboutButton.ForeColor = Color.White;

            MessageBox.Show(_plugin.ProductInfo.Vendor + "\n\n" +
                    _plugin.ProductInfo.Product + "\n\n" +
                    "Version: " + _plugin.ProductInfo.FormattedVersion + " BETA 2",
                    "Schema Factor MIDIMapperX");

            AboutButton.ForeColor = Color.Black;
        }


        // "Options" Button
        private void OptionsButton_Click(object sender, EventArgs e)
        {
            if (_plugin == null) return;

            OptionsUI dlg = new OptionsUI(_plugin.Options);
            OptionsButton.ForeColor = Color.White;

            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                _plugin.Options = dlg.TempOptionSet;
            }
            OptionsButton.ForeColor = Color.Black;
        }

        /// <summary>
        /// Check all map boxes for validity, and parse them into the current memory map if so.
        /// </summary>
        /// <returns></returns>
        private bool ParseMaps()
        {
            if (_plugin == null)  // Special case, only at startup
            {
                return true;
            }

            bool pass = true;

            for (int note = 0; note < Constants.MAXNOTES; note++)
            {
                if (!OnMaps[note].CheckValid())
                {
                    pass = false;
                }

                if (!OffMaps[note].CheckValid())
                {
                    pass = false;
                }

                if (!CCMaps[note].CheckValid())
                {
                    pass = false;
                }                
            }

            // !!!! FLAW with this approach: Maps are only saved to memory if Run is pressed!

            if (pass)
            {
                for (int note = 0; note < Constants.MAXNOTES; note++)
                {
                    _plugin.NoteMaps[note].KeyName = MapNames[note].Text;
                    _plugin.NoteMaps[note].OutputBytesStringOn = OnMaps[note].Text;
                    _plugin.NoteMaps[note].OutputBytesStringOff = OffMaps[note].Text;
                    _plugin.NoteMaps[note].OutputBytesStringCC = CCMaps[note].Text;                    
                }
            }
            else
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Switch to Run mode.
        /// </summary>
        private bool SwitchToRunMode()
        {
            if (_plugin == null) return true;

            if (!ParseMaps())
            {
                return false;
            }

            _plugin.CurrentMode = Constants.Modes.RUN;

            // Set edit boxes read-only            
            for (int note = 0; note < Constants.MAXNOTES; note++)
            {
                MapNames[note].ReadOnly = true;
                OnMaps[note].ReadOnly = true;
                OffMaps[note].ReadOnly = true;
                CCMaps[note].ReadOnly = true;
            }

            RunModeButton.ForeColor = Color.White;
            EditModeButton.ForeColor = Color.Black;
            myTimer.Start();

            return true;
        }

        /// <summary>
        /// Switch to Edit mode.
        /// </summary>
        private void SwitchToEditMode()
        {
            if (_plugin == null) return;

            _plugin.CurrentMode = Constants.Modes.EDIT;

            RunModeButton.ForeColor = Color.Black;
            EditModeButton.ForeColor = Color.White;
            myTimer.Stop();

            // Set edit boxes editable
            for (int note = 0; note < Constants.MAXNOTES; note++)
            {
                MapNames[note].ReadOnly = false;
                OnMaps[note].ReadOnly = false;
                OffMaps[note].ReadOnly = false;
                CCMaps[note].ReadOnly = false;

                _plugin.NoteMaps[note].ClearPulse();
            }
        }

        private void Debug_DoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                DebugLabel.Visible = !DebugLabel.Visible;
            }

        }

        private void RunModeButton_Click(object sender, EventArgs e)
        {
            if (SwitchToRunMode())
            {
                errorProvider1.SetError(RunModeButton, string.Empty);
            }
            else
            {
                errorProvider1.SetError(RunModeButton, "Can't run: Errors exist in your mappings!");    
            }
        }

        private void EditModeButton_Click(object sender, EventArgs e)
        {
            SwitchToEditMode();
        }
    }
}
