using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TCGPrimus.Contracts;
using TCGPrimus.Entities.Extensions;
using TCGPrimus.Entities.Models;

namespace TCGPrimus.Api.Controllers
{
    [Route("api/tcg")]
    [ApiController]
    public class TcgPrimusController : ControllerBase
    {
        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;

        public TcgPrimusController(ILoggerManager logger, IRepositoryWrapper repository)
        {
            _logger = logger;
            _repository = repository;
        }

        #region MyRegion

        #endregion workflow

        #region content
        [HttpGet("{id}/contentbyid")]
        public IActionResult GetContentById(int id)
        {
            try
            {
                var content = _repository.Content.GetContentById(id);

                _logger.LogInfo($"Returned Content By Id from database.");

                if (content == null)
                {
                    _logger.LogError($"Content with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned Content with details for id: {id}");
                    return Ok(content);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside ContentById action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
        [HttpGet("{id}/contentsbyfolderid")]
        public IActionResult GetContentsByFolderId(int id)
        {
            try
            {
                var contents = _repository.Content.GetContentsByFolder(id);

                _logger.LogInfo($"Returned contents with folder for id: {id}");
                return Ok(contents);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetContentsByFolderId {id} action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
        #endregion content

        #region folder

        [HttpGet("{id}/folderbyid")]
        public IActionResult GetFolderById(int id)
        {
            try
            {
                var content = _repository.Folder.GetFolderById(id);

                _logger.LogInfo($"Returned Folder By Id from database.");

                if (content == null)
                {
                    _logger.LogError($"Folder with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned Folder with details for id: {id}");
                    return Ok(content);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside ContentById action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
        [HttpGet("folders")]
        public IActionResult GetAllFolder()
        {
            try
            {
                var contents = _repository.Folder.GetAllFolders();

                _logger.LogInfo($"Returned folders");
                return Ok(contents);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllFolder action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
        #endregion

        #region activity
        [HttpGet("{id}/activitybyid")]
        public IActionResult GetActivityById(int id)
        {
            try
            {
                var content = _repository.Activity.GetActivityById(id);

                _logger.LogInfo($"Returned Activity By Id from database.");

                if (content == null)
                {
                    _logger.LogError($"Activity with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned Activity with details for id: {id}");
                    return Ok(content);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside ActivityById action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
        [HttpGet("activities")]
        public IActionResult GetAllActivities()
        {
            try
            {
                var contents = _repository.Activity.GetAllActivities();

                _logger.LogInfo($"Returned Activities");
                return Ok(contents);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllActivities action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
        #endregion

        #region activity field

        [HttpGet("{id}/activityfieldsbyactivityid")]
        public IActionResult GetActivityFieldsByActivityId(int id)
        {
            try
            {
                var content = _repository.ActivityField.GetActivityFieldsByActivityId(id);

                _logger.LogInfo($"Returned ActivityField By Id from database.");

                if (content == null)
                {
                    _logger.LogError($"ActivityField with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned ActivityField with details for id: {id}");
                    return Ok(content);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetActivityFieldsByActivityId action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
        #endregion

    }
}
