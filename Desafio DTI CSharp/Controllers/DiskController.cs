using System.Collections.Generic;
using System.Collections.ObjectModel;
using Desafio_DTI_CSharp.Models;
using Desafio_DTI_CSharp.Validators;

namespace Desafio_DTI_CSharp.Controllers
{
    public class DiskController
    {
        public static Disk Create(string title, string release, string groupName)
        {
            DiskValidator validator = new DiskValidator();
            validator.Create( title, release, groupName);

            Disk disk = new Disk(title, release, groupName);
            return disk;
        }

        public static Disk InsertMusicOnDisk(Music music, Disk disk)
        {
            return disk.InsertMusic(music);
        }
        
        public static List<Music> GetMusics(Disk disk)
        {
            return disk.GetMusic();
        }
    }
}