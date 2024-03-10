using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TrainingExercise.Controller;
using TrainingExercise.Model;

namespace TrainingExercise.Pages.UserPages
{
    public class UserDetailsModel : PageModel
    {
        public int UserId { get; set; }
        public User? user;
        public string _data;
        public void OnGet(int id, string data)
        {
            UserId=id;
            user = UserController.GetUser(UserId);
            _data = data;
        }       
    }
}
