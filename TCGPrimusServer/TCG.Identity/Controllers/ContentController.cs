using System;
using Microsoft.AspNetCore.Mvc;
using TCG.BusinessRules;

namespace TCG.Identity.Controllers
{
    [Route("api/content")]
    [ApiController]
    public class ContentController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAllContents()
        {
            try
            {
                var contents = new ContentRules().GetAll();

                return Ok(contents);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}", Name = "ContentById")]
        public IActionResult GetContentById(int id)
        {
            try
            {
                var content = new ContentRules().GetById(id);

                if (content == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(content);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}/folder")]
        public IActionResult GetContentGetByFolderId(int id)
        {
            try
            {
                var content = new ContentRules().GetByFolderId(id);

                if (content == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(content);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

    }
}
