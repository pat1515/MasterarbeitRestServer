using System.Collections.Generic;
using System.Linq;
using MasterarbeitRestServer.Models;
using Microsoft.EntityFrameworkCore;

namespace MasterarbeitRestServer.Data
{
    public class SqlServerRepository : IRepository
    {
        private readonly Context _context;

        public SqlServerRepository(Context context)
        {
            _context = context;
        }

        public IEnumerable<Autor> GetAlleAutoren()
        {
            return _context.AUTOR;
        }

        public Autor GetAutorAusId(int id)
        {
            var autor = _context.AUTOR.FirstOrDefault(a => a.ID == id);            

            return autor;
        }




        public IEnumerable<Buch> GetAlleBuecher()
        {
            return _context.BUCH.ToList();
        }



        public Buch GetBuchAusId(int id)
        {
            return _context.BUCH.FirstOrDefault(b => b.ID == id);
        }



        public IEnumerable<Buch> GetBuecherVonAutor(int autor_id)
        {
            var buecher = _context.BUCH.Where(b => b.AUTOR_ID == autor_id);            

            return buecher;
        }
    }
}