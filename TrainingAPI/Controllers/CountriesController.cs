using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TrainingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        

       private static readonly string[] Countries = new[]
       {
            "India",
            "USA",
            "UK",
            "Japan",
            "China",
            "Russia",
            "Australia",
            "Canada",
            "Mexico",
            "Brazil",
            "Germany",
            "France",
            "Spain",
            "Italy",
            "Nepal",
            "Sri Lanka",    
        };

        [HttpGet]
        public IEnumerable<string> Get()
        {
            return Countries;
        }


    }
}
