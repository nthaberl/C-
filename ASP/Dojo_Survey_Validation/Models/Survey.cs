// Let's us use text decorators
using System.ComponentModel.DataAnnotations;

namespace Dojo_Survey_Validation.Models
{
    public class Survey
    {
        [Display(Name = "Your Name:")]
        [MinLength(2, ErrorMessage = "Please provide your full first name")]
        [Required]

        public string SurveyName { get; set; }


        [Display(Name = "Your Location:")]
        [Required]
        public string SurveyLocation { get; set; }


        [Display (Name = "Your Favorite Language:")]
        [Required]
        public string SurveyLanguage { get; set; }


        [Display (Name = "Comments? (optional)")]
        [MinLength (20, ErrorMessage = "If you're leaving a commment make sure it's at least 20 charcters long :o)")]
        public string SurveyComments { get; set; }
        
        

        // utlizing building a constructor in the controller
        // public Survey(string name, string location, string language, string comments)
        // {
        //     SurveyName = name;
        //     SurveyLocation = location;
        //     SurveyLanguage = language;
        //     SurveyComments = comments;
        // }
    }
}