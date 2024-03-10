using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace TrainingExercise.Model
{
    public class Profile
    {
        public int Id { get; set; }

        //[Required, Display(Name = "User"), DataType(DataType.Text, ErrorMessage = "Invalid User"), Range(1, int.MaxValue, ErrorMessage = "Invalid User")]
        public required User  user { get; set; }
        public required int UserId { get; set; }

        [Required, Display(Name = "Name"), StringLength(100, MinimumLength = 3, ErrorMessage = "Minimum 3 and Maximum 100"), DataType(DataType.Text, ErrorMessage = "Invalid Name")]
        public required string Name { get; set; }
        [AllowNull, Display(Name = "Address"), StringLength(200, MinimumLength = 3, ErrorMessage = "Minimum 3 and Maximum 200"), DataType(DataType.Text, ErrorMessage = "Invalid Address")]
        public string Address { get; set; }

        [Required,DataType(DataType.Date, ErrorMessage = "Invalid Date"), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateOnly DateOfBirth { get; set; }

        [AllowNull, Display(Name = "Country")]
        public Country Country { get; set; }
        public int? CountryId { get; set; }

    }
}
