using System;
using System.Collections.Generic;
using Desafio_DTI_CSharp.Validators;

namespace Desafio_DTI_CSharp.Models
{
    public class Disk
    {
        public string Title { get; }
        public string Release { get; }
        public string GroupName { get; }

        public Disk(string title, string release, string groupName)
        {
            DiskValidator validator = new DiskValidator();
            validator.Create(title, release, groupName);
            
            Title = title;
            Release = release;
            GroupName = groupName;
        }
    }
}