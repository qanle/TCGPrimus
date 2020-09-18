using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TCG.BusinessRules;
using TCG.Models;

namespace TCG.Identity.Controllers
{
    [Route("api/workflow")]
    [ApiController]
    public class WorkflowController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAllWorkflows()
        {
            try
            {
                var workflows= new WorkflowRules().GetAll();

                return Ok(workflows);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}", Name = "WorkflowById")]
        public IActionResult GetWorkflowById(int id)
        {
            try
            {
                var workflow = new WorkflowRules().GetById(id);

                if (workflow == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(workflow);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }


        [HttpPost]
        public IActionResult CreateWorkflow([FromBody] Workflow workflow)
        {
            try
            {
                if (workflow == null)
                {
                    return BadRequest("Workflow object is null");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }

                new WorkflowRules().CreateWorkflow(workflow);

                return CreatedAtRoute("WorkflowById", new { id = workflow.Id }, workflow);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateWorkflow(Guid id, [FromBody] Workflow workflow)
        {
            try
            {
                if (workflow == null)
                {
                    return BadRequest("Workflow object is null");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }
               new WorkflowRules().UpdateWorkflow(workflow);

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteWorkflow(int id)
        {
            try
            {
                
                new WorkflowRules().DeleteWorkflow(id);

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
