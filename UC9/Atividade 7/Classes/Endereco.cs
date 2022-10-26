using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projetos_Senai.Classes
{
    public class Endereco
    {
        public string? Logradouro { get; set; }

        public string? Numero { get; set; }

        public string? Complemento { get; set; }
        
        public bool EnderecoComercial { get; set; }
        
    }
}