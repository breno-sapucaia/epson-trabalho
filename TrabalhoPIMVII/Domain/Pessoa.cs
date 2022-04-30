using Domain;

namespace Domain
{
    public class Pessoa 
    {
        public Pessoa()
        {
            PessoaTelefone = new List<PessoaTelefone>();
        }
        public int PessoaId { get; set; }
        public string Nome { get; set; }
        public long CPF { get; set; }
        public int EnderecoId { get; set; }
        public Endereco Endereco { get; set; }
        public ICollection<PessoaTelefone> PessoaTelefone { get; set; }
    }
}