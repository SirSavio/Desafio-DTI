using System;
using System.Text.RegularExpressions;

namespace Desafio_DTI_CSharp.Validators
{
    public class MusicValidator
    {
        public bool Create(string title, string duration)
        {
            if (title == null || title == "" || title.Length == 0)
                throw new ArgumentException("Nome da música  inválido!");

            Regex regex = new Regex("^([0-9]?[0-9]):[0-5][0-9]$");

            if (!regex.IsMatch(duration)) throw new ArgumentException("Duração inválida!");
            
            if (duration == null || duration == "" || duration.Length == 0)
                throw new ArgumentException("Duração inválido!");

            return true;
        }
    }
}