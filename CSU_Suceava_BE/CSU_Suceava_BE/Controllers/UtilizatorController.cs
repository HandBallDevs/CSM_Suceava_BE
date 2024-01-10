using CSU_Suceava_BE.Application.Interfaces;
using CSU_Suceava_BE.Application.Models.Utilizator;
using Microsoft.AspNetCore.Mvc;

namespace CSU_Suceava_BE.Controllers
{
    [ApiController, Route("api/utilizatori")]
    public class UtilizatorController : ControllerBase
    {
        private readonly IUtilizatorService utilizatorService;
        private readonly ILogger<UtilizatorController> logger;

        public UtilizatorController(IUtilizatorService utilizatorService, ILogger<UtilizatorController> logger)
        {
            this.utilizatorService = utilizatorService;
            this.logger = logger;
        }

        [HttpPost, Route("login")]
        public async Task<IActionResult> LoginAsync(AuthenticationDto authentication)
        {
            try
            {
                var token = await utilizatorService.LoginAsync(authentication);

                return Ok(token);

            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);

                return BadRequest(ex.Message);
            }
        }
    }
}
