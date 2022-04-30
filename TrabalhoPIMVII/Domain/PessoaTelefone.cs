using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class PessoaTelefone
    {
        public int PessoaId { get; set; }
        public Pessoa Pessoa { get; set; }

        public int TelefoneId { get; set; }
        public Telefone Telefone { get; set; }
    }
}
