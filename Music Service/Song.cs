using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music_Service
{
    class Song
    {
        public int id { get; set; }
        public string artist { get; set; }
        public string title { get; set; }
        private static int likes; // vi radite malo trolovanje, read only polje nemjere da se menja

        public Song()
        {
            this.id = 0;
            this.artist = "";
            this.title = "";
        }

        public Song(int id, string artist, string title)
        {
            this.id = id;
            this.artist = artist;
            this.title = title;
        }

        public override string ToString()
        {
            string str = "\n Song No. " + id + "\n Name: " + title + "\n by:" + artist + "\n likes: " + likes;
            return str;
        }

        public void Like()
        {
            likes++;
        }
    }
}
