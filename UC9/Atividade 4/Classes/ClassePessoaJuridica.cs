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
            throw new NotImplementedException();
        }
    }
}