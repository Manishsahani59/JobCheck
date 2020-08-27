using BusinessLayer.Interfaces;
using CommonLayer.RequestModels;
using CommonLayer.ResponseModels;
using RepositeryLayer.Interfaces;
using RepositeryLayer.Services;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

using CommonLayer.CandidateRequestModel;
using CommonLayer.CandidateResponceModel;


namespace BusinessLayer.Services
{
    public class CandidateBusinessLayer : ICandidateBusinessLayer
    {
        ICandidateRepositeryLayer CandidateRepositeryLayer;
        public CandidateBusinessLayer(ICandidateRepositeryLayer di_CandidateRepositeryLayer)
        {
            CandidateRepositeryLayer = di_CandidateRepositeryLayer;
        }


        public string InsertUpdateDeleteCandidatePersonalDetails(ReqCandidatePersonalDetails sCandidatePersonalDetails)
        {
            try
            {
                var Message = CandidateRepositeryLayer.InsertUpdateDeleteCandidatePD(sCandidatePersonalDetails);
                return Message;
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
        }

        public string InsertUpdateDeleteCandidateContactDetails(ReqCandidateContactDetails sReqCandidateContactDetails)
        {
            try
            {
                var Message = CandidateRepositeryLayer.InsertUpdateDeleteCandidateContactDetails(sReqCandidateContactDetails);
                return Message;
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
        }


        public string InsertUpdateDeleteCandidateWorkExperience(ReqCandidateWorkExperienceDetails sCandidateWorkExperienceDetails)
        {
            try
            {
                var Message = CandidateRepositeryLayer.InsertUpdateDeleteCandidateWorkExperience(sCandidateWorkExperienceDetails);
                return Message;
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
        }



    }
}
