using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TrainingExercise.Controller;
using TrainingExercise.Model;

namespace TrainingExercise.Pages.UserPages
{
    public class UserCreateModel : PageModel
    {
        public void OnGet()
        {
        }
        [HttpPost]
        public IActionResult OnPost()
        {

            //User user = new User()
            //{
            //    Name = Request.Form["name"],
            //    Address = Request.Form["Address"],
            //    DateOfBirth = DateOnly.Parse(Request.Form["DateOfBirth"]),
            //};
            //UserController.AddUser(user);
            return Redirect("/Index");
        }
    }
}
