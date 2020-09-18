using System;
using Microsoft.AspNetCore.Mvc;
using TCG.BusinessRules;
using TCG.Models;

namespace TCG.Identity.Controllers
{
    [Route("api/activityfield")]
    [ApiController]
    public class ActivityFieldController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAllActivityFields()
        {
            try
            {
                var activityFields= new ActivityFieldRules().GetAll();

                return Ok(activityFields);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}", Name = "ActivityFieldById")]
        public IActionResult GetActivityFieldById(int id)
        {
            try
            {
                var activityField = new ActivityFieldRules().GetById(id);

                if (activityField == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(activityField);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}/activity")]
        public IActionResult GetActivityFieldGetByActivityId(int id)
        {
            try
            {
                var activityField = new ActivityFieldRules().GetByActivityId(id);

                if (activityField == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(activityField);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public IActionResult CreateActivityField([FromBody] ActivityField activityField)
        {
            try
            {
                if (activityField == null)
                {
                    return BadRequest("ActivityField object is null");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }

                new ActivityFieldRules().CreateActivityField(activityField);

                return CreatedAtRoute("ActivityFieldById", new { id = activityField.Id }, activityField);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateActivityField(Guid id, [FromBody] ActivityField activityField)
        {
            try
            {
                if (activityField == null)
                {
                    return BadRequest("ActivityField object is null");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }
               new ActivityFieldRules().UpdateActivityField(activityField);

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteActivityField(int id)
        {
            try
            {

                new ActivityFieldRules().DeleteActivityField(id);

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
