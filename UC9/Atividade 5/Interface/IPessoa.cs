using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projetos_Senai.Interface
{
    public interface IPessoa
    {   ///Método para pagar imposto, paramêtro float rendimento
        float PagarImposto (float Rendimento);

        
    }
}