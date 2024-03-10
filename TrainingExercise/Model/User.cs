using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TrainingExercise.Model
{
    public class User
    {
        public int Id { get; set; }

        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Name can only contain letters"),
            DataType(DataType.Text, ErrorMessage = "Name can only contain letters"), Display(Name = "User Name"),
            StringLength(255, MinimumLength = 6, ErrorMessage = "Name must be between 6 and 255 characters long"),
            Description("Name of the user")]
        public required string UserName { get; set; }

        [PasswordPropertyText, 
            DataType(DataType.Password), Display(Name = "Password"),
            StringLength(255, MinimumLength = 8, ErrorMessage = "Password must be between 8 and 255 characters long")]
        public required string Password { get; set; }
        [DataType(DataType.EmailAddress, ErrorMessage = "Invalid Email Address"), Display(Name = "Email Address")]
        public required string Email { get; set; }
    }
}
