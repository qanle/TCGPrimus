using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TCG.BusinessRules;
using TCG.Models;

namespace TCG.Identity.Controllers
{
    [Route("api/owner")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAllOwners()
        {
            try
            {
                var owners= new OwnerRules().GetAll();

                return Ok(owners);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}", Name = "OwnerById")]
        public IActionResult GetOwnerById(Guid id)
        {
            try
            {
                var owner = new OwnerRules().GetById(id);

                if (owner == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(owner);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}/account")]
        public IActionResult GetOwnerWithDetails(Guid id)
        {
            try
            {
                var owner = new OwnerRules().GetOwnerWithDetails(id);

                if (owner == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(owner);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public IActionResult CreateOwner([FromBody] Owner owner)
        {
            try
            {
                if (owner == null)
                {
                    return BadRequest("Owner object is null");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }

                new OwnerRules().CreateOwner(owner);

                return CreatedAtRoute("OwnerById", new { id = owner.Id }, owner);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateOwner(Guid id, [FromBody] Owner owner)
        {
            try
            {
                if (owner == null)
                {
                    return BadRequest("Owner object is null");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }
               new OwnerRules().UpdateOwner(owner);

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteOwner(Guid id)
        {
            try
            {
                var owner = new OwnerRules().GetById(id);
                if (owner ==null)
                {
                    return NotFound();
                }

                if (owner.Accounts.Any())
                {
                    return BadRequest("Cannot delete owner. It has related accounts. Delete those accounts first.");
                }

                new OwnerRules().DeleteOwner(owner);

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
