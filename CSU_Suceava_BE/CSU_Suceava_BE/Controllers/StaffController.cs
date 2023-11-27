using CSU_Suceava_BE.Application.Interfaces;
using CSU_Suceava_BE.Application.Models;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CSU_Suceava_BE.Controllers
{
    [ApiController, Route("api/staff")]
    public class StaffController : ControllerBase
    {
        private readonly ILogger<StaffController> logger;
        private readonly IStaffService staffService;

        public StaffController(IStaffService staffService, ILogger<StaffController> logger)
        {
            this.logger = logger;
            this.staffService = staffService;
        }

        [SwaggerOperation(Summary = "Create staff")]
        [HttpPost]
        public async Task<IActionResult> CreateStaffAsync(StaffDto staff)
        {
          
                var createdStaff = await staffService.CreateStaffAsync(staff);

                return Ok(createdStaff);
           
    

        }

        [SwaggerOperation(Summary = "Retrive staff by id")]
        [HttpGet]
        public async Task<IActionResult> GetStaffAsync(Guid id)
        {
            try
            {
                var staff = await staffService.GetStaffAsync(id);

                return Ok(staff);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);

                return BadRequest();

            }
        }

        [SwaggerOperation(Summary = "Update staff")]
        [HttpPut]
        public async Task<IActionResult> UpdateStaffAsync(StaffDto staff)
        {
            try
            {
                var updatedStaff = await staffService.UpdateStaffAsync(staff);

                return Ok(updatedStaff);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);

                return BadRequest();
            }
        }

        [SwaggerOperation(Summary = "Delete staff by id")]
        [HttpDelete]
        public async Task<IActionResult> DeleteStaffAsync(Guid id)
        {
            try
            {
                await staffService.DeleteStaffAsync(id);

                return NoContent();

            }catch(Exception ex)
            {
                logger.LogError(ex.Message);

                return BadRequest();
            }
        }
    }
}
