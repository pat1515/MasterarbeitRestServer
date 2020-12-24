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
    [Route("api/autoren")]
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
                    authorsDTO.Add(MapAutor_CreateLinks(author));
                 
                return Ok(authorsDTO);
            }

            // Nichts gefunden --> 404       
            return NotFound();
        }

        // Autor auf DTO mappen & Links erzeugen
        private AutorDTO MapAutor_CreateLinks(Autor autor)
        {
            AutorDTO dto = new AutorDTO();
            dto.ID = autor.ID;
            dto.LAND = autor.LAND;
            dto.LEBENSALTER = autor.ALTER;
            dto.NACHNAME = autor.NACHNAME;
            dto.ORT = autor.ORT;
            dto.VORNAME = autor.VORNAME;
            dto.GROESSE = autor.GROESSE;

            // alle Bücher des Autors suchen
            IEnumerable<Buch> buecher = autor.BUECHER;

            // Links erstellen und in Liste speichern
            foreach (Buch buch in buecher)            
                dto.BuchLinks.Add(HostURL + "api/buecher/" + buch.ID.ToString());          
    
            return dto;
        }

        // Route api/authors/id
        // z.B. api/authors/7
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<Autor>> GetAuthor(int id)
        {
            // Autor im Repository anhand von ID suchen
            var autor = _repository.GetAutorAusId(id);  
            
            if (autor != null)
            {
                // Autor gefunden --> Mappen und Links erzeugen
                var autorDTO = MapAutor_CreateLinks(autor);            
                return Ok(autorDTO);
            }
       
            // Nichts gefunden --> 404   
            return NotFound();            
        }


    }
}