﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CUSTOR.EICOnline.DAL.DataAccessLayer.Bussiness;
using CUSTOR.EICOnline.DAL.EntityLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CUSTOR.EICOnline.API.Controllers.Bussiness
{
    [Produces("application/json")]
    [Route("api/Business")]
    public class BusinessController : Controller
    {
        private ApplicationDbContext context;
        public BusinessController (ApplicationDbContext ctx)
        {
            context = ctx;
        }
        [HttpGet("GetBussiness/{id:int}")]
        public async Task<IEnumerable<DAL.EntityLayer.Business>> GetBussiness(int id)
        {
            BusinessRepository
            businessRepo = new BusinessRepository(context);
            return await businessRepo.GetRecordsById(id);
        }

        [HttpGet("GetRegistration/{Tin:int}")]
        public async Task<Registration> GetRegistration(string Tin)
        {
            BusinessRepository
            businessRepo = new BusinessRepository(context);
            return await businessRepo.GetRegistrationByTin(Tin);
        }

        [HttpPost("Save")]
        public async Task<IActionResult> SaveBussiness([FromBody] DAL.EntityLayer.Business bussiness)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                BusinessRepository
           businessRepo = new BusinessRepository(context);
                 await businessRepo.SaveBussiness(bussiness);
            }
            catch(Exception ex)
            {

            }
            return CreatedAtAction("SaveBussiness", new { id = bussiness.ID }, bussiness);
        }

        //[HttpGet("api/GetBussiness")]
        //public async Task<IEnumerable<Business>> GetDivisions()
        //{
        //    BusinessRepository
        //    businessRepo = new BusinessRepository(context);
        //    return await businessRepo.GetRecordsById(id);
        //}
    }
}