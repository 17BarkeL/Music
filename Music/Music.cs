using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music
{
    public class Music
    {
        // ([A-G])(\d) (\d)
        private List<Note> notes = new List<Note>();
        private string fileName;

        public Music(string fileName)
        {
            Console.WriteLine($"Loading music from {fileName}");
            this.fileName = fileName;
        }

        public void Play()
        {
            string[] musicData = File.ReadAllLines(fileName);

            foreach (string line in musicData)
            {
                Console.WriteLine();
            }

            foreach (Note note in notes)
            {
                note.Play();
            }
        }
    }
}
