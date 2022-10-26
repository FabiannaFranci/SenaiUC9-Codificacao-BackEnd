
using System.Globalization;
using Projetos_Senai.Classes;

Endereco novoEndPF = new Endereco();
novoEndPF.Logradouro = ("Rua São Luís");
novoEndPF.Numero = 60;
novoEndPF.Complemento = ("Ao lado da banca Jorge Amado");
novoEndPF.EnderecoComercial = false;


PessoaFisica novaPF = new PessoaFisica();

novaPF.Nome  = ("Fabi");
novaPF.Rendimento = 5000.00f;
novaPF.cpf = ("994.778.983.98");
novaPF.DataDeNascimento = new DateTime(2001, 12, 09);
novaPF.Endereco = novoEndPF;

PessoaFisica metodosPF = new PessoaFisica();

Console.WriteLine("==========Pessoa Física==========");

Console.WriteLine(@$"Nome: {novaPF.Nome}
CPF: {novaPF.cpf}
Data de Nascimento: {novaPF.DataDeNascimento}
Rendimento Mensal: {novaPF.Rendimento.ToString("C", new CultureInfo("pt-BR"))}
Endereço: {novaPF.Endereco.Logradouro} nº{novaPF.Endereco.Numero}
Complemento: {novaPF.Endereco.Complemento}
Comercial: {novaPF.Endereco.EnderecoComercial}
Imposto à ser pago: {metodosPF.PagarImposto(novaPF.Rendimento).ToString("C", new CultureInfo("pt-BR"))}
Maior de idade: {(metodosPF.ValidarDataNasc(novaPF.DataDeNascimento) ? "Sim" : "Não")}
Maior de idade - string: {(metodosPF.ValidarDataNasc("09/12/2001") ? "Sim" : "Não")}");

Endereco novoEndPJ = new Endereco();
novoEndPJ.Logradouro = ("Rua Antônio das Flores");
novoEndPJ.Numero = 83;
novoEndPJ.Complemento = ("De frente ao restaurante Flor De Liz");
novoEndPJ.EnderecoComercial = true;

PessoaJuridica novaPJ = new PessoaJuridica();
novaPJ.Cpnj = ("23.453.654/0001-34");
novaPJ.Nome = ("Carlo's Company");
novaPJ.Rendimento = 1000000.0f;
novaPJ.RazaoSocial = ("Carlo's Company Ltda");
novaPJ.Endereco = novoEndPJ;

PessoaJuridica metodosPJ = new PessoaJuridica();

Console.WriteLine("==========Pessoa Jurídica==========");

Console.Write(@$"Nome da Empresa: {novaPJ.Nome}
Razão Social: {novaPJ.RazaoSocial}
Rendimento Mensal: {novaPJ.Rendimento.ToString("C", new CultureInfo("pt-BR"))}
CPNJ: {novaPJ.Cpnj}
Endereço: {novaPJ.Endereco.Logradouro} nº{novaPJ.Endereco.Numero}
Complemento: {novaPJ.Endereco.Complemento}
Comercial: {novaPJ.Endereco.EnderecoComercial}
Imposto à ser pago: {metodosPJ.PagarImposto(novaPJ.Rendimento).ToString("C", new CultureInfo("pt-BR"))}");


