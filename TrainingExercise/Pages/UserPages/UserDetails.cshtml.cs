using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TrainingExercise.Pages.UserPages
{
    public class UserDetailsModel : PageModel
    {
        public int UserId { get; set; }
        public void OnGet([FromQuery(Name = "id")] int userId)
        {
            UserId=userId;
        }
    }
}
