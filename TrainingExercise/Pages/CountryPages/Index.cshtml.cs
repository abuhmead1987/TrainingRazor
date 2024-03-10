using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using TrainingExercise.Model;

namespace TrainingExercise.Pages.CountryPages
{
    public class IndexModel : PageModel
    {
        private readonly TrainingExercise.DatabaseContext.UsersDbContext _context;

        public IndexModel(TrainingExercise.DatabaseContext.UsersDbContext context)
        {
            _context = context;
        }

        public IList<Country> Country { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Country = await _context.Countries.ToListAsync();
        }
    }
}
