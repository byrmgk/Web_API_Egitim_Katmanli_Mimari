using Entities.DataTransferObjects;
using Entities.Exceptions;
using Entities.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    //TODO:  internal public yap.
    //TODO: Eklediğimiz classın api controller olmasını sağla.
    //TODO: Route'u belirle.
    //TODO:  Controller'ın ControllerBase den türet
    [ApiController]
    [Route("api/books")]

    //TODO: WEB API Controller'ı buraya taşı !!!!
    public class BooksController : ControllerBase
    {
        #region ServiceManager'ı kullanmak için IRepositoryManger kodlarını kapatıyoruz.

        ////TODO: Aşağıdaki kodun sonuna gelip Ctrl + . tuşlarına basın. Generate constructor seçeneğini seçin. Otomatik olarak oluşturulan constructor'ı kullanın.
        //private readonly IRepositoryManger _manager;

        //public BooksController(IRepositoryManger manager)
        //{
        //    _manager = manager;
        //}

        #endregion

        private readonly IServiceManager _manager;

        public BooksController(IServiceManager manager)
        {
            _manager = manager;
        }

        //TODO: GetAllBooks metodu ile tüm kitapları listeleyin
        [HttpGet]
        public async Task<IActionResult> GetAllBooksAsync()
        {
            #region ServiceManager Sonrası kapatılan kod !!!
            //var books = _manager.Book.GetAllBooks(false);
            #endregion

            var books = await _manager.BookService.GetAllBooksAsync(false);
            return Ok(books);
        }

        //TODO: İmzalı Get metodu oluşturalım.
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetOneBookAsync([FromRoute(Name = "id")] int id)
        {
            //TODO: Veri tabanına erişemiyebiliriz. Veri tabanı ayakta olmayabilir. Ağda sıkıntı olabilir. Bunun için try catch kullanıyoruz.

            #region ServiceManager Sonrası kapatılan kod !!!

            // var book = _manager
            //.Book
            //.GetOneBookById(id, false);
            #endregion
                  

            var book =  await _manager
                .BookService
                .GetOneBookByIdAsync(id, false);

            //TODO: Artık NotFound servise taşıyalım !!!. 
         
            return Ok(book);
        }

        //TODO: Post metodu oluşturalım.
        [HttpPost]
        public async Task<IActionResult> CreateOneBookAsync([FromBody] BookDtoForInsertion bookDto)
        {
            if (bookDto is null)
            {
                return BadRequest(); // 400
            }
            #region ServiceManager Sonrası kapatılan kod !!!
            //_manager.Book.CreateBook(book);
            //_manager.Save();
            #endregion

            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState); // 422

            var bookCreate = await _manager
                .BookService
                .CreateOneBookAsync(bookDto);

            return StatusCode(201, bookDto); // 201 
        }

        //TODO: Put metodu oluşturalım. (Güncelleme yapmak için)
        [HttpPut("{id:int}")]
        public async  Task<IActionResult> UpdateOneBookAsync([FromRoute(Name = "id")] int id, [FromBody] BookDtoUpdate bookDto)
        {

            //TODO: Güncelleme yapmak için gelen book var mı kontrol et.
            #region ServiceManager Sonrası kapatılan kod !!!
            //var bookToUpdate = _manager
            //    .Book
            //    .GetOneBookById(id, true);

            //if (bookToUpdate is null)
            //    return NotFound(); // 404
            ////TODO: Gelen Id ile parametredeki Id aynı mı bakıyoruz.
            //if (id != book.Id)
            //    return BadRequest(); // 400

            //bookToUpdate.Title = book.Title;
            //bookToUpdate.Price = book.Price;

            //_manager.Save();
            #endregion

            if (bookDto is null)
            {
                return BadRequest(); // 400
            }
            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState); // 422

            await _manager.BookService.UpdateOneBookAsync(id, bookDto, false);

            return NoContent(); // 204            
        }

        //TODO: Delete metodu oluşturalım. (Belirtileni sil)
        [HttpDelete("{id:int}")]
        public async  Task<IActionResult> DeleteOneBookAsync([FromRoute(Name = "id")] int id)
        {
            #region ServiceManager Sonrası kapatılan kod !!!
            //var bookToDelete = _manager
            //   .BookService
            //   .GetOneBookById(id, false);

            //if (bookToDelete is null)
            //    return NotFound(new
            //    {
            //        StatusCode = 404,
            //        message = $"Silinecek kitap id: {id} bulunamadı."
            //    }); // 404
            //var bookToDelete = _manager
            //                .Book
            //                .GetOneBookById(id, false);

            //_manager.Book.DeleteBook(bookToDelete);
            //_manager.Save();
            #endregion

            await _manager.BookService.DeleteOneBookAsync(id, true);
            return NoContent(); // 204          
        }

        //TODO: Put metodu oluşturalım.
        [HttpPatch("{id:int}")]
        public async  Task<IActionResult> PartialllyUpdateOneBookAsync([FromRoute(Name = "id")] int id, [FromBody] JsonPatchDocument<BookDtoUpdate> bookPatch)
        {
            if (bookPatch is null)            
                return BadRequest(); // 400
            

          var result = await _manager
                .BookService
                .GetOneBookForPatchAsync(id, false);

            bookPatch.ApplyTo(result.bookDtoUpdate, ModelState);

            TryValidateModel(result.bookDtoUpdate);

            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState); // 422

            await _manager.BookService.SaveChangesForPatchAsync(result.bookDtoUpdate, result.book);

            return NoContent(); // 204            
        }
    }
}
