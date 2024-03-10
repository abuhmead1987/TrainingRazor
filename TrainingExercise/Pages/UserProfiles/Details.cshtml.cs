﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TrainingExercise.DatabaseContext;
using TrainingExercise.Model;

namespace TrainingExercise.Pages.UserProfiles
{
    public class DetailsModel : PageModel
    {
        private readonly TrainingExercise.DatabaseContext.UsersDbContext _context;

        public DetailsModel(TrainingExercise.DatabaseContext.UsersDbContext context)
        {
            _context = context;
        }

        public Profile Profile { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profile = await _context.Profiles.FirstOrDefaultAsync(m => m.Id == id);
            if (profile == null)
            {
                return NotFound();
            }
            else
            {
                Profile = profile;
            }
            return Page();
        }
    }
}
