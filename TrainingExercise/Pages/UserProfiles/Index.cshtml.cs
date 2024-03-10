using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using TrainingExercise.Model;

namespace TrainingExercise.Pages.UserProfiles
{
    public class IndexModel : PageModel
    {
        private readonly TrainingExercise.DatabaseContext.UsersDbContext _context;

        public IndexModel(TrainingExercise.DatabaseContext.UsersDbContext context)
        {
            _context = context;
        }

        public IList<Profile> Profile { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Profile = await _context.Profiles
                .Include(p => p.Country)
                .Include(p => p.user).ToListAsync();
        }
    }
}
