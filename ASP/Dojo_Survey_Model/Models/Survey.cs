
namespace Dojo_Survey_Model.Models
{
    public class Survey
    {
        public string SurveyName { get; set; }
        public string SurveyLocation { get; set; }
        public string SurveyLanguage { get; set; }
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