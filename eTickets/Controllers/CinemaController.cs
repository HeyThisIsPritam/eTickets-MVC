using eTickets.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Controllers
{
    public class CinemaController : Controller
    {
        private readonly AppDBContext _context;
        public CinemaController(AppDBContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var cinema = await _context.Cinemas.ToListAsync();
            return View(cinema);
        }
    }
}
