using NAudio.Midi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music
{
    public class NoteOn : MidiEvent
    {
        private Note note;

        public NoteOn(Note note, MidiOut device)
        {
            this.note = note;

            buffer[0] = 0x90; // Assume on channel 0
            buffer[1] = (byte)note.noteNumber;
            buffer[2] = (byte)note.volume;
        }

        public override void Send()
        {
            midiDevice.SendBuffer(buffer);
        }
    }
}
