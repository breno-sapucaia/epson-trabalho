using Domain;
using TrabalhoPIMVII.DataLayer;

namespace TrabalhoPIMVII.DAO
{
    public class PessoaDAO
    {
        private readonly Context _context;

        public PessoaDAO(Context context)
        {
            _context = context;
        }
        public bool Exclua(Pessoa p)
        {
            var pessoa = _context.Pessoas.FirstOrDefault(pessoa => pessoa.PessoaId == p.PessoaId);
            if(pessoa == null)
            {
                return false;
            }

            _context.Remove(pessoa);
            _context.SaveChanges();

            return true;
        }
        public Pessoa Consulte(long cpf)
        {

            var pessoa = _context.Pessoas.FirstOrDefault(pessoa => pessoa.CPF == cpf);
            return pessoa;
        }

        public bool Altere(Pessoa p)
        {
            var entity = _context.Pessoas.FirstOrDefault(pessoa => pessoa.PessoaId == p.PessoaId);
            if(entity == null)
            {
                return false;
            }

            _context.Entry(entity).CurrentValues.SetValues(p);
            return true;
        }

        public bool Insira (Pessoa p)
        {
            try
            {
            _context.Pessoas.Add(p);
            _context.SaveChanges();
            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }

        public void FecharConexao()
        {
            _context.Dispose();
        }
    }
}
