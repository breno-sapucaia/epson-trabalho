// See https://aka.ms/new-console-template for more information
using Domain;
using TrabalhoPIMVII.DAO;
using TrabalhoPIMVII.DataLayer;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var contextOptions = new DbContextOptionsBuilder<Context>()
    .UseSqlServer(@"Server=localhost\\SQLEXPRESS01;Database=master;Trusted_Connection=True;")
    .Options;
using (var context = new Context(contextOptions))
{
    var pessoaDAO = new PessoaDAO(context);
    var pessoa = new Pessoa()
    {
        Nome = "Epson",
        CPF = 03596199085,
        PessoaTelefone = new List<PessoaTelefone>()
        {
            new PessoaTelefone()
            {
                Telefone = new Telefone() {
                    Numero = 941231358,
                    DDD = 11,
                    Tipo = new TipoTelefone()
                    {
                        Tipo = "smartphone"
                    }
                }
            }
        },
        Endereco = new Endereco(){
            Bairro = "Nobre",
            CEP = 05282333,
            Cidade = "SP",
            Estado = "São Paulo",
            Logradouro = "Na rua de Baixo",
            Numero = 999,
        }
        
    };        
    try
    {
        var msg = pessoaDAO.Insira(pessoa);
        Console.WriteLine(msg);

    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
        Console.WriteLine(ex?.InnerException?.Message);
    }
    finally
    {
        pessoaDAO.FecharConexao();
    }

}



