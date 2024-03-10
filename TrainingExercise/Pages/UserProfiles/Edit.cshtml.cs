using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TrainingExercise.DatabaseContext;
using TrainingExercise.Model;

namespace TrainingExercise.Pages.UserProfiles
{
    public class EditModel : PageModel
    {
        private readonly TrainingExercise.DatabaseContext.UsersDbContext _context;

        public EditModel(TrainingExercise.DatabaseContext.UsersDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Profile Profile { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profile =  await _context.Profiles.FirstOrDefaultAsync(m => m.Id == id);
            if (profile == null)
            {
                return NotFound();
            }
            Profile = profile;
           ViewData["CountryId"] = new SelectList(_context.Countries, "Id", "Name");
           ViewData["UserId"] = new SelectList(_context.Users, "Id", "Email");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Profile).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProfileExists(Profile.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ProfileExists(int id)
        {
            return _context.Profiles.Any(e => e.Id == id);
        }
    }
}
