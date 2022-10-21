using NAudio.Midi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music
{
    public abstract class MusicalNotation
    {
        public int duration;
        public MidiOut device;

        public abstract void Play();

        public override string ToString()
        {
            return $"Unknown music notation for {duration} beats";
        }
    }
}
