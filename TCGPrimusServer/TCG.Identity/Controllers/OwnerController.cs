﻿using System;
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

        //[HttpGet("{id}/account")]
        //public IActionResult GetOwnerWithDetails(Guid id)
        //{
        //    try
        //    {
        //        var owner = _repository.Owner.GetOwnerWithDetails(id);

        //        if (owner.IsEmptyObject())
        //        {
        //            _logger.LogError($"Owner with id: {id}, hasn't been found in db.");
        //            return NotFound();
        //        }
        //        else
        //        {
        //            _logger.LogInfo($"Returned owner with details for id: {id}");
        //            return Ok(owner);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError($"Something went wrong inside GetOwnerWithDetails action: {ex.Message}");
        //        return StatusCode(500, "Internal server error");
        //    }
        //}

        //[HttpPost]
        //public IActionResult CreateOwner([FromBody] Owner owner)
        //{
        //    try
        //    {
        //        if (owner == null)
        //        {
        //            return BadRequest("Owner object is null");
        //        }

        //        if (!ModelState.IsValid)
        //        {
        //            return BadRequest("Invalid model object");
        //        }

        //        _repository.Owner.CreateOwner(owner);

        //        return CreatedAtRoute("OwnerById", new { id = owner.Id }, owner);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError($"Something went wrong inside CreateOwner action: {ex.Message}");
        //        return StatusCode(500, "Internal server error");
        //    }
        //}

        //[HttpPut("{id}")]
        //public IActionResult UpdateOwner(Guid id, [FromBody] Owner owner)
        //{
        //    try
        //    {
        //        if (owner.IsObjectNull())
        //        {
        //            _logger.LogError("Owner object sent from client is null.");
        //            return BadRequest("Owner object is null");
        //        }

        //        if (!ModelState.IsValid)
        //        {
        //            _logger.LogError("Invalid owner object sent from client.");
        //            return BadRequest("Invalid model object");
        //        }

        //        var dbOwner = _repository.Owner.GetOwnerById(id);
        //        if (dbOwner.IsEmptyObject())
        //        {
        //            _logger.LogError($"Owner with id: {id}, hasn't been found in db.");
        //            return NotFound();
        //        }

        //        _repository.Owner.UpdateOwner(dbOwner, owner);

        //        return NoContent();
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError($"Something went wrong inside UpdateOwner action: {ex.Message}");
        //        return StatusCode(500, "Internal server error");
        //    }
        //}

        //[HttpDelete("{id}")]
        //public IActionResult DeleteOwner(Guid id)
        //{
        //    try
        //    {
        //        var owner = _repository.Owner.GetOwnerById(id);
        //        if (owner.IsEmptyObject())
        //        {
        //            _logger.LogError($"Owner with id: {id}, hasn't been found in db.");
        //            return NotFound();
        //        }

        //        if (_repository.Account.AccountsByOwner(id).Any())
        //        {
        //            _logger.LogError($"Cannot delete owner with id: {id}. It has related accounts. Delete those accounts first.");
        //            return BadRequest("Cannot delete owner. It has related accounts. Delete those accounts first.");
        //        }

        //        _repository.Owner.DeleteOwner(owner);

        //        return NoContent();
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError($"Something went wrong inside DeleteOwner action: {ex.Message}");
        //        return StatusCode(500, "Internal server error");
        //    }
        //}
    }
}
