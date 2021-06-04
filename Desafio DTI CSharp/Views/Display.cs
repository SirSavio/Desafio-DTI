using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using Desafio_DTI_CSharp.Controllers;
using Desafio_DTI_CSharp.Models;
using Desafio_DTI_CSharp.Models.DAO;

namespace Desafio_DTI_CSharp.Views
{
    public static class Display
    {
        enum Option { CA = 1, PA, PM, GP, AA, S }
        
        public static bool Menu()
        {
            Console.WriteLine("Olá, Billie Joe!");
            Console.WriteLine("Escolha entre uma das opções abaixo:\n");
            Console.WriteLine("1) Cadastrar Álbum");
            Console.WriteLine("2) Pesquisar Álbum");
            Console.WriteLine("3) Pesquisar Música");
            Console.WriteLine("4) Gerar Playlist");
            Console.WriteLine("5) Atualizar Álbum");
            Console.WriteLine("6) Sair");

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
                case Option.AA:
                    UpdateDisk();
                    return true;
                case Option.S:
                    return false;
                default:
                    return true;
            }
        }
        private static void CreateDisk()
        {
            Console.WriteLine("\n\n\n\n\n\n\n\n");
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
                InsertMusicInDisk(ds);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("\nGostaria de tentar novamente?");
                Console.WriteLine("1) Sim");
                Console.WriteLine("2) Não");
                
                int index = GetAValidInput(true, 1, 2);

                if (index == 1)
                {
                    CreateDisk();
                }
            }
        }
    
        private static void SearchDisk()
        {
            Console.WriteLine("\n\n\n\n\n\n\n\n");
            Console.Clear();
            Console.Write("Show, o que deseja pesquisar? ");
            string search = Console.ReadLine();
            
            try
            {
                Dictionary<int, Disk> disks = DiskController.Search(search);
                Console.WriteLine("Tudo certo! Encontramos " + disks.Count + " Álbum(ns)\n" );

                foreach (KeyValuePair<int, Disk> disk in disks)
                {
                    Console.WriteLine("Álbum "+ disk.Key + ")\n");
                    DiskController.Print(disk.Value);

                    Console.WriteLine("Músicas:\n");

                    Dictionary<int, Music> musics = DiskController.GetMusics(disk.Key);

                    foreach (KeyValuePair<int, Music> music in musics)
                    {
                        string fav = music.Value.IsFavorite ? " (Favorita)" : "";
                        Console.WriteLine(music.Key + ") " +  music.Value.Title + fav);
                    }
                    Console.WriteLine("\n********************/////////********************\n");
                }
            }
            catch (Exception e) 
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("\nGostaria de tentar novamente?");
                Console.WriteLine("1) Sim");
                Console.WriteLine("2) Não");
                
                int index = GetAValidInput(true, 1, 2);

                if (index == 1)
                {
                    SearchDisk();
                }
            }

            Console.WriteLine("\nGostaria de pesquisar novamente?");
            Console.WriteLine("1) Sim");
            Console.WriteLine("2) Não");
                
            int again = GetAValidInput(true, 1, 2);

            if (again == 1)
            {
                SearchDisk();
            }
        }
        
        private static void SearchMusic()
        {
            Console.WriteLine("\n\n\n\n\n\n\n\n");
            Console.Clear();
            Console.Write("Show, o que deseja pesquisar? ");
            string search = Console.ReadLine();
            
            try
            {
                Dictionary<int, Music> musics = MusicController.Search(search);
                Console.WriteLine("Tudo certo! Encontramos " + musics.Count + " Música(s)\n" );

                foreach (KeyValuePair<int, Music> music in musics)
                {
                    Console.WriteLine("Música "+ music.Key + ")\n");
                    MusicController.Print(music.Value);

                    KeyValuePair<int, Disk> musicDisk = DiskController.GetDisk(music.Value.IdDisk);
                    Console.WriteLine("Está no Álbum " + music.Value.IdDisk + ") " + musicDisk.Value.Title + "\n");
                    DiskController.Print(musicDisk.Value);
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
                    SearchMusic();
                }
            }

            Console.WriteLine("\nGostaria de pesquisar novamente?");
            Console.WriteLine("1) Sim");
            Console.WriteLine("2) Não");
                
            int again = GetAValidInput(true, 1, 2);

            if (again == 1)
            {
                SearchMusic();
            }
        }
        
        private static void CreatePlaylist()
        {
            Console.WriteLine("\n\n\n\n\n\n\n\n");
            Console.Clear();
            Console.WriteLine("Gerando uma playlist de qualidade...\n");
            Console.WriteLine("A sua playlist é:\n");

            try
            {
                Dictionary<int, Music> playlist = MusicController.GeneratePlaylist();

                foreach (KeyValuePair<int, Music> music in playlist)
                {
                    Console.WriteLine("Música "+ music.Key + ")\n");
                    MusicController.Print(music.Value);
                    KeyValuePair<int, Disk> musicDisk = DiskController.GetDisk(music.Value.IdDisk);
                    Console.WriteLine("Está no Álbum " + music.Value.IdDisk + ") " + musicDisk.Value.Title + "\n");
                    Console.WriteLine("\n********************/////////********************\n");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("\nGostaria de tentar novamente?");
                Console.WriteLine("1) Sim");
                Console.WriteLine("2) Não");
                
                int index = GetAValidInput(true, 1, 2);

                if (index == 1)
                {
                    CreatePlaylist();
                }
            }
            
            Console.WriteLine("\nGostaria de gerar outra?");
            Console.WriteLine("1) Sim");
            Console.WriteLine("2) Não");
            int again = GetAValidInput(true, 1, 2);
            if (again == 1)
            {
                CreatePlaylist();
            }
        }
        
        private static void UpdateDisk()
        {
            Console.Write("\n\n\n\n\n\n\n\n");
            Console.Clear();
            try
            {
                Dictionary<int, Disk> disks = DiskController.GetAllDisks();

                foreach (KeyValuePair<int, Disk> disk in disks)
                {
                    Console.WriteLine("Álbum " + disk.Key + ") " + disk.Value.Title);
                }
                
                Console.WriteLine("Qual o número do Álbum que deseja alterar? " );
                int index = GetAValidInput(true, 1, disks.Keys.Max());
                
                Console.WriteLine("Álbum " + disks[index].Title + " selecionado!" );
                
                Console.WriteLine("Certo, o que deseja alterar?\n");
                Console.WriteLine("1) Inserir Música");
                Console.WriteLine("2) Remover Música");
                Console.WriteLine("3) Remover Álbum");
                Console.WriteLine("4) Atualizar informações básicas");
                int option =  GetAValidInput(true, 1, 4);

                if (option == 1)
                {
                    InsertMusicInDisk(new KeyValuePair<int, Disk>(index, disks[index]));
                }else if (option == 2)
                {
                    RemoveMusicInDisk(new KeyValuePair<int, Disk>(index, disks[index]));
                }
                else if(option == 3)
                {
                    RemoveDisk(new KeyValuePair<int, Disk>(index, disks[index]));
                }
                else
                {
                    UpdateDiskBasicData(new KeyValuePair<int, Disk>(index, disks[index]));
                }
            }
            catch (Exception e) 
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("\nGostaria de tentar novamente?");
                Console.WriteLine("1) Sim");
                Console.WriteLine("2) Não");
                
                int index = GetAValidInput(true, 1, 2);

                if (index == 1)
                {
                    UpdateDisk();
                }
            }

            Console.WriteLine("\nGostaria de atualizar outro Álbum?");
            Console.WriteLine("1) Sim");
            Console.WriteLine("2) Não");
                
            int again = GetAValidInput(true, 1, 2);

            if (again == 1)
            {
                UpdateDisk();
            }
        }
        
        private static void InsertMusicInDisk(KeyValuePair<int, Disk> disk)
        {
            Console.WriteLine("\n\n\n\n\n\n\n\n");
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
                Console.WriteLine("\nGostaria de tentar novamente?");
                Console.WriteLine("1) Sim");
                Console.WriteLine("2) Não");
                
                int index = GetAValidInput(true, 1, 2);

                if (index == 1)
                {
                    InsertMusicInDisk(disk);
                }
            }
            
            Console.WriteLine("\nAdicionar outra música?");
            Console.WriteLine("1) Sim");
            Console.WriteLine("2) Não");
            int again = GetAValidInput(true, 1, 2);
            if (again == 1)
            {
                InsertMusicInDisk(disk);
            }
        }
        
        private static void RemoveMusicInDisk(KeyValuePair<int, Disk> disk)
        {
            Console.WriteLine("\n\n\n\n\n\n\n\n");
            Console.Clear();

            try
            {
                Dictionary<int, Music> musics = DiskController.GetMusics(disk.Key);
                foreach (KeyValuePair<int, Music> music in musics)
                {
                    Console.WriteLine(music.Key + ") " + music.Value.Title);
                }
                Console.Write("Qual o número da Música? ");
                int index = GetAValidInput(true, 1, musics.Keys.Max());

                bool choice = GetUserConfirmationRemoveMusic(musics[index].Title, disk.Value.Title);
                if(choice) MusicController.RemoveMusic(index);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("\nGostaria de tentar novamente?");
                Console.WriteLine("1) Sim");
                Console.WriteLine("2) Não");
                
                int index = GetAValidInput(true, 1, 2);

                if (index == 1)
                {
                    RemoveMusicInDisk(disk);
                }
            }
            
            Console.WriteLine("\nRemover outra música?");
            Console.WriteLine("1) Sim");
            Console.WriteLine("2) Não");
            int again = GetAValidInput(true, 1, 2);
            if (again == 1)
            {
                RemoveMusicInDisk(disk);
            }
        }
        
        private static void RemoveDisk(KeyValuePair<int, Disk> disk)
        {
            Console.WriteLine("\n\n\n\n\n\n\n\n");
            Console.Clear();
            try
            {
                bool choice = GetUserConfirmationRemoveDisk(disk.Value.Title);
                if(choice) DiskController.RemoveDisk(disk.Key);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("\nGostaria de tentar novamente?");
                Console.WriteLine("1) Sim");
                Console.WriteLine("2) Não");
                
                int index = GetAValidInput(true, 1, 2);

                if (index == 1)
                {
                    UpdateDisk();
                }
            }
            Console.WriteLine("\nRemover outro Álbum?");
            int again = GetAValidInput(true, 1, 2, true);
            if (again == 1)
            {
                UpdateDisk();
            }
        }
        
        private static void UpdateDiskBasicData(KeyValuePair<int, Disk> disk)
        {
            Console.WriteLine("\n\n\n\n\n\n\n\n");
            Console.Clear();
            Console.Write("Show, qual o novo nome do Álbum? (default: "+disk.Value.Title+") ");
            string title = Console.ReadLine();
            Console.Write("\nBeleza, e qual o novo ano de lançamento? (default: "+disk.Value.Release+") ");
            string release = Console.ReadLine();
            Console.Write("\nPor último qual a nova banda/artista? (default: "+disk.Value.GroupName+") ");
            string groupName = Console.ReadLine();

            title = !string.IsNullOrEmpty(title) ? title : disk.Value.Title;
            release = !string.IsNullOrEmpty(title) ? release : disk.Value.Release;
            groupName = !string.IsNullOrEmpty(title) ? groupName : disk.Value.GroupName;
            
            try
            {
                Disk newDisk = new Disk(title, release, groupName);
                KeyValuePair<int, Disk> ds = DiskController.UpdateDisk(disk.Key, newDisk);
                Console.WriteLine("Tudo certo! Álbum atualizado!");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("\nGostaria de tentar novamente?");
                Console.WriteLine("1) Sim");
                Console.WriteLine("2) Não");
                
                int index = GetAValidInput(true, 1, 2);

                if (index == 1)
                {
                    UpdateDiskBasicData(disk);
                }
            }
        }

        private static int GetAValidInput(bool limit = false, int min = 1, int max = 6, bool trueOrNot = false)
        {
            if (trueOrNot)
            {
                Console.WriteLine("1) Sim");
                Console.WriteLine("2) Não");
            }
            string index = Console.ReadLine();
            while (!int.TryParse(index, out int j ) || (limit && (j > max || j < min )))
            {
                Console.WriteLine("Não consegui entender, pode repetir?");
                index = Console.ReadLine();
            }

            return int.Parse(index);
        }
        
        private static bool GetUserConfirmationRemoveMusic(string musicTitle, string diskTitle)
        {
            Console.WriteLine("\n\n\n\n\n\n\n\n");
            Console.Clear();
            Console.WriteLine("\nVocê tem certeza que deseja remover \""+ musicTitle +"\" de " + diskTitle + "? ");
            int index = GetAValidInput(true, 1, 2, true);

            if (index == 1) return true;
            return false;
        }
        
        private static bool GetUserConfirmationRemoveDisk(string diskTitle)
        {
            Console.WriteLine("\n\n\n\n\n\n\n\n");
            Console.Clear();
            Console.WriteLine("\nVocê tem certeza que deseja remover \""+ diskTitle +"\" e todas as suas músicas? ");
            int index = GetAValidInput(true, 1, 2, true);

            if (index == 1) return true;
            return false;
        }
    }
}