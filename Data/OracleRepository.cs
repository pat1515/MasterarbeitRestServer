using System.Collections.Generic;
using System.Linq;
using MasterarbeitRestServer.Models;

namespace MasterarbeitRestServer.Data
{
    public class OracleRepository : IAutorRepository
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
    }
}