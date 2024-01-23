using CSU_Suceava_BE.Application.Interfaces;
using CSU_Suceava_BE.Application.Models.Meci;
using CSU_Suceava_BE.Domain.Enums;
using Microsoft.AspNetCore.Mvc;

namespace CSU_Suceava_BE.Controllers
{
    [ApiController, Route("api/meci")]
    public class MeciController : ControllerBase
    {
        private readonly ILogger<MeciController> logger;
        private readonly IMeciService meciService;

        public MeciController(IMeciService meciService, ILogger<MeciController> logger)
        {
            this.logger = logger;
            this.meciService = meciService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateMeciAsync(MeciCreateDto meci)
        {
            try
            {
                var createdMeci = await meciService.CreateMeciAsync(meci);

                return Ok(createdMeci);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);

                return BadRequest();
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteMeciByIdAsync(Guid id)
        {
            try
            {
                await meciService.DeleteMeciByIdAsync(id);

                return NoContent();

            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);

                return BadRequest();
            }
        }

        [HttpGet, Route("{id}")]
        public async Task<IActionResult> GetMeciByIdAsync([FromRoute] Guid id)
        {
            try
            {
                var meci = await meciService.GetMeciByIdAsync(id);

                return Ok(meci);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);

                return BadRequest();
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetFilteredMeciuri(
            [FromQuery] StatusMeci? statusMeci, [FromQuery] TipCampionat? tipCampionat, [FromQuery] string? editie)
        {
            try
            {
                var meciuri = await meciService.GetFilteredMeciuri(statusMeci, tipCampionat, editie);

                return Ok(meciuri);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);

                return BadRequest();
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateMeciAsync(Guid id, MeciCreateDto meci)
        {
            try
            {
                var updatedMeci = await meciService.UpdateMeciAsync(id, meci);

                return Ok(updatedMeci);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);

                return BadRequest();
            }
        }


    }
}
