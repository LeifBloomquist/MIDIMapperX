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
    /// <summary>
    /// My derivation of TextBox with customizations for the VST.
    /// </summary>
    public class MapperTextBox : TextBox
    {
        private KeysConverter kc = new KeysConverter();

        /// <summary>
        /// Flag to indicate no checking is to be done on this instance (i.e. for names)
        /// </summary>
        public bool nocheck { get; set; }

        /// <summary>
        /// Flag to indicate that the value has been changed.  (Reset in parent control after parsing)
        /// </summary>
        public bool Changed { get; set; }

        /// <summary>
        /// The dedault font.
        /// </summary>
        public static Font OCRFont = new Font("OCR A Extended", 10f);

        public MapperTextBox(int x, int y, int width, int height, String tooltip)
        {            
            this.Location = new System.Drawing.Point(x, y);
            this.Size = new System.Drawing.Size(width, height);
            this.Multiline = false;
            this.Font = OCRFont;
            this.BackColor = Color.Black;
            this.ForeColor = Color.White;
            this.BorderStyle = BorderStyle.FixedSingle;
            this.WordWrap = false;
    
            // Events
            //this.KeyPress += MapperTextBox_KeyPress;  // This never gets called in FL except in Bridged mode.  So, using KeyUp instead.
            this.KeyUp += MapperTextBox_KeyUp;
            this.GotFocus += MapperTextBox_GotFocus;
            this.LostFocus += MapperTextBox_LostFocus;

            // Tooptip
            ToolTip toolTip1 = new ToolTip();
            toolTip1.UseAnimation = true;
            toolTip1.IsBalloon = true;
            toolTip1.SetToolTip(this, tooltip);

            Changed = false;
        }
   
        public MapperTextBox(int x, int y, int width, int height,  String tooltip, bool ro) : this(x, y+2, width, height, tooltip)
        {
            this.ReadOnly = ro;
            this.BorderStyle = BorderStyle.None;
            this.TextAlign = HorizontalAlignment.Right;         
        }



        //KeyPressEventArgs kpea = new KeyPressEventArgs(c);
        //kpea.Handled = false;
        //this.OnKeyPress(kpea);


        private void MapperTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            this.BackColor = Color.FromArgb(25, 25, 25);
            this.ForeColor = Color.White;           
            
            Changed = false;           
            string keyChar = "";

            // Special cases
            switch (e.KeyCode)
            {
                case Keys.Back:    // Backspace
                {
                    if (Text.Length > 0)
                    {
                        int savedIndex = this.SelectionStart;
                        Text = Text.Remove(savedIndex - 1, 1);
                        SelectionStart = savedIndex - 1;
                        Changed = true;
                    }
                    return;
                }

                case Keys.Delete:    
                {
                    int savedIndex = this.SelectionStart;
                    Text = Text.Remove(SelectionStart, SelectionLength);
                    SelectionStart = savedIndex;
                    return;
                }

                case Keys.Space:
                {
                    keyChar = " ";
                    break;
                }

                default:
                {
                    keyChar = kc.ConvertToString(e.KeyData);
                    break;
                }
            }

            // Special case: Instances where everything goes (i.e. map names)
            if (nocheck) 
            {
                Changed = true;
            }
             
            // Clever hack from Gerard on Stack Overflow
            if ("0123456789abcdefABCDEFnvNV ".Contains(keyChar)) 
            {
                Changed = true;
            }
           
            if (Changed)
            {
                int savedIndex = this.SelectionStart;
                Text = Text.Insert(SelectionStart, keyChar);
                SelectionStart = savedIndex + keyChar.Length;                
                return;
            }


            MessageBox.Show(this, "Unhandled key: " + keyChar);
          
            

            /*

                        // This will only allow valid hex values [0-9][a-f][A-F], spaces, n, and v to be entered. (and copy/paste)
                        int ic = (int)c;

                        // Allowed letters&numbers , copy/paste
                        if (c != '\b' && !((c <= 'f' && c >= 'a') || (c <= 'F' && c >= 'A') || (c >= '0' && c <= '9') || (c == ' ') || (c == 'n') || (c == 'v') || (ic == 22) || (ic == 24)))
                        {
                            e.Handled = true;
                        }
 
             */
        }


        private void MapperTextBox_GotFocus(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(15, 15, 15);
            this.ForeColor = Color.White;
            Changed = false;
        }

        private void MapperTextBox_LostFocus(object sender, EventArgs e)
        {
            if (this.CheckValid())
            {
                this.BackColor = Color.Black;
                this.ForeColor = Color.White;
            }            
        }

        /// <summary>
        /// Check for valid entry.  True if OK.
        /// </summary>
        /// <returns>true if OK, false if parsing error.</returns>
        public bool CheckValid()
        {
            // Get rid of extra whitespace
            this.Text = this.Text.Trim();

            if (nocheck) return true;

            // Parse the strings with dummy substitution values to verify they're OK.  Don't use 0 as it may mask weird input ('NN33', for example)
            try
            {
                MapNoteItem.StringToBytes(this.Text, 15, 255);
            }
            catch // All, assume parsing errors
            {
                this.BackColor = Color.Yellow;
                this.ForeColor = Color.Black;
                return false;
            }

            return true;
        }          
    }
}
