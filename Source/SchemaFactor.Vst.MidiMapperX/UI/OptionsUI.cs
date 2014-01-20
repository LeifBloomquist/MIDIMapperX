using System;
using System.Windows.Forms;

namespace SchemaFactor.Vst.MidiMapperX
{
    /// <summary>
    /// A form that allows the user to edit the details of a note map item.
    /// </summary>
    partial class OptionsUI : Form
    {
        /// <summary>
        /// Gets or sets the temporary options set that is being edited in the form.
        /// </summary>
        public OptionSet TempOptionSet { get; private set; }

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public OptionsUI(OptionSet opt)
        {
            InitializeComponent();

            ThruCheckbox.Checked = opt.MidiThru;
            AllThruCheckbox.Checked = opt.MidiThruAll;
            SysExCheckbox.Checked = opt.AlwaysSysEx;

            TempOptionSet = new OptionSet();
        }

        private void OptionsUI_Load(object sender, EventArgs e) 
        {
            ToolTip toolTip1 = new ToolTip();
            toolTip1.UseAnimation = true;
            toolTip1.IsBalloon = true;
            toolTip1.SetToolTip(ThruCheckbox,    "When checked, all non-mapped note on/off events are passed through normally.");
            toolTip1.SetToolTip(AllThruCheckbox, "When checked, all note on/off events are passed through normally, in addition to the new mappings.");
        }

        private void OKBtn_Click(object sender, EventArgs e)
        {
            TempOptionSet.MidiThru = ThruCheckbox.Checked;
            TempOptionSet.MidiThruAll = AllThruCheckbox.Checked;
            TempOptionSet.AlwaysSysEx = SysExCheckbox.Checked;
        }
    }
}