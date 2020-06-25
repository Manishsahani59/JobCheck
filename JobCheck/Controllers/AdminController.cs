using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace JobCheck.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        IAdminBusinessLayer AdminBusinesslayer;
        public AdminController(IAdminBusinessLayer Di_AdminBusinessLayer) {
            AdminBusinesslayer = Di_AdminBusinessLayer;
        }

        [HttpGet]
        [Route("GETIndustryType")]
        public async Task<IActionResult> GETIndustryType()
        {
            try
            {
               var IndustryTypes=await AdminBusinesslayer.GETIndustryType();
                if (IndustryTypes.Count != 0 && IndustryTypes!=null) {
                    var state = true;
                    var message = "The Total Industry is listed Below";
                    return Ok(new { state, message, IndustryTypes });
                }
                else
                {   
                    return NoContent();
                }
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
        }

        [HttpGet]
        [Route("GETOpenJobListing")]
        public async Task<IActionResult> GETOpenJobListing()
        {
            try
            {
                var OpenJobs = await AdminBusinesslayer.GETOpenJobListing();
                if (OpenJobs.Count != 0 && OpenJobs != null)
                {
                    var state = true;
                    var message = "The Total Industry is listed Below";
                    return Ok(new { state, message, OpenJobs });
                }
                else
                {
                    return NoContent();
                }
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
        }


        [HttpGet]
        [Route("User/{UserId}/District/{DistrictId}")]
        public async Task<IActionResult> GetDistrictList(int UserId, int DistrictId) {
            try
            {
               var DistrictList= await AdminBusinesslayer.GetDistrictList(UserId, DistrictId);
                if (DistrictList != null && DistrictList.Count != 0)
                {
                    var status = true;
                    var message = "The District List is Listed Below";
                    return Ok(new { status, message, DistrictList });
                }
                else {
                    var status = false;
                    var message = "No District Found";
                    return BadRequest(new { status, message, DistrictList });
                }
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
        }
    
        [HttpGet]
        [Route("IndustryId/{IndustryId}/UserId/{UserId}")]
        public async Task<IActionResult> GetIndustryList(int IndustryId,int UserId)
        {
            try
            {
                var IndustryLists = await AdminBusinesslayer.GetIndustryList(IndustryId,UserId);
                if (IndustryLists != null && IndustryLists.Count != 0)
                {
                    var status = true;
                    var message = "The Industry List in Listed Below";
                    return Ok(new { status, message, IndustryLists });
                }
                else
                {
                    var status = false;
                    var message = "No Industry Found";
                    return BadRequest(new { status, message});
                }
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
        }
        
     
        [HttpGet]
        [Route("SkillTypeId/{SkillTypeId}/UserId/{UserId}")]
        public async Task<IActionResult> GetSkillTypeList(int SkillTypeId,int UserId)
        {
            try
            {
                var SkillTypeList = await AdminBusinesslayer.GetSkillTypeList(SkillTypeId, UserId);
                if (SkillTypeList != null && SkillTypeList.Count != 0)
                {
                    var status = true;
                    var message = "The Skill List in Listed Below";
                    return Ok(new { status, message, SkillTypeList });
                }
                else
                {
                    var status = false;
                    var message = "Skill List is Empty";
                    return BadRequest(new { status, message });
                }
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
        }
        [HttpGet]
        [Route("LocationId/{LocationId}/UserId/{UserId}")]
        public async Task<IActionResult> GetLocationsList(int LocationId, int UserId)
        {
            try
            {
                var LocationsList = await AdminBusinesslayer.GetLocationsList(LocationId, UserId);
                if (LocationsList != null && LocationsList.Count != 0)
                {
                    var status = true;
                    var message = "The Location List in Listed Below";
                    return Ok(new { status, message, LocationsList });
                }
                else
                {
                    var status = false;
                    var message = "Location List is Empty";
                    return BadRequest(new { status, message });
                }
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
        }

        // GET api/<AdminController>/5
        [HttpGet]
        public string Get()
        {
            try
            {
                return "Hi Manish welcome to Innovsourc";
            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }
        }

       
    }
}
