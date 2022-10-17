using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music
{
    public class MidiEvent
    {
        protected byte[] buffer = new byte[3]; // The bytes sent as MIDI data
        protected int channel; // There are 16 channels to choose from

        /// <summary>
        /// Send MIDI data
        /// </summary>
        public void Send()
        {
            // Not implemented yet
        }
    }
}
