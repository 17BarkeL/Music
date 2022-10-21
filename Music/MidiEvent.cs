using NAudio.Midi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music
{
    public abstract class MidiEvent
    {
        protected byte[] buffer = new byte[3]; // The bytes sent as MIDI data
        protected int channel; // There are 16 channels to choose from
        public MidiOut device;

        /// <summary>
        /// Send MIDI data
        /// </summary>
        public abstract void Send();
    }
}
