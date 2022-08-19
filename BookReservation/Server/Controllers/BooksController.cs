using AutoMapper;
using BookReservation.Data.Entities;
using BookReservation.Server.Services;
using BookReservation.Server.Services.Abstract;
using BookReservation.Shared.Dtos;
using BookReservation.Shared.Dtos.Book;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookReservation.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var bookList = await _bookService.GetAll<BookGetAllDto>();
            return Ok(new GResponse<List<BookGetAllDto>>("Success", bookList));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var book = await _bookService.GetSingle<BookGetByIdDto>(id);

            if (book == null)
                return NotFound(new GResponse<BookGetByIdDto>("Book not found"));
            else
                return Ok(new GResponse<BookGetByIdDto>("Success", book));
        }
    }
}
