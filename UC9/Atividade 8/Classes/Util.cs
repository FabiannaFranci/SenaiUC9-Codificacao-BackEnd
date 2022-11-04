using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projetos_Senai.Classes
{
    static class Util
    {
        public static void MetodosUteis(string texto, int tempo, int quantidade){
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(texto);
        for (int i = 0; i < quantidade; i++)
        {
            Console.Write(".");
            Thread.Sleep(tempo);
        }
            Console.ResetColor();
        }
        public static void VerificaçãoFileDirectory(string caminho)
        {
            string pasta = caminho.Split("/")[0];
            if(!Directory.Exists(pasta))
            {
                Directory.CreateDirectory(pasta);
            }
            if(!File.Exists(caminho))
            {
                using(File.Create(caminho)){}
            }
        }
    }   

    
}