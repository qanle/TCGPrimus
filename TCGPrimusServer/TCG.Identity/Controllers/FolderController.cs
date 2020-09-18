using System;
using Microsoft.AspNetCore.Mvc;
using TCG.BusinessRules;

namespace TCG.Identity.Controllers
{
    [Route("api/folder")]
    [ApiController]
    public class FolderController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAllFolders()
        {
            try
            {
                var folders = new FolderRules().GetAll();

                return Ok(folders);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}", Name = "FolderById")]
        public IActionResult GetFolderById(int id)
        {
            try
            {
                var folder = new FolderRules().GetById(id);

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

        [HttpGet("{id}/workflow")]
        public IActionResult GetFolderGetByWorkflowId(int id)
        {
            try
            {
                var folder = new FolderRules().GetByWorkflowId(id);

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
