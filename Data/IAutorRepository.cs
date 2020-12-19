using System.Collections.Generic;
using MasterarbeitRestServer.Models;

namespace MasterarbeitRestServer.Data
{
    public interface IAutorRepository
    {
        IEnumerable<Autor> GetAllAuthors();
        
        Autor GetAuthorById(int id); 
    }
}