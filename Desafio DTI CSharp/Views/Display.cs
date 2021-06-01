using System;
using System.Globalization;

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

            string index = Console.ReadLine();
            while (!int.TryParse(index, out int j ) || j > 5)
            {
                Console.WriteLine("Não consegui entender, pode repetir?");
                index = Console.ReadLine();
            }
            Option optionSelect = (Option) int.Parse(index);

            Console.WriteLine(optionSelect);
            
            switch (optionSelect)
            {
                case Option.CA:
                    createDisk();
                    return true;
                case Option.PA:
                    searchDisk();
                    return true;
                case Option.PM:
                    searchMusic();
                    return true;
                case Option.GP:
                    createPlaylist();
                    return true;
                case Option.S:
                    return false;
                default:
                    return false;
            }
        }
        public static bool createDisk()
        {
            return true;
        }
    
        public static bool searchDisk()
        {
            return true;
        }
        
        public static bool searchMusic()
        {
            return true;
        }
        
        public static bool createPlaylist()
        {
            return true;
        }
    }
}