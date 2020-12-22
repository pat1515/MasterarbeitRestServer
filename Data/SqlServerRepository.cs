using System.Collections.Generic;
using System.Linq;
using MasterarbeitRestServer.Models;
using Microsoft.EntityFrameworkCore;

namespace MasterarbeitRestServer.Data
{
    public class SqlServerRepository : IRepository
    {
        // Verweis auf den Datenbank Kontext
        private readonly ApiContext _context;

        // Konstruktor
        public SqlServerRepository(ApiContext context)
        {
            _context = context;
        }

        // Alle Autoren lesen
        public IEnumerable<Autor> GetAlleAutoren()
        {
            return _context.AUTOR; // entspricht Inhalt der Tabelle AUTOR
        }

        // Autor anhand von ID lesen
        public Autor GetAutorAusId(int id)
        {
            return _context.AUTOR.FirstOrDefault(a => a.ID == id);            
        }

        // Alle Bücher lesen
        public IEnumerable<Buch> GetAlleBuecher()
        {
            return _context.BUCH; // entspricht Inhalt der Tabelle BUCH
        }

        // Buch anhand von ID lesen
        public Buch GetBuchAusId(int id)
        {
            return _context.BUCH.FirstOrDefault(b => b.ID == id);
        }

        // Bücher des Autors anhand von dessen ID suchen
        public IEnumerable<Buch> GetBuecherVonAutor(int autor_id)
        {
            return _context.BUCH.Where(b => b.AUTOR_ID == autor_id);
        }
    }
}