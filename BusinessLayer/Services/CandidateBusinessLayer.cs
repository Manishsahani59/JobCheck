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
        //public async Task<List<GetLoginDetailsResponseMOdel>> GetLoginList(String LoginName, String UserPassword, String UserType)
        //{
        //    try
        //    {
        //        var GetLogingDetails= await CandidateRepositeryLayer.GetLoginList(LoginName, UserPassword, UserType);
        //        if (GetLogingDetails != null && GetLogingDetails.Count != 0)
        //        {
        //            return GetLogingDetails;
        //        }
        //        return null;
        //    }
        //    catch (Exception e)
        //    {

        //        throw new ApplicationException(e.Message);
        //    }
        //}


    }
}
