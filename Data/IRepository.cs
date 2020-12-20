using System.Collections.Generic;
using MasterarbeitRestServer.Models;

namespace MasterarbeitRestServer.Data
{
    public interface IRepository
    {
        IEnumerable<Autor> GetAlleAutoren();
        
        Autor GetAutorAusId(int id); 


        IEnumerable<Buch> GetAlleBuecher();
        
        Buch GetBuchAusId(int id); 

        IEnumerable<Buch> GetBuecherVonAutor(int autor_id);
    }
}