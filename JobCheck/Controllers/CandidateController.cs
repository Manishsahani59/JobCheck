using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using BusinessLayer.Interfaces;
using CommonLayer.RequestModels;
using CommonLayer.CandidateRequestModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RepositeryLayer.Services;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JobCheck.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateController : ControllerBase
    {

        ICandidateBusinessLayer CandidateBusinessLayer;

        public CandidateController(ICandidateBusinessLayer Di_CandidateBusinessLayer)
        {
            CandidateBusinessLayer = Di_CandidateBusinessLayer;
        }


        [HttpPost]
        [Route("Candidate_InsertUpdateDeleteMaster")]
        public IActionResult Candidate_InsertUpdateDeleteMaster([FromBody] ReqCandidatePersonalDetails sCandidatePersonalDetails)
        {

            try
            {
                var Message = CandidateBusinessLayer.InsertUpdateDeleteCandidatePersonalDetails(sCandidatePersonalDetails);
                return Ok(new { Message });
            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }
        }

        [HttpPost]
        [Route("Candidate_InsertUpdateDeleteContactDetails")]
        public IActionResult Candidate_InsertUpdateDeleteContactDetails([FromBody] ReqCandidateContactDetails sReqCandidateContactDetails)
        {

            try
            {
                var Message = CandidateBusinessLayer.InsertUpdateDeleteCandidateContactDetails(sReqCandidateContactDetails);
                return Ok(new { Message });
            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }
        }


        [HttpPost]
        [Route("Candidate_InsertUpdateDeleteWorkExpDetails")]
        public IActionResult Candidate_InsertUpdateDeleteWorkExpDetails([FromBody] ReqCandidateWorkExperienceDetails sReqCandidateWorkExperienceDetails)
        {


            try
            {
                var Message = CandidateBusinessLayer.InsertUpdateDeleteCandidateWorkExperience(sReqCandidateWorkExperienceDetails);
                return Ok(new { Message });
            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }
        }

    }
}
