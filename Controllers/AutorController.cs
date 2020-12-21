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
        private readonly IRepository _repository;

        private readonly string HostURL = "https://masterarbeitRestServer.azurewebsites.net/";

        public AutorController(IRepository repository)
        {
            _repository = repository;
        }



        [HttpGet]
        public ActionResult<IEnumerable<Autor>> GetAllAuthors()
        {
            var authors = _repository.GetAlleAutoren();              

            if (authors != null)
            {
                var authorsDTO = new List<AutorDTO>(); 

                foreach (var author in authors)
                {
                    authorsDTO.Add(MapAutor(author));
                } 

                foreach (var authorDTO in authorsDTO)
                {
                    CreateLinksForAuthor(authorDTO);
                } 

                return Ok(authorsDTO);
            }

            
       
            return NotFound();
        }


        [HttpGet("{id}", Name = nameof(GetAuthor))]
        public ActionResult<IEnumerable<Autor>> GetAuthor(int id)
        {
            var autor = _repository.GetAutorAusId(id);    

            
            if (autor != null)
            {
                var autorDTO = MapAutor(autor);            
                return Ok(CreateLinksForAuthor(autorDTO));
            }
       
            return NotFound();
            
        }


        private AutorDTO CreateLinksForAuthor(AutorDTO autor)
        {
            IEnumerable<Buch> buecher = _repository.GetBuecherVonAutor(autor.ID);

            foreach (Buch buch in buecher)
            {
                autor.Buecher.Add(HostURL + "api/books/" + buch.ID.ToString());
            }

            return autor;
        }



        private AutorDTO MapAutor(Autor autor)
        {
            AutorDTO dto = new AutorDTO();

            dto.ID = autor.ID;
            dto.LAND = autor.LAND;
            dto.LEBENSALTER = autor.ALTER;
            dto.NACHNAME = autor.NACHNAME;
            dto.ORT = autor.ORT;
            dto.VORNAME = autor.VORNAME;

            return dto;
        }


    }
}