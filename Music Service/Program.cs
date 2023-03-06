using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Music_Service
{
    class Program
    {
        public static void ExportSong(Song track, string fileName)
        {
            using (BinaryWriter binWriter = new BinaryWriter(File.Open(fileName, FileMode.Create)))
            {

                binWriter.Write(track.id);
                binWriter.Write(track.artist);
                binWriter.Write(track.title);
                //binWriter.Write(track.likes); - ne znam da upisem static polje u binarni fajl
            }
        }

        public static Song ImportSong(string fileName)
        {
            Song x = new Song();

            BinaryReader binReader = new BinaryReader(File.Open(fileName, FileMode.Open));
 

            Encoding ascii = Encoding.ASCII;
            BinaryWriter bwEncoder = new BinaryWriter(new FileStream(fileName, FileMode.Create), ascii);

            x.id = binReader.ReadInt32();
            x.artist = binReader.ReadString();
            x.title = binReader.ReadString();
            //nijesam eksportovo lajkove pa nemrem ni da ih importujem

            return x;
        }

        static void Main(string[] args)
        {
            Song SS = new Song(0, "Wehrmacht", "erika");

            Song s1 = new Song(1, "Maneskin", "ZITTI E BUONI");
            Song s2 = new Song(2, "2Pac", "Ambitions Az A Ridah");
            Song s3 = new Song(3, "Porter Robinson", "Unfold");
            Song s4 = new Song(4, "Grah", "Lud crnja");
            Song s5 = new Song(5, "Selphius", "Los! Los! Los!");

            Song m1 = new Song(11, "Sabaton", "Panzerkampf");
            Song m2 = new Song(22, "The Longest Johns", "Wellerman");
            Song m3 = new Song(33, "Gloryhammer", "Hootsforce");
            Song m4 = new Song(44, "Rammstein", "DEUTSCHLAND");
            Song m5 = new Song(55, "BLACKPINK", "How You Like That");

            Console.WriteLine(s4.ToString()); Console.WriteLine();

            s4.Like();

            Console.WriteLine(s4.ToString()); Console.WriteLine();

            List<Song> Playlist1 = new List<Song> { };

            Account acc1 = new Account("Sale");

            acc1.AddSong(s1);
            acc1.AddSong(s2);
            acc1.AddSong(s3);
            acc1.AddSong(s4);
            acc1.AddSong(s5);

            Account acc2 = new Account("Grahov");

            acc2.AddSong(m1);
            acc2.AddSong(m2);
            acc2.AddSong(m3);
            acc2.AddSong(m4);
            acc2.AddSong(m5);

            Console.WriteLine(acc1.ToString()); Console.WriteLine();
            Console.WriteLine(acc2.ToString()); Console.WriteLine();

            acc1.RemoveSong(3);

            Console.WriteLine(acc1.ToString()); Console.WriteLine();

            acc1.Play();

            Console.WriteLine(acc1.ToString()); Console.WriteLine();

            acc1.Like();

            Console.WriteLine(acc1.ToString()); Console.WriteLine();

            MusicService Spotify = new MusicService { };

            Spotify.AddAccount(acc1);
            Spotify.AddAccount(acc2);

            Console.WriteLine(Spotify.ToString()); Console.WriteLine();

            Spotify.RemoveAccount("Grahov");

            Console.WriteLine(Spotify.ToString()); Console.WriteLine();

            Spotify.Export();

            ExportSong(SS, "Tracks");

            Song Gestapo = ImportSong("Tracks"); //nece import nesto da radi

            Console.WriteLine(Gestapo.ToString()); Console.WriteLine();
        }
    }
}
