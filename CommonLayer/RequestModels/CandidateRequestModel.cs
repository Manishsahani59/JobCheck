using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer.CandidateRequestModel
{
    class CandidateRequestModel
    {

    }

    public class ReqCandidateContactDetails
    {
        public string ActionType { get; set; }

        public int CandidateContactId { get; set; }

        public int CandidateId { get; set; }

        public int AddressTypeId { get; set; }
        public string HouseNo_Building { get; set; }
        public string Street { get; set; }
        public string Area { get; set; }

        public string Town_City { get; set; }
        public int StateId { get; set; }
        public string Country { get; set; }
        public string PINCode { get; set; }


        public string ContactNo { get; set; }
        public int CreatedBy { get; set; }
        public string IsActive { get; set; }
      
    }


    public class ReqCandidateWorkExperienceDetails
    {
        public string ActionType { get; set; }

        public int CandidateWorkExpId { get; set; }

        public int CandidateId { get; set; }

        public string CompanyName { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string LastDesignation { get; set; }

        public float LastCTC { get; set; }
        public string ReferenceName { get; set; }
        public string ReferenceDesignation { get; set; }
        public string ReferenceContactNo { get; set; }


        public int CreatedBy { get; set; }
        public string IsActive { get; set; }
       

    }
}
