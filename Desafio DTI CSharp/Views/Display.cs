using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using Desafio_DTI_CSharp.Controllers;
using Desafio_DTI_CSharp.Models;

namespace Desafio_DTI_CSharp.Views
{
    public static class Display
    {
        enum Option { CA = 1, PA, PM, GP, S }
        
        public static bool Menu()
        {
            Console.WriteLine("Olá, Billie Joe!");
            Console.WriteLine("Escolha entre uma das opções abaixo:\n");
            Console.WriteLine("1) Cadastrar Álbum");
            Console.WriteLine("2) Pesquisar Álbum");
            Console.WriteLine("3) Pesquisar Música");
            Console.WriteLine("4) Gerar Playlist");
            Console.WriteLine("5) Sair");

            int index = GetAValidInput(true);
            Option optionSelect = (Option) index;

            switch (optionSelect)
            {
                case Option.CA:
                    CreateDisk();
                    return true;
                case Option.PA:
                    SearchDisk();
                    return true;
                case Option.PM:
                    SearchMusic();
                    return true;
                case Option.GP:
                    CreatePlaylist();
                    return true;
                case Option.S:
                    return false;
                default:
                    return false;
            }
        }
        public static bool CreateDisk()
        {
            Console.Clear();
            Console.Write("Show, qual o nome do Álbum? ");
            string title = Console.ReadLine();
            Console.Write("\nBeleza, e qual o ano de lançamento? ");
            string release = Console.ReadLine();
            Console.Write("\nPor último qual a banda/artista? ");
            string groupName = Console.ReadLine();

            try
            {
                Disk disk = new Disk(title, release, groupName);
                KeyValuePair<int, Disk> ds = DiskController.Create(disk);
                Console.WriteLine("Tudo certo! Álbum cadastrado!");
                InsertMusicOnDisk(ds);
                
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Gostaria de tentar novamente?");
                Console.WriteLine("1) Sim");
                Console.WriteLine("2) Não");
                
                int index = GetAValidInput(true, 1, 2);

                if (index == 1)
                {
                    CreateDisk();
                    return true;
                }

                return true;
            }
        }
    
        public static bool SearchDisk()
        {
            Console.Clear();
            Console.Write("Show, o que deseja pesquisar? ");
            string search = Console.ReadLine();
            
            try
            {
                Dictionary<int, Disk> disks = DiskController.Search(search);
                Console.WriteLine("Tudo certo! Encontramos " + disks.Count + " Álbum(ns)\n" );

                foreach (KeyValuePair<int, Disk> disk in disks)
                {
                    Console.WriteLine("Álbum "+ disk.Key+1 + ")\n");
                    DiskController.Print(disk.Value);

                    Console.WriteLine("Músicas:\n");

                    Dictionary<int, Music> musics = DiskController.GetMusics(disk.Key);

                    foreach (KeyValuePair<int, Music> music in musics)
                    {
                        string fav = music.Value.IsFavorite ? " (Favorita)" : "";
                        Console.WriteLine(music.Key+1 + ") " +  music.Value.Title + fav);
                    }
                    Console.WriteLine("\n********************/////////********************\n");
                }
                Console.ReadLine();
            }
            catch (Exception e) 
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Gostaria de tentar novamente?");
                Console.WriteLine("1) Sim");
                Console.WriteLine("2) Não");
                
                int index = GetAValidInput(true, 1, 2);

                if (index == 1)
                {
                    SearchDisk();
                    return true;
                }

                return true;
            }

            Console.WriteLine("Gostaria de pesquisar novamente?");
            Console.WriteLine("1) Sim");
            Console.WriteLine("2) Não");
                
            int again = GetAValidInput(true, 1, 2);

            if (again == 1)
            {
                SearchDisk();
                return true;
            }

            return true;
        }
        
        public static bool SearchMusic()
        {
            Console.Clear();
            Console.Write("Show, o que deseja pesquisar? ");
            string search = Console.ReadLine();
            
            try
            {
                Dictionary<int, Music> musics = MusicController.Search(search);
                Console.WriteLine("Tudo certo! Encontramos " + musics.Count + " Música(s)\n" );

                foreach (KeyValuePair<int, Music> music in musics)
                {
                    Console.WriteLine("Música "+ (music.Key+1) + ")\n");
                    MusicController.Print(music.Value);

                    Console.WriteLine("\n********************/////////********************\n");
                    
                    KeyValuePair<int, Disk> musicDisk = MusicController.GetMusicDisk(music.Value.IdDisk);
                    Console.WriteLine("Está no Álbum " + (music.Value.IdDisk+1) + ") " + musicDisk.Value.Title + "\n");
                    DiskController.Print(musicDisk.Value);
                }
            }
            catch (Exception e) 
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Gostaria de tentar novamente?");
                Console.WriteLine("1) Sim");
                Console.WriteLine("2) Não");
                
                int index = GetAValidInput(true, 1, 2);

                if (index == 1)
                {
                    SearchMusic();
                    return true;
                }

                return true;
            }

            Console.WriteLine("Gostaria de pesquisar novamente?");
            Console.WriteLine("1) Sim");
            Console.WriteLine("2) Não");
                
            int again = GetAValidInput(true, 1, 2);

            if (again == 1)
            {
                SearchMusic();
                return true;
            }

            return true;
        }
        
        public static bool CreatePlaylist()
        {
            Console.Clear();
            Console.WriteLine("Gerando uma playlist de qualidade...\n");
            Console.WriteLine("A sua playlist é:\n");

            try
            {
                Dictionary<int, Music> playlist = MusicController.GeneratePlaylist();

                foreach (KeyValuePair<int, Music> music in playlist)
                {
                    Console.WriteLine("Música "+ music.Key+1 + ")\n");
                    MusicController.Print(music.Value);
                    KeyValuePair<int, Disk> musicDisk = MusicController.GetMusicDisk(music.Value.IdDisk);
                    Console.WriteLine("Está no Álbum " + music.Value.IdDisk + ") " + musicDisk.Value.Title + "\n");
                    Console.WriteLine("\n********************/////////********************\n");
                }
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Gostaria de tentar novamente?");
                Console.WriteLine("1) Sim");
                Console.WriteLine("2) Não");
                
                int index = GetAValidInput(true, 1, 2);

                if (index == 1)
                {
                    CreatePlaylist();
                    return true;
                }
                return true;
            }
            
            Console.WriteLine("\nGostaria de gerar outra?");
            Console.WriteLine("1) Sim");
            Console.WriteLine("2) Não");
            int again = GetAValidInput(true, 1, 2);
            if (again == 1)
            {
                CreatePlaylist();
            }
            return true;
        }
        
        public static bool InsertMusicOnDisk(KeyValuePair<int, Disk> disk)
        {
            Console.Clear();
            Console.WriteLine("Agora vamos cadastrar algumas músicas");
            Console.Write("Qual o nome da Música? ");
            string title = Console.ReadLine();
            Console.Write("\nBeleza, e qual a duração (MM:SS)? ");
            string duration = Console.ReadLine();
            Console.Write("\nPor último, é uma música favorita? ");
            Console.Write("\n1) Sim");
            Console.WriteLine("\n2) Não");
            string favorite = Console.ReadLine();

            try
            {
                bool isFavorite = favorite == "1" ? true : false;
                Music music = new Music(title, duration, isFavorite);
                DiskController.InsertMusic(disk.Key, music);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Gostaria de tentar novamente?");
                Console.WriteLine("1) Sim");
                Console.WriteLine("2) Não");
                
                int index = GetAValidInput(true, 1, 2);

                if (index == 1)
                {
                    InsertMusicOnDisk(disk);
                    return true;
                }

                return true;
            }
            
            Console.WriteLine("\nAdicionar outra música?");
            Console.WriteLine("1) Sim");
            Console.WriteLine("2) Não");
            int again = GetAValidInput(true, 1, 2);
            if (again == 1)
            {
                InsertMusicOnDisk(disk);
            }
            return true;
        }

        private static int GetAValidInput(bool limit = false, int min = 1, int max = 5)
        {
            string index = Console.ReadLine();
            while (!int.TryParse(index, out int j ) || (limit && (j > max || j < min )))
            {
                Console.WriteLine("Não consegui entender, pode repetir?");
                index = Console.ReadLine();
            }

            return int.Parse(index);
        }
    }
}