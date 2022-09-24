using dm_api.Application.Exceptions;
using dm_api.Application.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace dm_api.Api.Controllers
{
    public class BaseController : ControllerBase
    {
        protected ActionResult CreateResponse<T>(Func<T> function)
        {
            try
            {
                var result = function.Invoke();

                return Ok(new 
                {
                    Success = true,   
                    Data = result
                });
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(new
                {
                    Success = false,
                    data = new { message = ex.Message }
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    success = false,
                    data = new { message = ex.Message }
                });
            }
        }

        protected ActionResult CreateResponse(Action function)
        {
            try
            {
                function.Invoke();
                return Ok(new
                {
                    success = true,
                    data = new {},
                });
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(new
                {
                    success = false,
                    data = new { message = ex.Message }
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    success = false,
                    data = new { message = ex.Message }
                });
            }
        }
    }
}
