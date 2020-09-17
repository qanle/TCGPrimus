using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TCGPrimus.Contracts;
using TCGPrimus.Entities.Extensions;
using TCGPrimus.Entities.Models;

namespace TCGPrimus.Api.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;

        public AccountController(ILoggerManager logger, IRepositoryWrapper repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetAllAccounts()
        {
            try
            {
                var accounts = _repository.Account.GetAllAccounts();

                _logger.LogInfo($"Returned all accounts from database.");

                return Ok(accounts);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllAccounts action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}", Name = "AccountById")]
        public IActionResult GetAccountById(Guid id)
        {
            try
            {
                var account = _repository.Account.GetAccountById(id);

                if (account.IsEmptyObject())
                {
                    _logger.LogError($"Account with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned account with id: {id}");
                    return Ok(account);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAccountById action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }


        [HttpPost]
        public IActionResult CreateAccount([FromBody] Account account)
        {
            try
            {
                if (account.IsObjectNull())
                {
                    _logger.LogError("Account object sent from client is null.");
                    return BadRequest("Account object is null");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid account object sent from client.");
                    return BadRequest("Invalid model object");
                }

                _repository.Account.CreateAccount(account);

                return CreatedAtRoute("AccountById", new { id = account.Id }, account);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateAccount action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateAccount(Guid id, [FromBody] Account account)
        {
            try
            {
                if (account.IsObjectNull())
                {
                    _logger.LogError("Account object sent from client is null.");
                    return BadRequest("Account object is null");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid account object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var dbAccount = _repository.Account.GetAccountById(id);
                if (dbAccount.IsEmptyObject())
                {
                    _logger.LogError($"Account with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                _repository.Account.UpdateAccount(dbAccount, account);

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateAccount action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAccount(Guid id)
        {
            try
            {
                var account = _repository.Account.GetAccountById(id);
                if (account.IsEmptyObject())
                {
                    _logger.LogError($"Account with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                _repository.Account.DeleteAccount(account);

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside DeleteAccount action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
