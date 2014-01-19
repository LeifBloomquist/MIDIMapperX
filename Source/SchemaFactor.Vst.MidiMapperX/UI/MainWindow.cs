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
        private Plugin _plugin;    

        Random generator = new Random();
        Timer myTimer = new Timer();

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
            int XNudge = MainPanel.Location.X;
            int YSpacing = MapperTextBox.OCRFont.Height + 6;
            int YSize = 16;

            for (int note = 0; note <= 127; note++)
            {
                int Yloc = 2+ note * YSpacing;

                // Note Number                
                MapperTextBox tb = new MapperTextBox(NoteNumber.Location.X - XNudge - 10, Yloc, NoteNumber.Size.Width, YSize, true);                
                MainPanel.Controls.Add(tb);
                tb.Text = note.ToString("000");               

                // Map Name
                tb = new MapperTextBox(MapName.Location.X - XNudge, Yloc, MapName.Size.Width, YSize);                
                MainPanel.Controls.Add(tb);
                tb.Text = "Note Map " + note;
        
                // Note On
                tb = new MapperTextBox(MIDIDataOn.Location.X - XNudge, Yloc, MIDIDataOn.Size.Width, YSize);
                MainPanel.Controls.Add(tb);

                // Note Off
                tb = new MapperTextBox(MIDIDataOff.Location.X - XNudge, Yloc, MIDIDataOff.Size.Width, YSize);
                MainPanel.Controls.Add(tb);
            }
        }

        // This is the method to run when the timer is raised.
        // Animates the background of the Listview items.
        // Note that to avoid flicker, we use a derived BufferdListview, and FL users must use Bridged mode.
        private void TimerEventProcessor(Object myObject, EventArgs myEventArgs)
        {
            foreach (MapperTextBox mtb in MainPanel.Controls)
            {
                //byte noteNo = Byte.Parse(item.Name);

                int green = (int)(generator.NextDouble()*50f);   // was 255
                int red   = 0;

                mtb.BackColor = Color.FromArgb(red, green, 0);
            }


            foreach (MapperTextBox mtb in MainPanel.Controls)            
            {
                int noteNo = item.Index;

                int green = (int)(_plugin.NoteMaps[noteNo].TriggerPulseOn * 255);
                int red = (int)(_plugin.NoteMaps[noteNo].TriggerPulseOff * 255);

                item.SubItems[0].BackColor = Color.FromArgb(red, green, 0);
                _plugin.NoteMaps[noteNo].Pulse();
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
                //FillList();
                _plugin.presetsLoaded = false;
            }

 /*           // Debug info
            if (DebugLabel.Visible)
            {
                DebugLabel.Text = "Idle:   " + _plugin.idleCount + "\n" +
                                  "Calls:  " + _plugin.callCount + "\n" +
                                  "Events: " + _plugin.eventCount + "\n" +
                                  "MIDI:   " + _plugin.midiCount + "\n" +
                                  "Hits:   " + _plugin.hitCount + "\n" +
                                  "Last Output: [" + MapNoteItem.lastOutputString + "]";
            }
  */
        }

        private void AboutButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show(_plugin.ProductInfo.Vendor + "\n\n" +
                    _plugin.ProductInfo.Product + "\n\n" +
                    "Version: " + _plugin.ProductInfo.FormattedVersion + " BETA 2",
                    "Schema Factor MIDIMapperX");
        }
    }
}
