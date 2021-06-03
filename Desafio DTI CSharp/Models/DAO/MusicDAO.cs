using System;
using System.Collections.Generic;
using System.Linq;

namespace Desafio_DTI_CSharp.Models.DAO
{
    public static class MusicDAO
    {
        public static Dictionary<int, Music> GetMusicsByDiskId(int idDisk)
        {
            return DB.MusicDB.Where(music =>
            {
                return music.Value.IdDisk == idDisk;
            }).ToDictionary(music => music.Key, music => music.Value);
        }

        public static void Print(Music music)
        {
            string fav = music.IsFavorite ? "Sim" : "Não";
            Console.WriteLine("Titulo: " + music.Title);
            Console.WriteLine("Duração: " + music.Duration);
            Console.WriteLine("É favorita: " + fav);
        }
        public static Dictionary<int, Music> Search(string search)
        {
            return DB.MusicDB.Where(music =>
            {
                return SanitizeAndVerify(music.Value.Title, search) ||
                       SanitizeAndVerify(DB.DiskDB[music.Value.IdDisk].GroupName, search);
            }).ToDictionary(music => music.Key, disk => disk.Value);
        }

        public static KeyValuePair<int, Disk> GetMusicDisk(int id)
        {
            if (DB.MusicDB.TryGetValue(id, out var music))
            {
                return new KeyValuePair<int, Disk>(music.IdDisk, DB.DiskDB[music.IdDisk]);
            }
            else
            {
                throw new ArgumentException("Id do álbum inválido!");
            }
        }

        public static void Remove(int id)
        {
            if (DB.MusicDB.TryGetValue(id, out var music))
            {
                DB.MusicDB.Remove(id);
            }
            else
            {
                throw new ArgumentException("Id da música inválido!");
            }
        }

        public static Dictionary<int, Music> GeneratePlaylist()
        {

            int isFavoriteMaxTime = 0;
            int notFavoriteMaxTIme = 0;
            int maxTime = 3600;
            
            Dictionary<int, Music> favoriteMusics = DB.MusicDB.Where(music =>
                {
                    if (music.Value.IsFavorite) isFavoriteMaxTime += ConvertDurationToSeconds(music.Value.Duration);
                    return music.Value.IsFavorite;
                })
                .ToDictionary(music => music.Key, music => music.Value);
            
            Dictionary<int, Music> notFavoriteMusics = DB.MusicDB.Where(music =>
                {
                    if (!music.Value.IsFavorite) notFavoriteMaxTIme += ConvertDurationToSeconds(music.Value.Duration);
                    return !music.Value.IsFavorite;
                })
                .ToDictionary(music => music.Key, music => music.Value);

            
            if (isFavoriteMaxTime + notFavoriteMaxTIme <= 3600)
            {
                notFavoriteMusics.ToList().ForEach(music => favoriteMusics[music.Key] = music.Value);
                Console.WriteLine("Tempo de favorita: " + isFavoriteMaxTime);
                Console.WriteLine("Tempo de nao favorita: " + notFavoriteMaxTIme);
                return favoriteMusics;
            }else if (isFavoriteMaxTime < 1800)
            {
                maxTime -= isFavoriteMaxTime;
                Random rand = new Random();
                while (maxTime > 0)
                {
                    KeyValuePair<int, Music> music = notFavoriteMusics.ElementAt(rand.Next(0, notFavoriteMusics.Count));
                    favoriteMusics.Add(music.Key, music.Value);
                    maxTime -= ConvertDurationToSeconds(music.Value.Duration);

                    if (maxTime < 0)
                    {
                        favoriteMusics.Remove(music.Key);
                    }
                    notFavoriteMusics.Remove(music.Key);
                }
                Console.WriteLine("Tempo de favorita: " + isFavoriteMaxTime);
                Console.WriteLine("Tempo de nao favorita: " + notFavoriteMaxTIme);
                return favoriteMusics;
            }else if (notFavoriteMaxTIme < 1800)
            {
                maxTime -= notFavoriteMaxTIme;
                Random rand = new Random();
                while (maxTime > 0)
                {
                    KeyValuePair<int, Music> music = favoriteMusics.ElementAt(rand.Next(0, favoriteMusics.Count));
                    notFavoriteMusics.Add(music.Key, music.Value);
                    maxTime -= ConvertDurationToSeconds(music.Value.Duration);

                    if (maxTime < 0)
                    {
                        notFavoriteMusics.Remove(music.Key);
                    }
                    favoriteMusics.Remove(music.Key);
                }
                Console.WriteLine("Tempo de favorita: " + isFavoriteMaxTime);
                Console.WriteLine("Tempo de nao favorita: " + notFavoriteMaxTIme);
                return notFavoriteMusics;
            }
            else
            {
                Random rand = new Random();
                Dictionary<int, Music> playlist = new Dictionary<int, Music>();
                while (maxTime > 1800)
                {
                    KeyValuePair<int, Music> music = favoriteMusics.ElementAt(rand.Next(0, favoriteMusics.Count));
                    playlist.Add(music.Key, music.Value);
                    maxTime -= ConvertDurationToSeconds(music.Value.Duration);
                    
                    favoriteMusics.Remove(music.Key);
                }
                
                while (maxTime > 0)
                {
                    KeyValuePair<int, Music> music = notFavoriteMusics.ElementAt(rand.Next(0, notFavoriteMusics.Count));
                    playlist.Add(music.Key, music.Value);
                    maxTime -= ConvertDurationToSeconds(music.Value.Duration);

                    if (maxTime < 0)
                    {
                        playlist.Remove(music.Key);
                    }
                    notFavoriteMusics.Remove(music.Key);
                }
                Console.WriteLine("Tempo de favorita: " + isFavoriteMaxTime);
                Console.WriteLine("Tempo de nao favorita: " + notFavoriteMaxTIme);
                return playlist;
            }
        }
        
        private static bool SanitizeAndVerify(string str, string _str)
        {
            return str.ToLower().Normalize().Contains(_str.ToLower().Normalize());
        }

        private static int ConvertDurationToSeconds(string duration)
        {
            string[] tokens = duration.Split(':');
            return int.Parse(tokens[0]) * 60 + int.Parse(tokens[1]);
        }
        
    }
}