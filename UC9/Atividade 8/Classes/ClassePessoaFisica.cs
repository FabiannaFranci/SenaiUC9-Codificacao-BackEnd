using System.Text.RegularExpressions;
using Projetos_Senai.Interface;


namespace Projetos_Senai.Classes
{
    public class PessoaFisica : Pessoa, IPessoaFisica
    {
        public string? cpf { get; set; }
        public DateTime DataDeNascimento { get; set; }

        public string? CaminhoPessoaFisica { get; private set; } = "DataBase/PessoaFísica";

        public override float PagarImposto (float Rendimento)
        {
            if(Rendimento <= 1500)
            {
                return 0 ;
            }
            else if (Rendimento >= 1501 && Rendimento <= 3500)
            {
                return Rendimento * 0.02f;
            }
            else if (Rendimento >= 3501 && Rendimento <= 6000)
            {
                return Rendimento * 0.035f;
            }
            else 
            {
                return Rendimento * 0.05f;
            }
        }

        public bool ValidarDataNasc(DateTime DataDeNascimento)
        {
            DateTime dataAtual = DateTime.Today;
            double anos = (dataAtual - DataDeNascimento).TotalDays/365;
            if (anos >= 18)
            {
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
        public bool ValidarCpf(string Cpf)
        {
            this.cpf = Cpf;
            if(Regex.IsMatch(Cpf, @"(^(\d{3}.\d{3}.\d{3}-\d{2})$)" ))
            {
                if(Cpf.Length == 14){
                    return true;
                } 
            }
            else if(Regex.IsMatch(Cpf, @"(^(\d{11})$)" ))
            {
                if(Cpf.Length == 11){
                    return true;
                }
                
            }
            return false;
        }

    
        public void InserirDadosPessoaFisica(PessoaFisica novaPF)
        {
            Util.VerificaçãoFileDirectory(CaminhoPessoaFisica!);

            string[] listaCvsPessoaFisica =
            {@$"{novaPF.Nome}, {novaPF.DataDeNascimento}, {novaPF.cpf}, {novaPF.Rendimento}, {novaPF.Endereco!.Logradouro}, {novaPF.Endereco.Numero}, {novaPF.Endereco.Complemento}, {novaPF.Endereco.EnderecoComercial}"};

            File.AppendAllLines(CaminhoPessoaFisica!, listaCvsPessoaFisica);
        }
        public List<PessoaFisica> LerArquivoPessoaFisica()
        {
            List<PessoaFisica> listaPessoaFisica = new List<PessoaFisica>();

            Endereco novoEnd = new Endereco();

            string[] linha = File.ReadAllLines(CaminhoPessoaFisica!);


            foreach(string cadaLinha in linha)
            {
                string[] lerAtributos = cadaLinha.Split(",");
                
                PessoaFisica cadaAtributo = new PessoaFisica();
                Endereco cadaEndereco = new Endereco();

                cadaAtributo.Nome = lerAtributos[0];
                cadaAtributo.DataDeNascimento = Convert.ToDateTime(lerAtributos[1]);
                cadaAtributo.cpf = lerAtributos[2];
                cadaAtributo.Rendimento = float.Parse(lerAtributos[3]);

                cadaEndereco.Logradouro = lerAtributos[4];
                cadaEndereco.Numero = lerAtributos[5];
                cadaEndereco.Complemento = lerAtributos[6];
                cadaEndereco.EnderecoComercial = Convert.ToBoolean(lerAtributos[7]);
                
                cadaAtributo.Endereco = cadaEndereco;

                listaPessoaFisica.Add(cadaAtributo);
                
            }
        
            return listaPessoaFisica;
        }
    }
    
}