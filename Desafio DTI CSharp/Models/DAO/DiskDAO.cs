using System;
using System.Collections.Generic;
using System.Linq;

namespace Desafio_DTI_CSharp.Models.DAO
{
    public static class DiskDAO
    {

        public static KeyValuePair<int, Disk> Create(Disk disk)
        {
            DB.DiskDB.Add(DB.IndexDisk, disk);
            DB.IndexDisk++;

            return new KeyValuePair<int, Disk>(DB.IndexDisk - 1, disk);
        }

        public static Dictionary<int, Music> GetFavoriteMusicsInDisk(int idDisk)
        {
            return DB.MusicDB.Where(music =>
            {
                return music.Value.IdDisk == idDisk && music.Value.IsFavorite;
            }).ToDictionary(music => music.Key, music => music.Value);
            
        }

        public static Dictionary<int, Music> GetMusicsInDisk(int idDisk)
        {
            return DB.MusicDB.Where(music =>
            {
                return music.Value.IdDisk == idDisk;
            }).ToDictionary(music => music.Key, music => music.Value);
        }

        public static void InsertMusicInDisk(int idDisk, Music music)
        {
            music.IdDisk = idDisk;
            DB.MusicDB.Add(DB.IndexMusic, music);
            DB.IndexMusic++;
        }


        public static void Print(Disk disk)
        {
            Console.WriteLine("Titulo: " + disk.Title);
            Console.WriteLine("Ano de lançamento: " + disk.Release);
            Console.WriteLine("Artista/Banda: " + disk.GroupName);
        }

        public static Dictionary<int, Disk> GetAllDisk()
        {
            return DB.DiskDB;
        }
        
        public static Disk GetDisk(int id)
        {
            if (DB.DiskDB.TryGetValue(id, out var disk))
            {
                return disk;
            }
            else
            {
                throw new ArgumentException("Não há álbum com esse id");
            }
        }
        
        public static Disk UpdateDisk(int id, Disk disk)
        {
            return disk;
        }
        
        public static Dictionary<int, Disk> Search(string search)
        {
            return DB.DiskDB.Where(disk =>
            {
                return SanitizeAndVerify(disk.Value.Title, search) ||  SanitizeAndVerify(disk.Value.Release, search) ||
                       SanitizeAndVerify(disk.Value.GroupName, search);
            }).ToDictionary(disk => disk.Key, disk => disk.Value);
        }

        private static bool SanitizeAndVerify(string str, string _str)
        {
            return str.ToLower().Normalize().Contains(_str.ToLower().Normalize());
        }
    }
}
