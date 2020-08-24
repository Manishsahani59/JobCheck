using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace CommonLayer.RequestModels
{
    public class LocationRequestModel { 
        public string ActionType { get; set; }
        public long LocationId { get; set; }
        public long DistrictId { get; set; }
        public long StateId { get; set; }
        public string LocationName { get; set; }
        public string LocationCode { get; set; }
        public long UserId { get; set; }
    }

    public class DepartmentRequestModel {
       public string ActionType{get;set;}
       public long DepartmentId { get; set; } 
       public string DepartmentName { get; set; } 
       public long DepartmentCode { get; set; }
       public long UserId { get; set; } 
     }
    public class IndustryTypeRequestModel {
        public string ActionType { get; set; }
        public long IndustryTypeId { get; set; }
        public string IndustryTypeName { get; set; }
        public long IndustryTypeCode{get;set;}
        public long UserId { get; set; }
    }
    public class DistrictRequestModel { 
        public string ActionType { get; set; }
        public long DistrictId { get; set; }
        public long StateId { get; set; }
        public string DistrictName { get; set; }
        public long DistrictCode { get; set; }
        public long UserId { get; set; }

    }

    public class QualificationRequestModel { 
        public string ActionType { get; set; }
        public long QualificationTypeId { get; set; }
        public string QualificationTypeName { get; set; }
        public string QualificationTypeCode { get; set; }
        public long UserId { get; set; }
    }
    public class StateRequestModel
    {
        public string ActionType { get; set; }
        public long StateId { get; set; }
        public string StateName { get; set; }
        public string StateCode { get; set; }
        public long UserId { get; set; }
    }
    public class DesignationRequestModel
    {
        public string ActionType { get; set; }
        public long DesignationId { get; set; }
        public string DesignationName { get; set; }
        public string DesignationCode { get; set; }
        public long UserId { get; set; }
    }

    public class LoginDetails
    {
        public string LoginName { get; set; }
        public string UserPassword { get; set; }
        public string UserType { get; set; }
        public string SKey { get; set; }


    }
}
