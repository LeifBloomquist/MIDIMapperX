namespace SchemaFactor.Vst.MidiMapperX
{
    using System.Reflection;
    using System.Windows.Forms;


    /// <summary>
    /// sdfds
    /// </summary>
    public class BufferedListView : ListView
    {
        /// <summary>
        /// dsfsdf
        /// </summary>
        public BufferedListView()
            : base()
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.DoubleBuffer, true); 
            //SetStyle(ControlStyles.UserPaint, true);        
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.Opaque, true);
            SetStyle(ControlStyles.EnableNotifyMessage, true);
            SetStyle(ControlStyles.ResizeRedraw, true);           
            this.UpdateStyles();
            EnableDoubleBuffering(this);
        }

        /// <summary>
        /// This may help with the flickering.
        /// </summary>
        /// <param name="m"></param>
        protected override void OnNotifyMessage(Message m)
        {
            //if (m.Msg == 0x14) m.Msg = 0x00;
            if (m.Msg != 0x14) {
            base.OnNotifyMessage(m);
            }
        }

        /// <summary>
        /// tyghfhf
        /// </summary>
        /// <param name="control"></param>
        public static void EnableDoubleBuffering(Control control)
        {
            var property = typeof(Control).GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
            property.SetValue(control, true, null);
        }
    }
}
