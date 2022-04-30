using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Telefone
    {

        public int TelefoneId { get; set; }
        public int Numero { get; set; }
        public int DDD { get; set; }
        public int TipoId { get; set; }
        public TipoTelefone Tipo { get; set; }
        public ICollection<PessoaTelefone> PessoaTelefone { get; set; }
    }
}
