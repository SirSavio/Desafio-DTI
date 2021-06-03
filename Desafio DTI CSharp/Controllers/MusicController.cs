﻿using System.Collections.Generic;
using Desafio_DTI_CSharp.Models;
using Desafio_DTI_CSharp.Models.DAO;
using Desafio_DTI_CSharp.Validators;

namespace Desafio_DTI_CSharp.Controllers
{
    public class MusicController
    {
        public static void Print(Music music)
        {
            MusicDAO.Print(music);
        }

        public Dictionary<int, Music> GetMusicsDiskId(int idDisk, int idMusic)
        {
            return MusicDAO.GetMusicsByDiskId(idDisk);
        }

        public static Dictionary<int, Music> Search(string search)
        {
            return MusicDAO.Search(search);
        }

        public static KeyValuePair<int, Disk> GetMusicDisk(int id)
        {
            return MusicDAO.GetMusicDisk(id);
        }
        
        public static Dictionary<int, Music> GeneratePlaylist()
        {
            return MusicDAO.GeneratePlaylist();
        }
    }
}