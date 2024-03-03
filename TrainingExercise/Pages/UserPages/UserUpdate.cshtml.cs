using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TrainingExercise.Controller;
using TrainingExercise.Model;

namespace TrainingExercise.Pages.UserPages
{
    public class UserUpdateModel : PageModel
    {
        public int UserId { get; set; }
        [HttpGet]
        public void OnGet([FromQuery(Name = "id")] int userId)
        {
            UserId = userId;
        }
        [HttpPost]
        public IActionResult OnPost()
        {

            User user = new User()
            {
                Id =Int16.Parse (Request.Form["Id"]),
                Name = Request.Form["name"],
                Address = Request.Form["Address"],
                DateOfBirth = DateOnly.Parse (Request.Form["DateOfBirth"]),
            };
                UserController.UpdateUser(user);
            //return Redirect($"/UserPages/UserDetails?id={user.Id}") ;
            return Redirect("/UserPages/UserDetails?id=" + user.Id);
        }
    }
}
