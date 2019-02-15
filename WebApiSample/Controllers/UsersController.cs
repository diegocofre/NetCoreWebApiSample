using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using WebapiSample.API.Services;

namespace WebapiSample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _usrService;
        private readonly ILogger _log;

        public UsersController(IUserService userService, ILogger<UsersController> log)
        {
            _usrService = userService;
            _log = log;
        }

        // GET api/values
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IList<UserDTO>))]
        public IActionResult GetPaginated(int page, int rows)
        {
            try
            {
                return Ok(_usrService.GetAll(page, rows));
            }
            catch (Exception ex)
            {
                _log.LogError(ex, "Error");
                return StatusCode(500);
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(UserDTO))]
        [ProducesResponseType(404)]
        public IActionResult GetById(int id)
        {
            try
            {
                var retVal = _usrService.GetbyIdValue(id);

                if (retVal == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(retVal);
                }
            }
            catch (Exception ex)
            {
                _log.LogError(ex, "Error");
                return StatusCode(500);
            }
        }

        [HttpPut]
        [ProducesResponseType(200, Type = typeof(UserDTO))]
        [ProducesResponseType(404)]
        public IActionResult Update([FromBody]  UserDTO user)
        {
            try
            {
                var retVal = _usrService.Update(user);

                if (retVal == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(retVal);
                }
            }
            catch (Exception ex)
            {
                _log.LogError(ex, "Error");
                return StatusCode(500);
            }
        }

        [HttpDelete]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public IActionResult Delete(int id)
        {
            try
            {
                var found = _usrService.Delete(id);

                if (!found)
                {
                    return NotFound();
                }
                else
                {
                    return Ok();
                }
            }
            catch (Exception ex)
            {
                _log.LogError(ex, "Error");
                return StatusCode(500);
            }
        }
    }
}
