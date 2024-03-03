using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TrainingExercise.Controller;

namespace TrainingExercise.Pages.UserPages
{
    public class UserDeleteModel : PageModel
    {
        public int UserId { get; set; }
        public void OnGet([FromQuery(Name = "id")] int userId)
        {
            UserId = userId;
            UserController.DeleteUser(userId);
            Response.Redirect("/Index");
        }
    }
}
