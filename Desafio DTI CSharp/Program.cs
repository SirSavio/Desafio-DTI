using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Desafio_DTI_CSharp.Models;
using Desafio_DTI_CSharp.Controllers;
using Desafio_DTI_CSharp.Views;

namespace Desafio_DTI_CSharp
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            while (Display.Menu())
            {
                Console.Clear();
            }
        }
    }
}