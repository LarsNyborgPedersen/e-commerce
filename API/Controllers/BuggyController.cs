using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class BuggyController : BaseApiController
    {
        [HttpGet("not-found")]
        public ActionResult getNoutFound() 
        {
            return NotFound();
        }

        [HttpGet("bad-request")]
        public ActionResult getBadRequest() 
        {
            return BadRequest(new ProblemDetails{Title = "This is a bad request"});
        }

        [HttpGet("unauthorized")]
        public ActionResult getUnauthorized() 
        {
            return Unauthorized();
        }

        [HttpGet("validation-error")]
        public ActionResult getValidationError() 
        {
            ModelState.AddModelError("Problem1", "This is the first error");
            ModelState.AddModelError("Problem2", "This is the second error");
            return ValidationProblem();
        }

        [HttpGet("server-error")]
        public ActionResult getServerError() 
        {
            throw new Exception("This is a server error");
        }
    }
}