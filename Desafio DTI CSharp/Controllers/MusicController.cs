using Desafio_DTI_CSharp.Models;
using Desafio_DTI_CSharp.Validators;

namespace Desafio_DTI_CSharp.Controllers
{
    public class MusicController
    {
        public static Music Create(string title, string duration, bool isFavorite)
        {
            MusicValidator validator = new MusicValidator();
            validator.Create( title, duration);

            Music music = new Music(title, duration, isFavorite);
            return music;
        }
    }
}