using System.Collections.Generic;
using TCG.BusinessRules;
using TCG.Models;
using TCG.Models.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TCG.Identity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogPostController : ControllerBase
    {
        //[Authorize(Roles = UserRoles.UnAuthorize)]
        //[HttpGet]
        //[Route("getall")]
        //public IEnumerable<BlogPost> GetAll()
        //{
        //    return new BlogPostRules().GetAll();
        //}


        //[Authorize(Roles = UserRoles.UnAuthorize)]
        //[HttpGet]
        //[Route("getbyid")]
        //public BlogPost GetById(int id)
        //{
        //    return new BlogPostRules().GetById(id);
        //}


        //[Authorize(Roles = UserRoles.Admin)]
        //[HttpPost]
        //[Route("create")]
        //public IActionResult Create(BlogPost blogPost)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var c = new BlogPostRules().Create(blogPost);
        //    return Ok(c);
        //}



        //[Authorize(Roles = UserRoles.Admin)]
        //[HttpDelete]
        //[Route("delete")]
        //public IActionResult Delete(int id)
        //{
        //    var blogPost = new BlogPostRules().Delete(id);

        //    return Ok(blogPost);
        //}
    }
}
