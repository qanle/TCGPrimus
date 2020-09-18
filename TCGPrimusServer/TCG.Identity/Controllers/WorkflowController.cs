using System;
using Microsoft.AspNetCore.Mvc;
using TCG.BusinessRules;

namespace TCG.Identity.Controllers
{
    [Route("api/workflow")]
    [ApiController]
    public class WorkflowController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAllWorkflow()
        {
            try
            {
                var folders= new WorkflowRules().GetAll();

                return Ok(folders);
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
                var folder = new WorkflowRules().GetById(id);

                if (folder == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(folder);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

    }
}
