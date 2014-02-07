using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

#pragma warning disable 1591

namespace SchemaFactor.Vst.MidiMapperX
{
    public static class Constants
    {
        public const int VERSION = 2000;
        public const int MAXNOTES = 128;
        public const string MIDIMAPPERX = "MIDIMAPPERX";

        public enum Modes { RUN = 1, EDIT = 2 };
        public enum MapTypes { ON = 1, OFF = 2, CC = 3 };
    }
}

#pragma warning restore 1591