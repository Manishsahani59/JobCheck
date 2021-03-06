﻿using CommonLayer.RequestModels;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Text;

namespace CommonLayer.ResponseModels
{
      public class GETIndustryTypeResppnseModel
        {
            public string IndustryType { get; set; }
        }

    public class GETOpenJobListingResponseModel
        { 
            public long RM_ClientRequirementID { get; set; }
            public string ClientName { get; set; }
            public string Branch { get; set; }
            public string Designation { get; set; }
            public string LocationName { get; set; }
            public string Client_Ho_Location { get; set; }
            public string CreatedDate { get; set; }
            public string CreatedBy { get; set; }
            public string Role { get; set; }
            public string CategoryName { get; set; }
            public string IndustryType { get; set; }
            public string HiringManagerName { get; set; }
            public string HiringManagerEmailId { get; set; }
            public string HiringManagerContactNo { get; set; }
            public string FromSalary { get; set; }
            public string ToSalary { get; set; }
            public string FromExperince { get; set; }
            public string ToExperince { get; set; }
           public string RM_PositionCount { get; set; }
           public string RecievedDate { get; set; }
           public string EndDate { get; set; }
           public string  StateName { get; set; }

    }

    public class GetDistrictListResponseModel
       { 
            public int DistrictId { get; set; }
            public string DistrictName { get; set; }
            public int DistrictCode { get; set; }
            public int StateId { get; set; }
            public string StateName { get; set; }
            public string CreatedBy { get; set; }
            public string CreatedOn { get; set; }
            public string UpdatedBy { get; set; }
            public string UpdatedOn { get; set; }
            public char isActive { get; set; }
 
    }
    public class GetIndustryListResponseModel
        {
            public int IndustryTypeId { get; set; }
            public string IndustryTypeName { get; set; }
            public string IndustryTypeCode { get; set; }
            public string CreatedBy { get; set; }
            public string CreatedOn { get; set; }
            public string UpdatedBy { get; set; }
            public string UpdatedOn { get; set; }
            public bool IsActive { get; set; }
         }

    public class GetSkillTypeListResponseModel
    {
        public int SkillTypeId { get; set; }
        public string SkillTypeName { get; set; }

      //  public string SkillTypeCode { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public string UpdatedOn { get; set; }
        public bool IsActive { get; set; }
    }
    public class GetLocationsListResponseModel
    {
        public int LocationId { get; set; }
        public string LocationName { get; set; }
        public string LocationCode { get; set; } 
        public int DistrictId { get; set; }
        public string DistrictName { get; set; }
        public string StateId { get; set; }  
        public string StateName { get; set; }
        public string  CreatedBy { get; set; }
        public string CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public string UpdatedOn { get; set; }
        public char IsActive { get; set; }
    }

    public class CourseTypeResponseModel { 
        public long CoursTypeId { get; set; }
        public string CoursTypeName { get; set; }
        public string CoursTypeCode { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public string UpdatedOn { get; set; }
        public bool IsActive { get; set; }


    }

    public class JobTypeResponseModel
    {
        public long JobTypeId { get; set; }
        public string JobTypeName { get; set; }
        public string JobTypeCode { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public string UpdatedOn { get; set; }
        public bool IsActive { get; set; }
    }

    public class GetQualificationTypeList {
       public long QualificationTypeId { get; set; } 
       public string QualificationTypeName { get; set; } 
       public string QualificationTypeCode { get; set; }
       public string CreatedBy { get; set; } 
       public string CreatedOn { get; set; } 
       public string UpdatedBy { get; set; }
       public string UpdatedOn { get; set; } 
       public string IsActive { get; set; }
    }

    public class GetStateListResponseModel { 
        public long StateId { get; set; }
        public string StateName { get; set; }
        public string StateCode { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public string UpdatedOn { get; set; }
        public string IsActive { get; set; }
    }

    public class GetDepartmentListResponseModel {
       public long DepartmentId { get; set; }
        public string DepartmentName { get; set; } 
        public string DepartmentCode { get; set; }
        public string CreatedBy { get; set; } 
        public string CreatedOn { get; set; }
        public string UpdatedBy { get; set; }  
        public string UpdatedOn{get;set;}  
       public bool IsActive { get; set; }
    }

    public class DesignationlistResponseModel
    {
        public long DesignationId { get; set; }
        public string DesignationName { get; set; }
        public string DesignationCode { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public string UpdatedOn { get; set; }
        public bool IsActive { get; set; }
    }


    public class GetLoginDetailsResponseMOdel
    {



        public int UserId { get; set; }
        public string UserFirstName { get; set; }
        public string UserMiddleName { get; set; }
        public string UserLastName { get; set; }
        public string LoginName { get; set; }
        public string UserPassword { get; set; }
        public string EmailId { get; set; }
        public string MobileNo { get; set; }

        public string RoleId { get; set; }
        public string IsActive { get; set; }
        public string CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public string DeletedDate { get; set; }
        public string DeletedBy { get; set; }

        public string Errormsg { get; set; }

    }

  

    public class GetJobTypeResponseModel { 
            
    }


}
