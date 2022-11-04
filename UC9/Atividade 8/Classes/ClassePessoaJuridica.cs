using System.Text.RegularExpressions;
using Projetos_Senai.Interface;

namespace Projetos_Senai.Classes
{
    public class PessoaJuridica : Pessoa, IPessoaJuridica
    {
        public string? Cpnj { get; set; }
        
        public string? RazaoSocial { get; set;}
        public string? CaminhoPesooaJuridica { get; private set; } = "DataBase/PessoaJurídica";
        
        

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
            public void InserirDadosPessoaJuridica(PessoaJuridica pf)
            {
                Util.VerificaçãoFileDirectory(CaminhoPesooaJuridica!);

                string[] cvsPessoaJuridica = {$"{pf.Nome}, {pf.Cpnj}, {pf.Rendimento} "};
                
                File.AppendAllLines(CaminhoPesooaJuridica!, cvsPessoaJuridica);
            }
            public List<PessoaJuridica> LerArquivoPessoaJuridica(){

                List<PessoaJuridica> listaPessoaJuridica = new List<PessoaJuridica>();

                string[] linha = File.ReadAllLines(CaminhoPesooaJuridica!);
                
                foreach(string cadaLinha in linha){
                    string[] lerAtributo = cadaLinha.Split(",");
                    PessoaJuridica cadaAtributo = new PessoaJuridica();
                    cadaAtributo.Nome = lerAtributo[0];
                    cadaAtributo.Cpnj = lerAtributo[1];
                    cadaAtributo.Rendimento = float.Parse(lerAtributo[2]);

                listaPessoaJuridica.Add(cadaAtributo);
            }
            return listaPessoaJuridica;
            }
            
    }       


}