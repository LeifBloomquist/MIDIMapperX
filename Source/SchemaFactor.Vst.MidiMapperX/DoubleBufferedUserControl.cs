using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

#pragma warning disable 1591

namespace SchemaFactor.Vst.MidiMapperX
{
    public partial class DoubleBufferedUserControl : UserControl
    {
        public DoubleBufferedUserControl()
        {

        }

        private Bitmap _backBuffer;

        protected override void OnPaint(PaintEventArgs e)
        {
            if (_backBuffer == null)
            {
                _backBuffer = new Bitmap(this.ClientSize.Width, this.ClientSize.Height);
            }

            Graphics g = Graphics.FromImage(_backBuffer);

            //Paint your graphics on g here

            g.Dispose();

            //Copy the back buffer to the screen

            e.Graphics.DrawImageUnscaled(_backBuffer, 0, 0);

            // base.OnPaint (e); //optional but not recommended
        }

        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            //Don't allow the background to paint
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            if (_backBuffer != null)
            {
                _backBuffer.Dispose();
                _backBuffer = null;
            }
            base.OnSizeChanged(e);
        }
    }
}

#pragma warning restore 1591