using Projetos_Senai.Interface;

namespace Projetos_Senai.Classes
{
    public class PessoaFisica : Pessoa, IPessoaFisica
    {
        public string? cpf { get; set; }
        public DateTime DataDeNascimento { get; set; }

        public override float PagarImposto (float Rendimento){
            if(Rendimento <= 1500){
                return 0 ;
            }
            else if (Rendimento >= 1501 && Rendimento <= 3500){
                return Rendimento * 0.02f;
            }
            else if (Rendimento >= 3501 && Rendimento <= 6000){
                return Rendimento * 0.035f;
            }
            else {
                return Rendimento * 0.05f;
            }
        }

        public bool ValidarDataNasc(DateTime DataDeNascimento)
        {
            DateTime dataAtual = DateTime.Today;
            double anos = (dataAtual - DataDeNascimento).TotalDays/365;
            if (anos >= 18){
                return true;
            }
            
             return false;
            
        }
        public bool ValidarDataNasc(string DataDeNascimento){
            DateTime dataConvertida;
            if(DateTime.TryParse(DataDeNascimento, out dataConvertida))
            {
                DateTime dataAtual = DateTime.Today;

                double anos = (dataAtual - dataConvertida).TotalDays/365;
                if (anos >= 18)
                {
                    return true;
                }
            }   
            return false;
            
            
        }
    }
} 