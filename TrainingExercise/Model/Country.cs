using System.ComponentModel.DataAnnotations;

namespace TrainingExercise.Model
{
    public class Country
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        [DataType(DataType.Text, ErrorMessage = "Name must be text"), StringLength(50, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 50 characters")]
        public required string Name { get; set; }
        [DataType(DataType.Text, ErrorMessage = "Code must be text"), StringLength(2, MinimumLength =2, ErrorMessage = "Code must be 2 characters long")]
        
        public required string Code { get; set; }
    }
}
