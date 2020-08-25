using CommonLayer.RequestModels;
using CommonLayer.ResponseModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
    public interface ICandidateBusinessLayer
    {

        //Task<List<GetLoginDetailsResponseMOdel>> GetLoginList(String LoginName, String UserPassword, String UserType);
        string InsertUpdateDeleteCandidatePersonalDetails(ReqCandidatePersonalDetails sCandidatePersonalDetails);


    }

}
