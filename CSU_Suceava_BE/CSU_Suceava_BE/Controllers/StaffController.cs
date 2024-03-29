﻿using CSU_Suceava_BE.Application.Interfaces;
using CSU_Suceava_BE.Application.JwtUtils;
using CSU_Suceava_BE.Application.Models.Staff;
using CSU_Suceava_BE.Domain.Enums;
using Microsoft.AspNetCore.Authorization;
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
        public async Task<IActionResult> CreateStaffAsync(StaffCreateDto staff)
        {
            try
            {
                var createdStaff = await staffService.CreateStaffAsync(staff);

                return Ok(createdStaff);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);

                return BadRequest();
            }
        }

        [SwaggerOperation(Summary = "Retrive staff by id")]
        [HttpGet, Route("{id}")]
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

        [SwaggerOperation(Summary = "Retrive staff by type")]
        [HttpGet]
        public async Task<IActionResult> GetStaffByType([FromQuery] TipLot tipLot)
        {
            try
            {
                var staff = await staffService.GetStaffByType(tipLot);

                return Ok(staff);
               
            }
            catch(Exception ex)
            {
                logger.LogError(ex.Message);

                return BadRequest();
            }
        }

        [SwaggerOperation(Summary = "Update staff")]
        [HttpPut]
        public async Task<IActionResult> UpdateStaffAsync(Guid id, StaffCreateDto staff)
        {
            try
            {
                var updatedStaff = await staffService.UpdateStaffAsync(id, staff);

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

            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);

                return BadRequest();
            }
        }
    }
}
