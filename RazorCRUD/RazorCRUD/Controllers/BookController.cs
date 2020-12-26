using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RazorCRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorCRUD.Controllers
{
    [ApiController]
    [Route("api/Book")]
    public class BookController : Controller
    {
        private readonly BookContext _db;

        public BookController(BookContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Json(new { data = await _db.Books.ToListAsync() });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var bookFromDB = await _db.Books.FirstOrDefaultAsync(x => x.Id == id);
            if(bookFromDB == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }
            _db.Books.Remove(bookFromDB);
            await _db.SaveChangesAsync();
            return Json(new { success = true, message = "Deleted successfully" });

        }
    }
}
