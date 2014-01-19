using System;
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
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            myTimer.Tick += TimerEventProcessor;

            // Sets the timer interval to 50 milliseconds.
            myTimer.Interval = 50;
            myTimer.Start();
        }


        private void InitializeGrid()
        {
            int XNudge = MainPanel.Location.X + 3;
            int YSpacing = MapperTextBox.OCRFont.Height + 6;
            int YSize = 16;

            for (int note = 0; note < Constants.MAXNOTES; note++)
            {
                int Yloc = 2 + note * YSpacing;

                // Note Number                
                MapperTextBox tb = new MapperTextBox(NoteNumber.Location.X - XNudge - 10, Yloc, NoteNumber.Size.Width, YSize, true);                                
                tb.Text = note.ToString("000");
                MapNums[note] = tb;
                MainPanel.Controls.Add(tb);

                // Map Name
                tb = new MapperTextBox(MapName.Location.X - XNudge, Yloc, MapName.Size.Width, YSize);
                tb.Text = "Undefined " + note;
                MapNames[note] = tb;
                MainPanel.Controls.Add(tb);
        
                // Note On
                tb = new MapperTextBox(MIDIDataOn.Location.X - XNudge, Yloc, MIDIDataOn.Size.Width, YSize);
                OnMaps[note] = tb;
                MainPanel.Controls.Add(tb);

                // Note Off
                tb = new MapperTextBox(MIDIDataOff.Location.X - XNudge, Yloc, MIDIDataOff.Size.Width, YSize);
                OffMaps[note] = tb;
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
            }
        }

        // This is the method to run when the timer is raised.
        // Animates the background of the textbox items.
        private void TimerEventProcessor(Object myObject, EventArgs myEventArgs)
        {
            if (_plugin == null) return;
            if ((!this.Created) || (_plugin.NoteMaps == null)) return; 

            for (int note = 0; note < Constants.MAXNOTES; note++)
            {
                MapNoteItem map = _plugin.NoteMaps[note];

                if (map == null) return;

                int green = (int)(map.TriggerPulseOn * 255);
                int red = (int)(map.TriggerPulseOff * 255);

                MapNums[note].BackColor = Color.FromArgb(red, green, 0);
                OnMaps[note].BackColor = Color.FromArgb(0, green, 0);
                OffMaps[note].BackColor = Color.FromArgb(red, 0, 0);

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
            MessageBox.Show(_plugin.ProductInfo.Vendor + "\n\n" +
                    _plugin.ProductInfo.Product + "\n\n" +
                    "Version: " + _plugin.ProductInfo.FormattedVersion + " BETA 2",
                    "Schema Factor MIDIMapperX");
        }

        // "Options" Button
        private void OptionsButton_Click(object sender, EventArgs e)
        {
            OptionsUI dlg = new OptionsUI(_plugin.Options );

            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                _plugin.Options = dlg.TempOptionSet;
            }
        }
    }
}
