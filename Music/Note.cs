using NAudio.Midi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Music
{
    public class Note : MusicalNotation
    {
        public int volume = 127;
        public int noteNumber;
        public MidiOut device;

        public override string ToString()
        {
            return $"Note {noteNumber} at volume {volume} for {duration} beats";
        }

        public override void Play()
        {
            NoteOn on = new NoteOn(this, this.device);
            on.Send();
            Thread.Sleep(100 * duration);
            NoteOff off = new NoteOff(this, this.device);
            off.Send();
        }
    }
}
