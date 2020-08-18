using CommonLayer.RequestModels;
using CommonLayer.ResponseModels;
using Microsoft.Extensions.Configuration;
using RepositeryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace RepositeryLayer.Services
{
    public class AdminRepositeryLayer : IAdminRepositeryLayer
    {
        private readonly IConfiguration _configuration;
        public AdminRepositeryLayer(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        //GetLocationsListResponseModel GetLocation;
        //SqlDataReader sdr;
        private static string message;


     
        public async Task<List<GETIndustryTypeResppnseModel>> GETIndustryType()
        {
            try
            {
                List<GETIndustryTypeResppnseModel> IndustryTypes = new List<GETIndustryTypeResppnseModel>();
               
                SqlConnection sqlConnection = new SqlConnection(_configuration["ConnectionString:DigiJobCheck"]);
                SqlCommand sqlCommand = new SqlCommand("usp_GETIndustryType", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                await sqlConnection.OpenAsync();
                SqlDataReader sdr =sqlCommand.ExecuteReader();
                while (sdr.Read()) {
                    GETIndustryTypeResppnseModel IndustryType = new GETIndustryTypeResppnseModel();
                    IndustryType.IndustryType = sdr["IndustryType"].ToString();
                    IndustryTypes.Add(IndustryType);
                }
                sdr.Close();
                return (IndustryTypes.Count != 0 && IndustryTypes != null) ? IndustryTypes : null;
            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }
        }

        public async Task<List<GETOpenJobListingResponseModel>> GETOpenJobListing()
        {
            try
            {
                List<GETOpenJobListingResponseModel> OpenJobListing = new List<GETOpenJobListingResponseModel>();
                SqlConnection sqlConnection = new SqlConnection(_configuration["ConnectionString:DigiJobCheck"]);
                SqlCommand sqlCommand = new SqlCommand("usp_GETOpenJobListing", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                await sqlConnection.OpenAsync();
                SqlDataReader sdr = sqlCommand.ExecuteReader();
                if (sdr.HasRows) {
                    GETOpenJobListingResponseModel GetOpenJob = new GETOpenJobListingResponseModel();
                    while (sdr.Read())
                    {

                        GetOpenJob.RM_ClientRequirementID = Convert.ToInt32(sdr["RM_ClientRequirementID"]);
                        GetOpenJob.ClientName = sdr["ClientName"].ToString();
                        GetOpenJob.Branch = sdr["Branch"].ToString();
                        GetOpenJob.Designation = sdr["Designation"].ToString();
                        GetOpenJob.LocationName = sdr["LocationName"].ToString();
                        GetOpenJob.Client_Ho_Location = sdr["Client HO Location"].ToString();
                        GetOpenJob.CreatedDate = sdr["Created_Date"].ToString();
                        GetOpenJob.CreatedBy = sdr["Created_By"].ToString();
                        GetOpenJob.Role = sdr["Role"].ToString();
                        GetOpenJob.CategoryName = sdr["CategoryName"].ToString();
                        GetOpenJob.IndustryType = sdr["IndustryType"].ToString();
                        GetOpenJob.HiringManagerName = sdr["HiringManagerName"].ToString();
                        GetOpenJob.HiringManagerEmailId = sdr["HiringManagerEmailId"].ToString();
                        GetOpenJob.HiringManagerContactNo = sdr["HiringManagerContactNo"].ToString();
                        GetOpenJob.FromSalary = sdr["FromSalary"].ToString();
                        GetOpenJob.ToSalary = sdr["ToSalary"].ToString();
                        GetOpenJob.FromExperince = sdr["FromExperince"].ToString();
                        GetOpenJob.ToExperince = sdr["ToExperince"].ToString();
                        GetOpenJob.RM_PositionCount = sdr["RM_PositionCount"].ToString();
                        GetOpenJob.RecievedDate = sdr["Received_date"].ToString();
                        GetOpenJob.EndDate = sdr["End_Date"].ToString();
                        GetOpenJob.StateName = sdr["StateName"].ToString();
                        OpenJobListing.Add(GetOpenJob);
                    }
                }
                
                sdr.Close();
                return (OpenJobListing != null && OpenJobListing.Count != 0) ? OpenJobListing : null;
               
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
        }

        public async Task<List<GetDistrictListResponseModel>> GetDistrictList(int UserId, int DistrictId)
        {
            try
            {
                List<GetDistrictListResponseModel> DistrictList = new List<GetDistrictListResponseModel>();
                SqlConnection sqlConnection = new SqlConnection(_configuration["ConnectionString:DigiJobCheck"]);
                SqlCommand sqlCommand = new SqlCommand("usp_GetDistrictList", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@intDistrictId", DistrictId);
                sqlCommand.Parameters.AddWithValue("@intUserId", UserId);
                await sqlConnection.OpenAsync();
                SqlDataReader sdr = sqlCommand.ExecuteReader();
                while (sdr.Read())
                {
                    GetDistrictListResponseModel GetDistrict = new GetDistrictListResponseModel();
                    GetDistrict.DistrictId= Convert.ToInt32(sdr["DistrictId"]);
                    GetDistrict.DistrictName = sdr["DistrictName"].ToString();
                    GetDistrict.DistrictCode = Convert.ToInt32(sdr["DistrictCode"]);
                    GetDistrict.CreatedBy= sdr["StateId"].ToString();
                    GetDistrict.CreatedOn= sdr["CreatedBy"].ToString();
                    GetDistrict.UpdatedBy = sdr["CreatedOn"].ToString();
                    GetDistrict.UpdatedOn = sdr["UpdatedBy"].ToString();
                    GetDistrict.UpdatedOn = sdr["UpdatedOn"].ToString();
                    GetDistrict.isActive = Convert.ToChar(sdr["isActive"]);
                    DistrictList.Add(GetDistrict);
                }
                sdr.Close();
                return (DistrictList != null && DistrictList.Count != 0) ? DistrictList : null;
               
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
        }

        public async Task<List<GetIndustryListResponseModel>> GetIndustryList(int IndustryId,int UserId)
        {
            try
            {
                List<GetIndustryListResponseModel> IndustryList= new List<GetIndustryListResponseModel>(); 
                SqlConnection sqlConnection = new SqlConnection(_configuration["ConnectionString:DigiJobCheck"]);
                SqlCommand sqlCommand = new SqlCommand("usp_GetIndustryList", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@intIndustryId", IndustryId);
                sqlCommand.Parameters.AddWithValue("@intUserId", UserId);
                await sqlConnection.OpenAsync();
                SqlDataReader sdr = sqlCommand.ExecuteReader();
                while (sdr.Read())
                {
                    GetIndustryListResponseModel GetIndustry = new GetIndustryListResponseModel();
                    GetIndustry.IndustryTypeId = Convert.ToInt32(sdr["IndustryTypeId"]);
                    GetIndustry.IndustryTypeName = sdr["IndustryTypeName"].ToString();
                    GetIndustry.IndustryTypeCode = Convert.ToInt32(sdr["IndustryTypeCode"]);
                    GetIndustry.CreatedBy = sdr["CreatedBy"].ToString();
                    GetIndustry.CreatedOn = sdr["CreatedOn"].ToString();
                    GetIndustry.UpdatedBy= sdr["UpdatedBy"].ToString();
                    GetIndustry.UpdatedOn= sdr["UpdatedOn"].ToString();
                    GetIndustry.IsActive= Convert.ToBoolean(sdr["IsActive"]);
                    IndustryList.Add(GetIndustry);
                }
                sdr.Close();
                return (IndustryList != null && IndustryList.Count != 0) ? IndustryList : null;
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
        }

        public async Task<List<GetSkillTypeListResponseModel>> GetSkillTypeList(int SkillTypeId, int UserId)
        {
            try
            {
                List<GetSkillTypeListResponseModel> GetSkillTypeList = new List<GetSkillTypeListResponseModel>();
                SqlConnection sqlConnection = new SqlConnection(_configuration["ConnectionString:DigiJobCheck"]);
                SqlCommand sqlCommand = new SqlCommand("[usp_GetSkillTypeList]", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@intSkillTypeId", SkillTypeId);
                sqlCommand.Parameters.AddWithValue("@intUserId", UserId);
                await sqlConnection.OpenAsync();
                SqlDataReader sdr = sqlCommand.ExecuteReader();
                while (sdr.Read()) {
                    GetSkillTypeListResponseModel GetSkill = new GetSkillTypeListResponseModel()
                    {
                        SkillTypeId = Convert.ToInt32(sdr["SkillTypeId"]),
                        SkillTypeName=sdr["SkillTypeName"].ToString(),
                        CreatedBy=sdr["CreatedBy"].ToString(),
                        CreatedOn=sdr["CreatedOn"].ToString(),
                        UpdatedBy=sdr["UpdatedBy"].ToString(),
                        UpdatedOn=sdr["UpdatedOn"].ToString(),
                        IsActive=Convert.ToChar(sdr["IsActive"]),
                    };
                    GetSkillTypeList.Add(GetSkill);
                }
                sdr.Close();
                return (GetSkillTypeList != null && GetSkillTypeList.Count != 0) ? GetSkillTypeList : null;
           
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
        }

        public async Task<List<GetLocationsListResponseModel>> GetLocationsList(int LocationId, int UserId)
        {
            try
            {
                List<GetLocationsListResponseModel> GetLocationsList = new List<GetLocationsListResponseModel>();
                SqlConnection sqlConnection = new SqlConnection(_configuration["ConnectionString:DigiJobCheck"]);
                SqlCommand sqlCommand = new SqlCommand("[usp_GetLocationsList]", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@intLocationId", LocationId);
                sqlCommand.Parameters.AddWithValue("@intUserId", UserId);
                await sqlConnection.OpenAsync();
                SqlDataReader sdr = sqlCommand.ExecuteReader();
                while (sdr.Read()) {
                    GetLocationsListResponseModel GetLocation = new GetLocationsListResponseModel()
                    {
                        LocationId = Convert.ToInt32(sdr["LocationId"]),
                        LocationName = sdr["LocationName"].ToString(),
                        LocationCode = sdr["LocationCode"].ToString(),
                        DistrictId = Convert.ToInt32(sdr["DistrictId"]),
                        DistrictName = sdr["DistrictName"].ToString(),
                        StateId = sdr["StateId"].ToString(),
                        StateName = sdr["StateName"].ToString(),
                        CreatedBy = sdr["CreatedBy"].ToString(),
                        CreatedOn = sdr["CreatedOn"].ToString(),
                        UpdatedBy = sdr["UpdatedBy"].ToString(),
                        UpdatedOn=sdr["UpdatedOn"].ToString(),
                        IsActive=Convert.ToChar(sdr["IsActive"]),
                    };
                    GetLocationsList.Add(GetLocation);
                }
                sdr.Close();
                return (GetLocationsList != null && GetLocationsList.Count != 0) ? GetLocationsList : null;
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
        }

        public async Task<List<GetQualificationTypeList>> GetQualificationTypeList(int QualificationTypeId, int UserId)
        {
            try
            {
                List<GetQualificationTypeList> GetQualificationTypeList = new List<GetQualificationTypeList>();
                SqlConnection sqlConnection = new SqlConnection(_configuration["ConnectionString:DigiJobCheck"]);
                SqlCommand sqlCommand = new SqlCommand("[usp_GetQualificationTypeList]", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@intQualificationTypeId",QualificationTypeId );
                sqlCommand.Parameters.AddWithValue("@intUserId", UserId);
                await sqlConnection.OpenAsync();
                SqlDataReader sdr = sqlCommand.ExecuteReader();
                while (sdr.Read())
                {
                    GetQualificationTypeList GetQualificationType = new GetQualificationTypeList()
                    {
                        QualificationTypeId = Convert.ToInt32(sdr["QualificationTypeId"]),
                        QualificationTypeName = sdr["QualificationTypeName"].ToString(),
                        QualificationTypeCode = sdr["QualificationTypeCode"].ToString(),
                        CreatedBy=sdr["CreatedBy"].ToString(),
                        CreatedOn=sdr["CreatedOn"].ToString(),
                        UpdatedBy=sdr["UpdatedBy"].ToString(),
                        UpdatedOn=sdr["UpdatedOn"].ToString(),
                        IsActive= sdr["IsActive"].ToString(),
                    };
                    GetQualificationTypeList.Add(GetQualificationType);
                }
                sdr.Close();
                return (GetQualificationTypeList != null && GetQualificationTypeList.Count != 0) ? GetQualificationTypeList : null;

            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
        }

        public string InsertUpdateDeleteLocation(LocationRequestModel LocationInfo)
        {
            try
            {
                SqlConnection sqlConnection = new SqlConnection(_configuration["ConnectionString:DigiJobCheck"]);
                SqlCommand sqlCommand = new SqlCommand("[usp_InsertUpdateDeleteLocation]", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@varType",LocationInfo.ActionType);
                sqlCommand.Parameters.AddWithValue("@intLocationId",LocationInfo.LocationId);
                sqlCommand.Parameters.AddWithValue("@intDistrictId",LocationInfo.DistrictId);
                sqlCommand.Parameters.AddWithValue("@intStateId",LocationInfo.StateId);
                sqlCommand.Parameters.AddWithValue("@varLocationName",LocationInfo.LocationName);
                sqlCommand.Parameters.AddWithValue("@varLocationCode",LocationInfo.LocationCode);
                sqlCommand.Parameters.AddWithValue("@intUserId",LocationInfo.UserId);
                sqlConnection.Open();
                var sdr = sqlCommand.ExecuteReader();
                if (sdr.HasRows)
                {
                    while (sdr.Read())
                    {
                        message = sdr["Message"].ToString();
                    }
                }
               sdr.Close();
               return message;

            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
        }

        public string Department_InsertUpdateDelete(DepartmentRequestModel DepartmentInfo)
        {
            try
            {
                SqlConnection sqlConnection = new SqlConnection(_configuration["ConnectionString:DigiJobCheck"]);
                SqlCommand sqlCommand = new SqlCommand("[usp_InsertUpdateDeleteDepartment]", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@varType", DepartmentInfo.ActionType);
                sqlCommand.Parameters.AddWithValue("@intDepartmentId", DepartmentInfo.DepartmentId);
                sqlCommand.Parameters.AddWithValue("@varDepartmentName", DepartmentInfo.DepartmentName);
                sqlCommand.Parameters.AddWithValue("@varDepartmentCode", DepartmentInfo.DepartmentCode);
                sqlCommand.Parameters.AddWithValue("@intUserId", DepartmentInfo.UserId);
                sqlConnection.Open();
                var sdr = sqlCommand.ExecuteReader();
                if (sdr.HasRows)
                {
                    while (sdr.Read())
                    {
                        message = sdr["Message"].ToString();
                    }
                }
                sdr.Close();
                return message;

            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
        }

        public string InsertUpdateDeleteIndustryType(IndustryTypeRequestModel IndustryTypeInfo)
        {
            try
            {
                SqlConnection sqlConnection = new SqlConnection(_configuration["ConnectionString:DigiJobCheck"]);
                SqlCommand sqlCommand = new SqlCommand("[usp_InsertUpdateDeleteIndustryType]", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@varType", IndustryTypeInfo.ActionType);
                sqlCommand.Parameters.AddWithValue("@intIndustryTypeId", IndustryTypeInfo.IndustryTypeId);
                sqlCommand.Parameters.AddWithValue("@varIndustryTypeName", IndustryTypeInfo.IndustryTypeName);
                sqlCommand.Parameters.AddWithValue("@varIndustryTypeCode", IndustryTypeInfo.IndustryTypeCode);
                sqlCommand.Parameters.AddWithValue("@intUserId", IndustryTypeInfo.UserId);
                sqlConnection.Open();
                var sdr = sqlCommand.ExecuteReader();
                if (sdr.HasRows)
                {
                    while (sdr.Read())
                    {
                        message = sdr["Message"].ToString();
                    }
                }
                sdr.Close();
                return message;
            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }
        }

        public string InsertUpdateDeleteDistrict(DistrictRequestModel DistrictInfo)
        {
            try
            {
                SqlConnection sqlConnection = new SqlConnection(_configuration["ConnectionString:DigiJobCheck"]);
                SqlCommand sqlCommand = new SqlCommand("[usp_InsertUpdateDeleteDistrict]", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@varType", DistrictInfo.ActionType);
                sqlCommand.Parameters.AddWithValue("@intDistrictId", DistrictInfo.DistrictId);
                sqlCommand.Parameters.AddWithValue("@intStateId", DistrictInfo.StateId);
                sqlCommand.Parameters.AddWithValue("@varDistrictName", DistrictInfo.DistrictName);
                sqlCommand.Parameters.AddWithValue("@varDistrictCode", DistrictInfo.DistrictCode);
                sqlCommand.Parameters.AddWithValue("@intUserId", DistrictInfo.UserId);
                sqlConnection.Open();
                var sdr = sqlCommand.ExecuteReader();
                if (sdr.HasRows)
                {
                    while (sdr.Read())
                    {
                        message = sdr["Message"].ToString();
                    }
                }
                sdr.Close();
                return message;
            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }
        }
        public string InsertUpdateDeleteQualificationType(QualificationRequestModel QualificationInfo)
        {
            try
            {
                SqlConnection sqlConnection = new SqlConnection(_configuration["ConnectionString:DigiJobCheck"]);
                SqlCommand sqlCommand = new SqlCommand("[usp_InsertUpdateDeleteQualificationType]", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@varType", QualificationInfo.ActionType);
                sqlCommand.Parameters.AddWithValue("@intQualificationTypeId", QualificationInfo.QualificationTypeId);
                sqlCommand.Parameters.AddWithValue("@varQualificationTypeName", QualificationInfo.QualificationTypeName);
                sqlCommand.Parameters.AddWithValue("@varQualificationTypeCode", QualificationInfo.QualificationTypeCode);
                sqlCommand.Parameters.AddWithValue("@intUserId", QualificationInfo.UserId);
                sqlConnection.Open();
                var sdr = sqlCommand.ExecuteReader();
                if (sdr.HasRows)
                {
                    while (sdr.Read())
                    {
                        message = sdr["Message"].ToString();
                    }
                }
                sdr.Close();
                return message;
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
        }

        public string InsertUpdateDeleteDesignation(DesignationRequestModel DesignationInfo)
        {
            try
            {
                SqlConnection sqlConnection = new SqlConnection(_configuration["ConnectionString:DigiJobCheck"]);
                SqlCommand sqlCommand = new SqlCommand("[usp_InsertUpdateDeleteDesignation]", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@varType", DesignationInfo.ActionType);
                sqlCommand.Parameters.AddWithValue("@intDesignationId", DesignationInfo.DesignationId);
                sqlCommand.Parameters.AddWithValue("@varDesignationName", DesignationInfo.DesignationName);
                sqlCommand.Parameters.AddWithValue("@varDesignationCode", DesignationInfo.DesignationCode);
                sqlCommand.Parameters.AddWithValue("@intUserId", DesignationInfo.UserId);
                sqlConnection.Open();
                var sdr = sqlCommand.ExecuteReader();
                if (sdr.HasRows)
                {
                    while (sdr.Read())
                    {
                        message = sdr["Message"].ToString();
                    }
                }
                sdr.Close();
                return message;
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
        }

        public string InsertUpdateDeleteState(StateRequestModel StateInfo)
        {
            try
            {
                SqlConnection sqlConnection = new SqlConnection(_configuration["ConnectionString:DigiJobCheck"]);
                SqlCommand sqlCommand = new SqlCommand("[usp_InsertUpdateDeleteState]", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@varType", StateInfo.ActionType);
                sqlCommand.Parameters.AddWithValue("@intStateId", StateInfo.StateId);
                sqlCommand.Parameters.AddWithValue("@varStateName", StateInfo.StateName);
                sqlCommand.Parameters.AddWithValue("@varStateCode", StateInfo.StateCode);
                sqlCommand.Parameters.AddWithValue("@intUserId", StateInfo.UserId);
                sqlConnection.Open();
                var sdr = sqlCommand.ExecuteReader();
                if (sdr.HasRows)
                {
                    while (sdr.Read())
                    {
                        message = sdr["Message"].ToString();
                    }
                }
                sdr.Close();
                return message;
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
        }

        public async Task<List<GetStateListResponseModel>> GetStateList(int stateId, int UserId)
        {
            try
            {
                List<GetStateListResponseModel> GetstateList = new List<GetStateListResponseModel>();
                SqlConnection sqlConnection = new SqlConnection(_configuration["ConnectionString:DigiJobCheck"]);
                SqlCommand sqlCommand = new SqlCommand("[usp_GetStateList]", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@intStateId", stateId);
                sqlCommand.Parameters.AddWithValue("@intUserId", UserId);
                await sqlConnection.OpenAsync();
                SqlDataReader sdr = sqlCommand.ExecuteReader();
                while (sdr.Read())
                {
                    GetStateListResponseModel GetStateData = new GetStateListResponseModel()
                    {
                        StateId = Convert.ToInt32(sdr["StateId"]),
                        StateName = sdr["StateName"].ToString(),
                        StateCode= sdr["StateCode"].ToString(),
                        CreatedBy = sdr["CreatedBy"].ToString(),
                        CreatedOn = sdr["CreatedOn"].ToString(),
                        UpdatedBy = sdr["UpdatedBy"].ToString(),
                        UpdatedOn = sdr["UpdatedOn"].ToString(),
                        IsActive = sdr["IsActive"].ToString(),
                    };
                    GetstateList.Add(GetStateData);
                }
                sdr.Close();
                return (GetstateList != null && GetstateList.Count != 0) ? GetstateList : null;
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
        }

        public async Task<List<GetDepartmentListResponseModel>> GetDepartmentList(int DepartmentId, int UserId)
        {
            try
            {
                List<GetDepartmentListResponseModel> GetDepartmentList = new List<GetDepartmentListResponseModel>();
                SqlConnection sqlConnection = new SqlConnection(_configuration["ConnectionString:DigiJobCheck"]);
                SqlCommand sqlCommand = new SqlCommand("[usp_GetDepartmentList]", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("intDepartmentId", DepartmentId);
                sqlCommand.Parameters.AddWithValue("@intUserId", UserId);
                await sqlConnection.OpenAsync();
                SqlDataReader sdr = sqlCommand.ExecuteReader();
                while (sdr.Read())
                {
                    GetDepartmentListResponseModel GetDepartment = new GetDepartmentListResponseModel()
                    {
                        DepartmentId = Convert.ToInt32(sdr["DepartmentId"]),
                        DepartmentName = sdr["DepartmentName"].ToString(),
                        DepartmentCode= sdr["DepartmentCode"].ToString(),
                        CreatedBy = sdr["CreatedBy"].ToString(),
                        CreatedOn = sdr["CreatedOn"].ToString(),
                        UpdatedBy = sdr["UpdatedBy"].ToString(),
                        UpdatedOn = sdr["UpdatedOn"].ToString(),
                        IsActive =  Convert.ToBoolean(sdr["IsActive"]),
                    };
                    GetDepartmentList.Add(GetDepartment);
                }
                sdr.Close();
                return (GetDepartmentList != null && GetDepartmentList.Count != 0) ? GetDepartmentList : null;
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
        }

        public async Task<List<DesignationlistResponseModel>> GetDesignationlist(int DesignationId, int UserId)
        {
            try
            {
                List<DesignationlistResponseModel> GetDesignationlist = new List<DesignationlistResponseModel>();
                SqlConnection sqlConnection = new SqlConnection(_configuration["ConnectionString:DigiJobCheck"]);
                SqlCommand sqlCommand = new SqlCommand("[usp_GetDesignationList]", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@intDesignationId", DesignationId);
                sqlCommand.Parameters.AddWithValue("@intUserId", UserId);
                await sqlConnection.OpenAsync();
                SqlDataReader sdr = sqlCommand.ExecuteReader();
                while (sdr.Read())
                {
                    DesignationlistResponseModel GetDesignation = new DesignationlistResponseModel()
                    {
                        DesignationId = Convert.ToInt32(sdr["DesignationId"]),
                        DesignationName= sdr["DesignationName"].ToString(),
                        DesignationCode = sdr["DesignationCode"].ToString(),
                        CreatedBy = sdr["CreatedBy"].ToString(),
                        CreatedOn = sdr["CreatedOn"].ToString(),
                        UpdatedBy = sdr["UpdatedBy"].ToString(),
                        UpdatedOn = sdr["UpdatedOn"].ToString(),
                        IsActive = Convert.ToBoolean(sdr["IsActive"]),
                    };
                    GetDesignationlist.Add(GetDesignation);
                }
                sdr.Close();
                return (GetDesignationlist != null && GetDesignationlist.Count != 0) ? GetDesignationlist : null;
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
        }

      

    }
}
