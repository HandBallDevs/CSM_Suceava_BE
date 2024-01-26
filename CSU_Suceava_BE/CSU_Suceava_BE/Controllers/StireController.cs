using CSU_Suceava_BE.Application.Interfaces;
using CSU_Suceava_BE.Application.Models.Stire;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CSU_Suceava_BE.Controllers
{
    [ApiController, Route("api/stire")]
    public class StireController : ControllerBase
    {
        private readonly ILogger<StireController> logger;
        private readonly IStireService stireService;

        public StireController(ILogger<StireController> logger, IStireService stireService)
        {
            this.logger = logger;
            this.stireService = stireService;
        }

        [SwaggerOperation(Summary = "Create stire")]
        [HttpPost]
        public async Task<IActionResult> CreateStireAsync([FromQuery]Guid creatorId, StireCreateDto stire)
        {
            try
            {
                var createdStire = await stireService.CreateStireAsync(creatorId, stire);

                return Ok(createdStire);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);

                return BadRequest();
            }
        }

        [SwaggerOperation(Summary = "Update stire by id")]
        [HttpPut]
        public async Task<IActionResult> UpdateStireAsync(Guid id, StireCreateDto stire)
        {
            try
            {
                var updatedStire = await stireService.UpdateStireAsync(id, stire);

                return Ok(updatedStire);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);

                return BadRequest();
            }
        }

        [SwaggerOperation(Summary = "Delete stire by id")]
        [HttpDelete]
        public async Task<IActionResult> DeleteStireAsync(Guid id)
        {
            try
            {
                await stireService.DeleteStireAsync(id);

                return NoContent();
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);

                return BadRequest();
            }
        }

        [SwaggerOperation(Summary = "Get stire by id")]
        [HttpGet, Route("{id}")]
        public async Task<IActionResult> GetStireByIdAsync(Guid id)
        {
            try
            {
                var stire = await stireService.GetStireByIdAsync(id);

                return Ok(stire);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);

                return BadRequest();
            }
        }

        [SwaggerOperation(Summary = "Get all stiri")]
        [HttpGet]
        public async Task<IActionResult> GetAllStiriAsync()
        {
            try
            {
                var stiri = await stireService.GettAllStiriAsync();

                return Ok(stiri);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);

                return BadRequest();
            }
        }
    }
}
