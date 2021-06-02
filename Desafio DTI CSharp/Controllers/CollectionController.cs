using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Desafio_DTI_CSharp.Models;

namespace Desafio_DTI_CSharp.Controllers
{
    public static class CollectionController
    {
        public static void InsertDisk(Disk disk)
        {
            Collection.InsertDisk(disk);
        }
        
        public static List<Disk> GetDisks()
        {
           return Collection.GetDisks();
        }

        public static void UpdateDisk(Disk disk)
        {
            Collection.UpdateDisk(disk);
        }
        
        
    }
}