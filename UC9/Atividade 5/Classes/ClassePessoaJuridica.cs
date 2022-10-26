using System.Text.RegularExpressions;
using Projetos_Senai.Interface;

namespace Projetos_Senai.Classes
{
    public class PessoaJuridica : Pessoa, IPessoaJuridica
    {
        public string? Cpnj { get; set; }
        
        public string? RazaoSocial { get; set;}

        public override float PagarImposto(float Rendimento)
        {
            if(Rendimento <= 3000){
                return Rendimento * 0.03f ;
            }
            else if (Rendimento >= 3001 && Rendimento <= 6000){
                return Rendimento * 0.05f;
            }
            else if (Rendimento >= 6001 && Rendimento <= 10000){
                return Rendimento * 0.07f;
            }
            else {
                return Rendimento * 0.09f;
            }
        }

        public bool ValidarCnpj(string Cnpj)
        {
             if(Regex.IsMatch(Cnpj, @"(^(\d{2}.\d{3}.\d{3}/\d{4}-\d{2})|(\d{14})$)"))
            {
                if(Cnpj.Length == 18)
                {
                    if(Cnpj.Substring(11, 4) == "0001")
                    {
                        return true;
                    }
                }
                else if(Cnpj.Length == 14)
                {
                    if(Cnpj.Substring(8, 4) == "0001")
                    {
                        return true;
                    }

                }
            } 
            
            return false;
        }
    }
}