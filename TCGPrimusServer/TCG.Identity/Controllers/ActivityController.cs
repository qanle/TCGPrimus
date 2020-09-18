using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TCG.BusinessRules;
using TCG.Models;

namespace TCG.Identity.Controllers
{
    [Route("api/activity")]
    [ApiController]
    public class ActivityController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAllActivities()
        {
            try
            {
                var activitys= new ActivityRules().GetAll();

                return Ok(activitys);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}", Name = "ActivityById")]
        public IActionResult GetActivityById(int id)
        {
            try
            {
                var activity = new ActivityRules().GetById(id);

                if (activity == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(activity);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
