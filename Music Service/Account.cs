using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music_Service
{
    class Account
    {
        public string username { get; set; }
        private List<Song> songs = new List<Song> { };

        public Account(string us)
        {
            this.username = us;
        }


        public bool AddSong(Song song)
        {
            int b = 0;
            foreach (Song x in songs)
            {
                if (song.id == x.id)
                {
                    b++;
                }
            }
            if(b == 0)
            {
                songs.Add(song);
                return true;
            }
            return false;
        }

        public bool RemoveSong(int index)
        {
            if (index < songs.Count)
            {
                songs.RemoveAt(index);
                return true;
            }
            else return false;
        }

        public void Play()
        {
            Console.WriteLine(songs[0].ToString());
            Song x = new Song();
            x = songs[0];
            RemoveSong(0);
            AddSong(x);
        }

        public void Like()
        {
            songs[0].Like();
        }

        public override string ToString()
        {
            string str = "\n Username: " + username + "\n Songs:";
            foreach (Song x in songs)
            {
                str = str + x.ToString();
            }
            return str;
        }
    }
}
