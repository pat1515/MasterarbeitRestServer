using System.Collections.Generic;
using System.Linq;
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
        private readonly IAutorRepository _autorRepository;

        public AutorController(IAutorRepository autorRepository)
        {
            _autorRepository = autorRepository;
        }



        [HttpGet]
        public ActionResult<IEnumerable<Autor>> GetAllAuthors()
        {
            var authors = _autorRepository.GetAllAuthors();  

            

            if (authors != null)
            {
                var authorsDTO = new List<AutorDTO>(); 

                foreach (var author in authors)
                {
                    authorsDTO.Add(MapAutor(author));
                } 

                authorsDTO.Select(a => CreateLinksForAuthor(a));


                return Ok(authorsDTO);
            }


       
            return NotFound();
        }


        [HttpGet("{id}", Name = nameof(GetAuthor))]
        public ActionResult<IEnumerable<Autor>> GetAuthor(int id)
        {
            var autor = _autorRepository.GetAuthorById(id);    

            if (autor != null)
            {
                var autorDTO = MapAutor(autor);            
                return Ok(CreateLinksForAuthor(autorDTO));
            }
       
            return NotFound();
        }


        private AutorDTO CreateLinksForAuthor(AutorDTO autor)
        {
            

            return autor;
        }



        private AutorDTO MapAutor(Autor autor)
        {
            AutorDTO dto = new AutorDTO();

            dto.ID = autor.ID;
            dto.LAND = autor.LAND;
            dto.LEBENSALTER = autor.LEBENSALTER;
            dto.NACHNAME = autor.NACHNAME;
            dto.ORT = autor.ORT;
            dto.VORNAME = autor.VORNAME;

            return dto;
        }


    }
}