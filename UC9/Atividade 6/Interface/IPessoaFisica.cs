using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projetos_Senai.Interface
{
    public interface IPessoaFisica
    {
        bool ValidarDataNasc(DateTime DataDeNascimento);
    }
}