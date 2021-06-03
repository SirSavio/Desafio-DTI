using System.Collections.Generic;

namespace Desafio_DTI_CSharp.Models.DAO
{
    public class CollectionDAO
    {
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