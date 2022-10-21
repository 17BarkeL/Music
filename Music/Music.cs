using NAudio.Midi;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Music
{
    public class Music
    {
        private List<MusicalNotation> notes = new List<MusicalNotation>();
        private string fileName;

        public Music(string fileName)
        {
            Console.WriteLine($"Loading music from {fileName}...");
            this.fileName = fileName;
            string musicContents = File.ReadAllText(fileName);
            musicContents = Regex.Replace(musicContents, @"\/\/.*", "");

            int octave = 4;

            foreach (Match match in Regex.Matches(musicContents, @"([A-G])*([b#])*(\d)*(:(\d))*"))
            {
                // Get note
                string note = match.Groups[1].Value;

                // Is it a note or a rest
                if (note.Length > 0)
                {
                    // Get octave
                    if (match.Groups[3].Value.Length > 0)
                    {
                        octave = int.Parse(match.Groups[3].Value);
                    }

                    // Get flat or sharp
                    bool flat = match.Groups[2].Value == "b";
                    bool sharp = match.Groups[2].Value == "#";

                    

                    Note newNote = new Note();

                    newNote.duration = 1;

                    if (match.Groups[5].Value.Length > 0)
                    {
                        newNote.duration = int.Parse(match.Groups[5].Value);
                    }

                    newNote.noteNumber = NoteToNumber(note[0], flat, sharp, octave);
                    notes.Add(newNote);
                }

                else
                {
                    Rest newRest = new Rest();
                    newRest.duration = 1;

                    if (match.Groups[5].Value.Length > 0)
                    {
                        newRest.duration = int.Parse(match.Groups[5].Value);
                        notes.Add(newRest);
                    }
                }
            }
        }

        public void Play()
        {
            MidiOut player = new MidiOut(0);
            Console.WriteLine($"Using {MidiOut.DeviceInfo(0).ProductName}");
            byte[] buffer = new byte[3] { 0x90, 0x3C, 127 };
            player.SendBuffer(buffer);
            buffer[0] = 0x80;
            Console.ReadLine();
            player.SendBuffer(buffer);
            player.Volume = int.MaxValue;

            Console.WriteLine("Playing...");

            foreach (MusicalNotation notation in notes)
            {
                notation.device = player;
                notation.Play();

                if (notation.GetType().Name == "Note")
                {
                    Note note = (Note)notation;
                    Console.WriteLine(note.ToString());
                }

                else
                {
                    Console.WriteLine(notation.ToString());
                }
            }
        }

        public int NoteToNumber(char noteName, bool flat, bool sharp, int octave)
        {
            int noteNumber = 0;

            switch (noteName)
            {
                case 'C':
                    noteNumber = 0;
                    break;
                case 'D':
                    noteNumber = 2;
                    break;
                case 'E':
                    noteNumber = 4;
                    break;
                case 'F':
                    noteNumber = 5;
                    break;
                case 'G':
                    noteNumber = 7;
                    break;
                case 'A':
                    noteNumber = 9;
                    break;
                case 'B':
                    noteNumber = 11;
                    break;
            }

            if (flat)
            {
                noteNumber--;
            }

            if (sharp)
            {
                noteNumber++;
            }

            return noteNumber + (octave * 12);
        }
    }
}
