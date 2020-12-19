using System.Collections.Generic;
using MasterarbeitRestServer.Data;
using MasterarbeitRestServer.DTO;
using MasterarbeitRestServer.Models;
using Microsoft.AspNetCore.Mvc;

namespace MasterarbeitRestServer.Controllers
{
    [ApiController]
    [Route("api/books")]
    public class BuchController : ControllerBase
    {

        
        private readonly IRepository _repository;

        public BuchController(IRepository repository)
        {
            _repository = repository;
        }


        [HttpGet]
        public ActionResult<IEnumerable<Buch>> GetAllBooks()
        {
            var books = _repository.GetAllBooks();              

            if (books != null)
            {
                var booksDTO = new List<BuchDTO>(); 

                foreach (var book in books)
                {
                    booksDTO.Add(MapBuch(book));
                } 

                //foreach (var authorDTO in authorsDTO)
                //{
                //    CreateLinksForAuthor(authorDTO);
                //} 

                return Ok(booksDTO);
            }


       
            return NotFound();
        }


        [HttpGet("{id}", Name = nameof(GetBook))]
        public ActionResult<IEnumerable<Autor>> GetBook(int id)
        {
            var buch = _repository.GetBookById(id);    

            if (buch != null)
            {
                var bookDTO = MapBuch(buch);    
                return Ok(bookDTO);       
                //return Ok(CreateLinksForAuthor(autorDTO));
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