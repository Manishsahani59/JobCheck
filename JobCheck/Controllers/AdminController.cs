using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using BusinessLayer.Interfaces;
using CommonLayer.RequestModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RepositeryLayer.Services;

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
        [HttpPost]
        [Route("Location_InsertUpdateDelete")]
        public IActionResult InsertUpdateDeleteLocation([FromBody] LocationRequestModel LocationInfo) {
            try
            {
              var Message = AdminBusinesslayer.InsertUpdateDeleteLocation(LocationInfo);
                 return Ok(new { Message });
            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }
        }

        [HttpPost]
        [Route("Department_InsertUpdateDelete")]
        public IActionResult InsertUpdateDeleteDepartment([FromBody] DepartmentRequestModel DepartmentInfo) {
            try
            {
                var Message = AdminBusinesslayer.Department_InsertUpdateDelete(DepartmentInfo);
                return Ok(new { Message });
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
        }

        [HttpPost]
        [Route("IndustryType_InsertUpdateDelete")]
        public IActionResult InsertUpdateDeleteIndustryType([FromBody] IndustryTypeRequestModel IndustryInfo) {
            try
            {
                var Message = AdminBusinesslayer.InsertUpdateDeleteIndustryType(IndustryInfo);
                return Ok( new { Message});
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }   
        }
        [HttpPost]
        [Route("District_InsertUpdateDelete")]
        public IActionResult InsertUpdateDeleteDistrict([FromBody] DistrictRequestModel DistricInfo) {
            try
            {
                var Message = AdminBusinesslayer.InsertUpdateDeleteDistrict(DistricInfo);
                return Ok(new { Message });
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
        }
        [HttpPost]
        [Route("Qualification_InsertUpdateDelete")]
        public IActionResult InsertUpdateDeleteQualification([FromBody] QualificationRequestModel QualificationInfo) {
            try
            {
                var Message = AdminBusinesslayer.InsertUpdateDeleteQualificationType(QualificationInfo);
                return Ok(new { Message });
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
        }
        [HttpPost]
        [Route("State_InsertUpdateDelete")]
        public IActionResult InsertUpdateDeleteState([FromBody] StateRequestModel StateInfo) {
            try
            {
                var Message = AdminBusinesslayer.InsertUpdateDeleteState(StateInfo);
                return Ok(new { Message });
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
        }
        [HttpPost]
        [Route("Designation_InsertUpdateDelete")]
        public IActionResult InsertUpdateDeleteDesignation([FromBody] DesignationRequestModel DesignationInfo)
        {
            try
            {
                    var Message = AdminBusinesslayer.InsertUpdateDeleteDesignation(DesignationInfo);
                    return Ok(new { Message });
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
        }

        [HttpPost]
        [Route("SkillType_InsertUpdateDelete")]
        public IActionResult InsertUpadteDeleteSkillType([FromBody] SkillTypeRequestModel SkillTypeInfo)
        {
            try
            {
                var Message = AdminBusinesslayer.InsertUpdateDeleteSkillType(SkillTypeInfo);
                return Ok(new { Message });
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
        }

        [HttpPost]
        [Route("JObType_InsertUpdateDelete")]
        public IActionResult InsertUpadteDeleteJobType([FromBody] JobTypeRequestModel JobTypeInfo)
        {
            try
            {
                var Message = AdminBusinesslayer.InsertUpdateDeleteJobType(JobTypeInfo);
                return Ok(new { Message });
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
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

        [HttpGet]
        [Route("QualificationTypeId/{QualificationTypeId}/UserId/{UserId}")]
        public async Task<IActionResult> GetQualificationTypeList(int QualificationTypeId, int UserId)
        {
            try
            {
                var GetQualificationType = await AdminBusinesslayer.GetQualificationTypeList(QualificationTypeId, UserId);
                if (GetQualificationType != null && GetQualificationType.Count != 0)
                {
                    var status = true;
                    var Message = "QualifictionTypelist is Give Below";
                    return Ok(new { status, Message, GetQualificationType });
                }
                else
                {
                    var status = false;
                    var Message = "QualifictionTypelist is not Found";
                    return NotFound(new { status, Message, });

                }
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
        }

        [HttpGet]
        [Route("StateId/{StateId}/UserId/{UserId}")]
        public async Task<IActionResult> GetStateList(int StateId, int UserId)
        {
            try
            {
                var GetStateList = await AdminBusinesslayer.GetStateList(StateId, UserId);
                if (GetStateList != null && GetStateList.Count != 0)
                {
                    var status = true;
                    var Message = "Statelist is Give Below";
                    return Ok(new { status, Message, GetStateList });
                }
                else
                {
                    var status = false;
                    var Message = "Statelist is not Found";
                    return NotFound(new { status, Message, });

                }
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
        }


        [HttpGet]
        [Route("DepartmentId/{DepartmentId}/UserId/{UserId}")]
        public async Task<IActionResult> GetDepartmentList(int DepartmentId, int UserId)
        {
            try
            {
                var DepartmentList = await AdminBusinesslayer.GetDepartmentList(DepartmentId, UserId);
                if (DepartmentList != null && DepartmentList.Count != 0)
                {
                    var status = true;
                    var Message = "Departmentlist is Give Below";
                    return Ok(new { status, Message, DepartmentList });
                }
                else
                {
                    var status = false;
                    var Message = "Departmentlist is not Found";
                    return NotFound(new { status, Message, });

                }
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
        }

        [HttpGet]
        [Route("DesignationId/{DesignationId}/UserId/{UserId}")]
        public async Task<IActionResult> GetDesignationList(int DesignationId, int UserId)
        {
            try
            {
                var Designationlist = await AdminBusinesslayer.GetDesignationlist(DesignationId, UserId);
                if (Designationlist != null && Designationlist.Count != 0)
                {
                    var status = true;
                    var Message = "Designationlist is Give Below";
                    return Ok(new { status, Message, Designationlist });
                }
                else
                {
                    var status = false;
                    var Message = "Designationlist is not Found";
                    return NotFound(new { status, Message, });

                }
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
        }



    }
}
