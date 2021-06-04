using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Desafio_DTI_CSharp.Models;
using Desafio_DTI_CSharp.Models.DAO;

namespace Desafio_DTI_CSharp.Controllers
{
    public static class DiskController
    {
        public static KeyValuePair<int, Disk> Create(Disk disk)
        {
            return DiskDAO.Create(disk);
        }
        
        public static Dictionary<int, Music> GetFavoriteMusics(int id)
        {
            return DiskDAO.GetFavoriteMusicsInDisk(id);
        }
        
        public static Dictionary<int, Music> GetMusics(int id)
        {
            return DiskDAO.GetMusicsInDisk(id);
        }
        
        public static void InsertMusic(int id, Music music)
        {
            DiskDAO.InsertMusicInDisk(id, music);
        }

        public static void Print(Disk disk)
        {
            DiskDAO.Print(disk);
        }

        public static KeyValuePair<int, Disk> GetDisk(int id)
        {
            return DiskDAO.GetDisk(id);
        }
        
        public static Dictionary<int, Disk> Search(string search)
        {
            if (search.Length == 0) throw new ArgumentException("Informe o que deseja buscar!");
            return DiskDAO.Search(search);
        }

        public static void RemoveDisk(int id)
        {
            DiskDAO.Remove(id);
        }

        public static Dictionary<int, Disk> GetAllDisks()
        {
            return DiskDAO.GetAllDisk();
        }

        public static KeyValuePair<int, Disk> UpdateDisk(int id, Disk disk)
        {
            return DiskDAO.UpdateDisk(id, disk);
        }
        
    }
}