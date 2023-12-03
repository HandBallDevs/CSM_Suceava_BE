using CSU_Suceava_BE.Application.Interfaces;
using CSU_Suceava_BE.Application.Models.IstoricPremii;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CSU_Suceava_BE.Controllers
{
    [ApiController, Route("api/istoricpremii")]
    public class IstoricPremiiController : ControllerBase
    {
        private readonly ILogger<IstoricPremiiController> logger;
        private readonly IIstoricPremiiService istoricPremiiService;

        public IstoricPremiiController(IIstoricPremiiService istoricPremiiService, ILogger<IstoricPremiiController> logger)
        {
            this.logger = logger;
            this.istoricPremiiService = istoricPremiiService;
        }

        [SwaggerOperation(Summary = "Create istoric premii by staff id")]
        [HttpPost]
        public async Task<IActionResult> CreateIstoricPremiiAsync(IstoricPremiiCreateDto istoricPremii,
                                                                  [FromQuery] Guid staffId)
        {
            try
            {
                var createdIstoricPremii = await istoricPremiiService
                    .CreateIstoricPremiiAsync(istoricPremii, staffId);

                return Ok(createdIstoricPremii);

            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);

                return BadRequest();
            }
        }

        [SwaggerOperation(Summary = "Get istoric premii by staff id")]
        [HttpGet]
        public async Task<IActionResult> GetIstoricPremiiByStaffIdAsync([FromQuery] Guid staffId)
        {
            try
            {
                var istoricPremii = await istoricPremiiService.GetIstoricPremiiByStaffIdAsync(staffId);

                return Ok(istoricPremii);

            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);

                return BadRequest();
            }
        }

        [SwaggerOperation(Summary = "Delete istoric premii by id")]
        [HttpDelete]
        public async Task<IActionResult> DeleteIstoricPremiiByStaffIdAsync(Guid id)
        {
            try
            {
                await istoricPremiiService.DeleteIstoricPremiiByIdAsync(id);

                return NoContent();

            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);

                return BadRequest();
            }
        }

        [SwaggerOperation(Summary = "Update istoric premii by id")]
        [HttpPut]
        public async Task<IActionResult> UpdateIstoricPremiiByIdAsync(Guid id, IstoricPremiiCreateDto istoricPremii)
        {
            try
            {
                var updatedIstoricPremii = await istoricPremiiService
                    .UpdateIstoricPremiiByIdAsync(id, istoricPremii);

                return Ok(updatedIstoricPremii);

            }catch(Exception ex)
            {
                logger.LogError(ex.Message);

                return BadRequest();
            }
        }
    }
}
