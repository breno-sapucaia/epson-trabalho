using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class Endereco
    {
        public int EnderecoId { get; set; }
        public string? Logradouro { get; set; }
        public int Numero { get; set; }
        public int CEP { get; set; }
        public string? Bairro { get; set; }
        public string? Cidade { get; set; }
        public string? Estado { get; set; }
    }
}
