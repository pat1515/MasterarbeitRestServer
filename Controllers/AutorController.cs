using System.Collections.Generic;
using System.Linq;
using System.Web;
using MasterarbeitRestServer.Data;
using MasterarbeitRestServer.DTO;
using MasterarbeitRestServer.Models;
using Microsoft.AspNetCore.Mvc;

namespace MasterarbeitRestServer.Controllers
{
    [ApiController]
    [Route("api/authors")]
    public class AutorController : ControllerBase
    {
        // Verweis auf das Repository
        private readonly IRepository _repository;

        // URL des Hosts, wird für die Erstellung der Links benötigt
        private readonly string HostURL = "https://masterarbeitRestServer.azurewebsites.net/";

        // Konstruktor 
        public AutorController(IRepository repository)
        {
            _repository = repository;
        }


        // Route api/authors
        [HttpGet]
        public ActionResult<IEnumerable<Autor>> GetAllAuthors()
        {
            // Alle Autoren aus dem Repository lesen
            var authors = _repository.GetAlleAutoren();              

            if (authors != null)
            {
                // Es wurden Autoren gefunden, Objekte werden in das DTO gemapped
                var authorsDTO = new List<AutorDTO>(); 

                foreach (var author in authors)                
                    authorsDTO.Add(MapAutor(author));                

                // Für alle Autoren werden die Links erstellt
                foreach (var authorDTO in authorsDTO)                
                    CreateLinksForAuthor(authorDTO);
                 
                return Ok(authorsDTO);
            }

            // Nichts gefunden --> 404       
            return NotFound();
        }

        // Autor auf DTO mappen
        private AutorDTO MapAutor(Autor autor)
        {
            AutorDTO dto = new AutorDTO();
            dto.ID = autor.ID;
            dto.LAND = autor.LAND;
            dto.LEBENSALTER = autor.ALTER;
            dto.NACHNAME = autor.NACHNAME;
            dto.ORT = autor.ORT;
            dto.VORNAME = autor.VORNAME;
            dto.GROESSE = autor.GROESSE;
            return dto;
        }

        // Route api/authors/id
        // z.B. api/authors/7
        [HttpGet("{id}", Name = nameof(GetAuthor))]
        public ActionResult<IEnumerable<Autor>> GetAuthor(int id)
        {
            // Autor im Repository anhand von ID suchen
            var autor = _repository.GetAutorAusId(id);  
            
            if (autor != null)
            {
                // Autor gefunden --> Mappen und Links erzeugen
                var autorDTO = MapAutor(autor);            
                return Ok(CreateLinksForAuthor(autorDTO));
            }
       
            // Nichts gefunden --> 404   
            return NotFound();            
        }

        // Links für den Autor erzeugen
        private AutorDTO CreateLinksForAuthor(AutorDTO autor)
        {
            // Zuerst alle Bücher des Autors suchen
            IEnumerable<Buch> buecher = _repository.GetBuecherVonAutor(autor.ID);

            // Links erstellen und in Liste speichern
            foreach (Buch buch in buecher)            
                autor.Buecher.Add(HostURL + "api/books/" + buch.ID.ToString());            

            return autor;
        }


    }
}