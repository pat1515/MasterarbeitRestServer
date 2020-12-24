using System.Collections.Generic;
using MasterarbeitRestServer.Data;
using MasterarbeitRestServer.DTO;
using MasterarbeitRestServer.Models;
using Microsoft.AspNetCore.Mvc;

namespace MasterarbeitRestServer.Controllers
{
    [ApiController]
    [Route("api/buecher")]
    public class BuchController : ControllerBase
    {        
        private readonly IRepository _repository;

        public BuchController(IRepository repository)
        {
            _repository = repository;
        }


        [HttpGet]
        public ActionResult<IEnumerable<Buch>> GetAlleBuecher()
        {
            var books = _repository.GetAlleBuecher();              

            if (books != null)
            {
                var booksDTO = new List<BuchDTO>(); 

                foreach (var book in books)
                {
                    booksDTO.Add(MapBuch(book));
                } 

                return Ok(booksDTO);
            }
       
            return NotFound();
        }


        [HttpGet("{id}")]
        public ActionResult<IEnumerable<Autor>> GetBuchAusId(int id)
        {
            var buch = _repository.GetBuchAusId(id);    

            if (buch != null)
            {
                var bookDTO = MapBuch(buch);    
                return Ok(bookDTO);       
            }
       
            return NotFound();
        }



         private BuchDTO MapBuch(Buch buch)
        {
            BuchDTO dto = new BuchDTO();

            dto.ID = buch.ID;
            dto.AUFLAGE = buch.AUFLAGE;
            dto.AUTOR_ID = buch.AUTOR_ID;
            dto.DRUCKORT = buch.DRUCKORT;
            dto.ERSCHEINUNGSDATUM = buch.ERSCHEINUNGSDATUM;
            dto.ISBN = buch.ISBN;
            dto.SPRACHE = buch.SPRACHE;
            dto.TITEL = buch.TITEL;
            dto.VERLAG = buch.VERLAG;
            
            return dto;
        }
    }
}