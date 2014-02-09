using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace SchemaFactor.Vst.MidiMapperX
{
    /// <summary>
    /// The About form.
    /// </summary>
    partial class AboutForm : Form
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public AboutForm(string info)
        {
            InitializeComponent();
            InfoLabel.Text = info;
        }

        private void DonateLogo_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=MKFPKYAD45VQL");
        }
    }
}