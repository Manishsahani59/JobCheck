using CommonLayer.RequestModels;

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


using CommonLayer.CandidateRequestModel;


namespace RepositeryLayer.Interfaces
{
   public interface ICandidateRepositeryLayer
    {
             

        string InsertUpdateDeleteCandidatePD(ReqCandidatePersonalDetails sCandidatePersonalDetails);
        string InsertUpdateDeleteCandidateContactDetails(ReqCandidateContactDetails sReqCandidateContactDetails);
        string InsertUpdateDeleteCandidateWorkExperience(ReqCandidateWorkExperienceDetails sReqCandidateWorkExperienceDetails);

    }
}
