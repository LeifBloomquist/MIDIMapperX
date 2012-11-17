using System;
using System.Windows.Forms;

namespace SchemaFactor.Vst.MidiMapperX
{
    /// <summary>
    /// A form that allows the user to edit the details of a note map item.
    /// </summary>
    partial class MapNoteDetailsUI : Form
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public MapNoteDetailsUI(MapNoteItem myMapNoteitem)
        {
            TempMapNoteItem = myMapNoteitem;
            InitializeComponent();
        }

        /// <summary>
        /// Gets or sets the temporary note map item that is being edited in the form.
        /// </summary>
        public MapNoteItem TempMapNoteItem { get; private set; }

        private void EntityToForm()
        {
            this.KeyNameTxt.Text = TempMapNoteItem.KeyName;
            this.TriggerNoteNoTxt.Value = TempMapNoteItem.TriggerNoteNumber;
            this.MIDIBytesOnTxt.Text = TempMapNoteItem.OutputBytesStringOn;
            this.MIDIBytesOffTxt.Text = TempMapNoteItem.OutputBytesStringOff;
        }

        private void FormToEntity()
        {
            TempMapNoteItem.KeyName = this.KeyNameTxt.Text;
            TempMapNoteItem.TriggerNoteNumber = (byte)this.TriggerNoteNoTxt.Value;
            TempMapNoteItem.OutputBytesStringOn = this.MIDIBytesOnTxt.Text;
            TempMapNoteItem.OutputBytesStringOff = this.MIDIBytesOffTxt.Text;
        }

        private void MapNoteDetails_Load(object sender, EventArgs e)
        {
            EntityToForm();
            ToolTip toolTip1 = new ToolTip();      
            toolTip1.UseAnimation = true;
            toolTip1.IsBalloon = true;
            toolTip1.SetToolTip(MIDIBytesOnTxt,  "Enter bytes to send in hexadecimal in the form ## ## ##...\nUse N for Channel and VV for Velocity from original note.\nLeave blank to ignore Note On events.");
            toolTip1.SetToolTip(MIDIBytesOffTxt, "Enter bytes to send in hexadecimal in the form ## ## ##...\nUse N for Channel and VV for Velocity from original note.\nLeave blank to ignore Note Off events."); 
        }

        private void MapNoteDetails_FormClosed(object sender, FormClosedEventArgs e)
        {
            FormToEntity();   // Assume other validations have passed before reaching here
        }

        // This is called for keypressesd on both TextBoxes
        private void MIDIBytesTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            ((TextBox)sender).BackColor = System.Drawing.SystemColors.Window;

            // this will only allow valid hex values [0-9][a-f][A-F] to be entered. See ASCII table. 
            char c = e.KeyChar;
            if (c != '\b' && !((c <= 'f' && c >= 'a') || (c <= 'F' && c >= 'A') || (c >= '0' && c <= '9') || (c == ' ') || (c == 'n') || (c =='v') ))
            {                
                e.Handled = true;
            }
        }
   
        private void MapNoteDetailsUI_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
            {
                FormToEntity();

                // Parse the strings with dummy substitution values to verify they're OK.  Don't use 0 as it may mask weird input ('NN33', for example)
                try
                {                              
                    MapNoteItem.StringToBytes(MIDIBytesOnTxt.Text, 15, 255);
                }
                catch // All, assume parsing errors
                {
                    this.MIDIBytesOnTxt.BackColor = System.Drawing.Color.Yellow;
                    e.Cancel = true;
                }
          
                try
                {
                    MapNoteItem.StringToBytes(MIDIBytesOffTxt.Text, 15, 255);
                }
                catch // All, assume parsing errors
                {
                    this.MIDIBytesOffTxt.BackColor = System.Drawing.Color.Yellow;
                    e.Cancel = true;
                }
            }
        }
    }
}
