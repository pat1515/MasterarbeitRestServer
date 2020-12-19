using System.Collections.Generic;
using MasterarbeitRestServer.Models;

namespace MasterarbeitRestServer.Data
{
    public interface IRepository
    {
        IEnumerable<Autor> GetAllAuthors();
        
        Autor GetAuthorById(int id); 


        IEnumerable<Buch> GetAllBooks();
        
        Buch GetBookById(int id); 

        IEnumerable<Buch> GetBuchIDsVonAutor(int autor_id);
    }
}