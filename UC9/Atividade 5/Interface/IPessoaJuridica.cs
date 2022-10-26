using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projetos_Senai.Interface
{
    public interface IPessoaJuridica
    {
        bool ValidarCnpj (string Cnpj);
    }
}