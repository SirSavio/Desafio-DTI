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

            Console.WriteLine(optionSelect);
            
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
                Disk disk = DiskController.Create(title, release, groupName);
                CollectionController.InsertDisk(disk);
                Console.WriteLine("Tudo certo! Álbum cadastrado!");
                InsertMusicOnDisk(disk);
                
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.WriteLine("Gostaria de tentar novamente?");
                Console.WriteLine("1) Sim");
                Console.WriteLine("2) Não");
                
                int index = GetAValidInput(true, 1, 2);

                if (index == 1)
                {
                    CreateDisk();
                }
                else
                {
                    return true;
                }
            }

            return true;
        }
    
        public static bool SearchDisk()
        {
            return true;
        }
        
        public static bool SearchMusic()
        {
            return true;
        }
        
        public static bool CreatePlaylist()
        {
            return true;
        }
        
        public static bool InsertMusicOnDisk(Disk disk)
        {
            Console.Clear();
            Console.WriteLine("Agora vamos cadastrar algumas músicas");
            Console.Write("Qual o nome da Música? ");
            string title = Console.ReadLine();
            Console.Write("\nBeleza, e qual a duração (MM:SS)? ");
            string duration = Console.ReadLine();
            Console.Write("\nPor último, é uma música favorita? ");
            Console.Write("\n0) Não");
            Console.WriteLine("\n1) Sim");
            bool isFavorite = bool.TryParse(Console.ReadLine(), out bool j);

            try
            {
                Music music = MusicController.Create(title, duration, isFavorite);
                disk = DiskController.InsertMusicOnDisk(music, disk);

                CollectionController.UpdateDisk(disk);

                List<Music> musics = DiskController.GetMusics(disk);

                List<Disk> dk = CollectionController.GetDisks();

                foreach (Disk d in dk)
                {
                    List<Music> ms = d.GetMusic();
                    foreach (Music m in ms)
                    {
                        m.Print(m);
                    }
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.WriteLine("Gostaria de tentar novamente?");
                Console.WriteLine("1) Sim");
                Console.WriteLine("2) Não");
                
                int index = GetAValidInput(true, 1, 2);

                if (index == 1)
                {
                    InsertMusicOnDisk(disk);
                }
                else
                {
                    return true;
                }
            }
            
            Console.WriteLine("Adicionar outra música?");
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