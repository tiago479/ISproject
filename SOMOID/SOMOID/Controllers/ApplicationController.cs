using Microsoft.AspNetCore.Mvc;
using SOMOID.core.Interfaces;
using SOMOID.core.Models;

namespace SOMOID.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ApplicationController : ControllerBase
    {
        private readonly ISomoidDB somoidDB;
        public ApplicationController(ISomoidDB somoidDB)
        {
            this.somoidDB=somoidDB;
        }

        [HttpPost]
        public IActionResult PostApplication(Application application)
        {
            //validations
            if(application == null)
            {
                return BadRequest("no content on the create application");
            }
            var app = new Application();
            
            app = somoidDB.CreateApplication(application);

            return Ok(app);
        }
    }
}
