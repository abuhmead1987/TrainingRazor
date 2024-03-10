using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TrainingExercise.DatabaseContext;
using TrainingExercise.Model;

namespace TrainingExercise.Pages.UserProfiles
{
    public class CreateModel : PageModel
    {
        private readonly TrainingExercise.DatabaseContext.UsersDbContext _context;

        public CreateModel(TrainingExercise.DatabaseContext.UsersDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["CountryId"] = new SelectList(_context.Countries, "Id", "Name");
        ViewData["UserId"] = new SelectList(_context.Users, "Id", "Email");
            return Page();
        }

        [BindProperty]
        public Profile Profile { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Profiles.Add(Profile);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
