using CSU_Suceava_BE.Application.Interfaces;
using CSU_Suceava_BE.Application.Models.IstoricPremii;
using CSU_Suceava_BE.Application.Models.IstoricRoluri;
using CSU_Suceava_BE.Application.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CSU_Suceava_BE.Controllers
{
    [ApiController, Route("api/istoricroluri")]
    public class IstoricRoluriController:ControllerBase
    {
        private readonly ILogger<IstoricRoluriController> logger;
        private readonly IIstoricRoluriService istoricRoluriService;

        public IstoricRoluriController(IIstoricRoluriService istoricRoluriService, ILogger<IstoricRoluriController> logger)
        {
            this.logger = logger;
            this.istoricRoluriService = istoricRoluriService;
        }

        [SwaggerOperation(Summary = "Create istoric roluri by staff id")]
        [HttpPost]
        public async Task<IActionResult> CreateIstoricRoluriAsync(IstoricRoluriCreateDto istoricRoluri,
                                                                 [FromQuery] Guid staffId)
        {
            try
            {
                var createdIstoricRoluri = await istoricRoluriService
                    .CreateIstoricRoluriAsync(istoricRoluri, staffId);

                return Ok(createdIstoricRoluri);

            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);

                return BadRequest();
            }
        }

        [SwaggerOperation(Summary = "Get istoric roluri by staff id")]
        [HttpGet]
        public async Task<IActionResult> GetIstoricRoluriByStaffId([FromQuery] Guid staffId)
        {
            try
            {
                var istoricRoluri = await istoricRoluriService.GetIstoricRoluriByStaffIdAsync(staffId);

                return Ok(istoricRoluri);

            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);

                return BadRequest();
            }
        }

        [SwaggerOperation(Summary = "Delete istoric roluri by id")]
        [HttpDelete]
        public async Task<IActionResult> DeleteIstoricPremiiByStaffIdAsync(Guid id)
        {
            try
            {
                await istoricRoluriService.DeleteIstoricRoluriByIdAsync(id);

                return NoContent();

            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);

                return BadRequest();
            }
        }

        [SwaggerOperation(Summary = "Update istoric roluri by id")]
        [HttpPut]
        public async Task<IActionResult> UpdateIstoricPremiiByIdAsync(Guid id, IstoricRoluriCreateDto istoricRoluri)
        {
            try
            {
                var updatedIstoricRoluri = await istoricRoluriService
                    .UpdateIstoricRoluriByIdAsync(id, istoricRoluri);

                return Ok(updatedIstoricRoluri);

            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);

                return BadRequest();
            }
        }
    }
}
