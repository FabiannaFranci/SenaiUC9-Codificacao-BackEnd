using Projetos_Senai.Interface;

namespace Projetos_Senai.Classes
{
    public abstract class Pessoa : IPessoa
    {
        public string? Nome { get; set; }

        public float Rendimento { get; set; }

        public Endereco? Endereco { get; set; }

        public abstract float PagarImposto(float Rendimento);
    
    }
}