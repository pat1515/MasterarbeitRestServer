using System.Collections.Generic;
using MasterarbeitRestServer.Models;

namespace MasterarbeitRestServer.Data
{
    public interface IRepository
    {
        // Alle Autoren zurückgeben
        IEnumerable<Autor> GetAlleAutoren();
        
        // Einen bestimmten Autor anhand der ID (Primärschlüssel) zurückgeben
        Autor GetAutorAusId(int id); 

        // Alle Bücher zurückgeben
        IEnumerable<Buch> GetAlleBuecher();
        
        // Ein bestimmtes Buch anhand der ID (Primärschlüssel) zurückgeben
        Buch GetBuchAusId(int id);
    }
}