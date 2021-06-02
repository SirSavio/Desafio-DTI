using System;
using System.IO;

namespace Desafio_DTI_CSharp.Validators
{
    public class DiskValidator
    {
        public bool Create(string title, string release, string groupName)
        {
            if (title == null || title == "" || title.Length == 0)
                throw new ArgumentException("Nome do álbum inválido!");
            if (groupName == null || groupName == "" || groupName.Length == 0)
                throw new ArgumentException("Nome do grupo inválido!");
            if (release == null || release == "" || release.Length != 4)
                throw new ArgumentException("Ano de lançamento inválido!");
            return true;
        }
    }
}