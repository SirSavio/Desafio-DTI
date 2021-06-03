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
        
        public static Dictionary<int, Disk> Search(string search)
        {
            return DiskDAO.Search(search);
        }
        
    }
}