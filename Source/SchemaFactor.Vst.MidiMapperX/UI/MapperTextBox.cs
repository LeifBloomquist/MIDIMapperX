using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SchemaFactor.Vst.MidiMapperX
{
    class MapperTextBox : TextBox
    {
        public static Font OCRFont = new Font("OCR A Extended", 10f);

        public MapperTextBox(int x, int y, int width, int height)
        {            
            this.Location = new System.Drawing.Point(x, y);
            this.Size = new System.Drawing.Size(width, height);
            this.Multiline = false;
            this.Font = OCRFont;
            this.BackColor = Color.Black;
            this.ForeColor = Color.White;
            this.BorderStyle = BorderStyle.FixedSingle;
            this.WordWrap = false;        
    
            this.KeyPress += MapperTextBox_KeyPress;

            ToolTip toolTip1 = new ToolTip();
            toolTip1.UseAnimation = true;
            toolTip1.IsBalloon = true;
            toolTip1.SetToolTip(this, "Enter bytes to send in hexadecimal in the form ## ## ##...\nUse N for Channel and VV for Velocity from original note.\nLeave blank to ignore Note On/Off events.");
        }
      
        public MapperTextBox(int x, int y, int width, int height, bool ro) : this(x, y+2, width, height)
        {
            this.ReadOnly = ro;
            this.BorderStyle = BorderStyle.None;
            this.TextAlign = HorizontalAlignment.Right;         
        }

        private void MapperTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            MessageBox.Show("Key pressed!");


            this.BackColor = Color.Black;

            // this will only allow valid hex values [0-9][a-f][A-F] to be entered. See ASCII table. 
            char c = e.KeyChar;
            if (c != '\b' && !((c <= 'f' && c >= 'a') || (c <= 'F' && c >= 'A') || (c >= '0' && c <= '9') || (c == ' ') || (c == 'n') || (c == 'v')))
            {
                e.Handled = true;
            }
        }


        public bool CheckValid()
        {
            // Get rid of extra whitespace
            this.Text = this.Text.Trim();

            // Parse the strings with dummy substitution values to verify they're OK.  Don't use 0 as it may mask weird input ('NN33', for example)
            try
            {
                MapNoteItem.StringToBytes(this.Text, 15, 255);
            }
            catch // All, assume parsing errors
            {
                this.BackColor = Color.Yellow;
                return false;
            }

            return true;
        }          
    }
}
