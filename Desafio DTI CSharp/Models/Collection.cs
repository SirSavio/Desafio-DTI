using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Desafio_DTI_CSharp.Models
{
    public static class Collection
    {
        private static List<Disk> disks = new List<Disk>();

        public static void InsertDisk(Disk disk)
        {
            disks.Add(disk);
        }

        public static List<Disk> GetDisks()
        {
            return disks;
        }

        public static List<Music> GetDiskMusic(string title)
        {
            List<Disk> disks = GetDisks();

            Disk selected = disks.Find(d => d.Title == title);
            return selected.GetMusic();
        }

        public static void UpdateDisk(Disk disk)
        {
            int index = disks.IndexOf(disk);
            if(index != -1)
                disks[index] = disk;
        }
    }
}