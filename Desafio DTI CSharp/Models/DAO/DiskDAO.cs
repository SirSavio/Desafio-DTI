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
            Dictionary<int, Music> musics = DB.MusicDB.Where(music =>
            {
                return music.Value.IdDisk == idDisk && music.Value.IsFavorite;
            }).ToDictionary(music => music.Key, music => music.Value);

            if (musics.Count == 0) throw new ArgumentException("Nenhuma música favorita no álbum!");
            return musics;
        }

        public static Dictionary<int, Music> GetMusicsInDisk(int idDisk)
        {
            Dictionary<int, Music> musics = DB.MusicDB.Where(music =>
            {
                return music.Value.IdDisk == idDisk;
            }).ToDictionary(music => music.Key, music => music.Value);

            if (musics.Count == 0) throw new ArgumentException("Nenhuma música nesse álbum!");
            else return musics;
        }

        public static void InsertMusicInDisk(int idDisk, Music music)
        {
            music.IdDisk = idDisk;

            if (DB.DiskDB.TryGetValue(idDisk, out var i))
            {
                DB.MusicDB.Add(DB.IndexMusic, music);
                DB.IndexMusic++;   
            }
            else
            {
                throw new ArgumentException("Id do álbum inválido!");
            }
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
        
        public static KeyValuePair<int,Disk> GetDisk(int id)
        {
            if (DB.DiskDB.TryGetValue(id, out var disk))
            {
                return new KeyValuePair<int, Disk>(id, disk);
            }
            else
            {
                throw new ArgumentException("Não há álbum com esse id");
            }
        }
        
        public static KeyValuePair<int,Disk> UpdateDisk(int id, Disk disk)
        {
            if (DB.DiskDB.TryGetValue(id, out var d))
            {
                DB.DiskDB[id] = disk;
                return new KeyValuePair<int, Disk>(id, disk);
            }
            else throw new ArgumentException("Id do álbum inválido");
        }
        
        public static Dictionary<int, Disk> Search(string search)
        {
            return DB.DiskDB.Where(disk =>
            {
                return SanitizeAndVerify(disk.Value.Title, search) ||  SanitizeAndVerify(disk.Value.Release, search) ||
                       SanitizeAndVerify(disk.Value.GroupName, search);
            }).ToDictionary(disk => disk.Key, disk => disk.Value);
        }

        public static void Remove(int id)
        {
            try
            {
                if (DB.DiskDB.TryGetValue(id, out var disk))
                {
                    DB.DiskDB.Remove(id);

                    foreach ( var aux in DB.MusicDB.Where(music => music.Value.IdDisk == id).ToList() ) {
                        DB.MusicDB.Remove(aux.Key);
                    }
                    
                }
                else
                {
                    throw new ArgumentException("Id do álbum inválido!");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private static bool SanitizeAndVerify(string str, string _str)
        {
            return str.ToLower().Normalize().Contains(_str.ToLower().Normalize());
        }
    }
}
