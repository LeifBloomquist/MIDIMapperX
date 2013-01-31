using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SchemaFactor.Vst.MidiMapperX
{
    class BufferedListView : ListView
    {
        public BufferedListView()
        {
            this.DoubleBuffered = true;
            this.UpdateStyles();
        } 
    }
}
