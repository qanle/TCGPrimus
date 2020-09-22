using System;
using Microsoft.AspNetCore.Mvc;
using TCG.BusinessRules;
using TCG.BusinessRules.ExtendedModels;
using TCG.Models;

namespace TCG.Identity.Controllers
{
    [Route("api/workflowitem")]
    [ApiController]
    public class WorkflowItemController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAllWorkflowItems()
        {
            try
            {
                var workflowItems = new WorkflowItemRules().GetAll();

                return Ok(workflowItems);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}", Name = "WorkflowByItemId")]
        public IActionResult GetWorkflowByItemId(int id)
        {
            try
            {
                var workflowItem = new WorkflowItemRules().GetById(id);

                if (workflowItem == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(workflowItem);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }


        [HttpPost]
        public IActionResult CreateWorkflowItem([FromBody] WorkflowitemExtended workflowItem)
        {
            try
            {
                if (workflowItem == null)
                {
                    return BadRequest("Workflow object is null");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }

                new WorkflowItemRules().CreateWorkflowItem(workflowItem);
                return Ok();
                //return CreatedAtRoute("CreateWorkflowItem", new { id = workflowItem.Id }, workflowItem);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut]
        public IActionResult UpdateWorkflowItem([FromBody] WorkflowItem workflowItem)
        {
            try
            {
                if (workflowItem == null)
                {
                    return BadRequest("WorkflowItem object is null");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }
               new WorkflowItemRules().UpdateWorkflowItem(workflowItem);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteWorkflowItem(int id)
        {
            try
            {
                
                new WorkflowItemRules().DeleteWorkflowItem(id);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
