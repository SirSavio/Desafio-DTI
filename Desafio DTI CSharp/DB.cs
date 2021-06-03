using System.Collections.Generic;
using Desafio_DTI_CSharp.Models;

namespace Desafio_DTI_CSharp
{
    public static class DB
    {
        public static Dictionary<int, Disk> DiskDB = new Dictionary<int, Disk>();
        public static Dictionary<int, Music> MusicDB = new Dictionary<int, Music>();
        
        public static int IndexDisk = 0;
        public static int IndexMusic = 0;
    }
}