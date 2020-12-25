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
        private readonly string HostURL = 
            "https://masterarbeitRestServer.azurewebsites.net/";

        // Konstruktor 
        public AutorController(IRepository repository)
        {
            _repository = repository;
        }
        
        [HttpGet]  // Route api/autoren
        public ActionResult<IEnumerable<Autor>> GetAlleAutoren()
        {
            // Alle Autoren aus dem Repository lesen
            var autoren = _repository.GetAlleAutoren();              

            if (autoren != null)
            {
                // Es wurden Autoren gefunden, Objekte werden in das DTO gemapped
                var autorenDTO = new List<AutorDTO>(); 

                foreach (var autor in autoren)                
                    autorenDTO.Add(MapAutor_CreateLinks(autor));
                 
                return Ok(autorenDTO);
            }

            // Nichts gefunden --> 404       
            return NotFound();
        }
        
        [HttpGet("{id}")]  // Route api/autoren/id  (z.B. api/autoren/7)
        public ActionResult<IEnumerable<Autor>> GetAutor(int id)
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

        [HttpGet("erste/{first:int}")] // Route api/autoren/erste/"first"  (z.B. api/autoren/erste/3)
        public ActionResult<IEnumerable<Autor>> GetErsteXAutoren(int first)
        {
            // Autor im Repository anhand von ID suchen
            var autoren = _repository.GetErsteXAutoren(first);  
            
            if (autoren != null)
            {
                // Es wurden Autoren gefunden, Objekte werden in das DTO gemapped
                var autorenDTO = new List<AutorDTO>(); 

                foreach (var autor in autoren)                
                    autorenDTO.Add(MapAutor_CreateLinks(autor));
                 
                return Ok(autorenDTO);
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
    }
}