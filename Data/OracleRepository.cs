using System.Collections.Generic;
using System.Linq;
using MasterarbeitRestServer.Models;

namespace MasterarbeitRestServer.Data
{
    public class OracleRepository : IRepository
    {
        private readonly Context _context;

        public OracleRepository(Context context)
        {
            _context = context;
        }

        public IEnumerable<Autor> GetAllAuthors()
        {
            return _context.AUTOR.ToList();
        }

        public Autor GetAuthorById(int id)
        {
            return _context.AUTOR.FirstOrDefault(a => a.ID == id);
        }




        public IEnumerable<Buch> GetAllBooks()
        {
            return _context.BUCH.ToList();
        }



        public Buch GetBookById(int id)
        {
            return _context.BUCH.FirstOrDefault(b => b.ID == id);
        }



        public IEnumerable<Buch> GetBuchIDsVonAutor(int autor_id)
        {
            var buecher = _context.BUCH.Where(b => b.AUTOR_ID == autor_id);            

            return buecher;
        }
    }
}