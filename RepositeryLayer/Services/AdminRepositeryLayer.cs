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
                if (IndustryTypes.Count != 0 && IndustryTypes != null) {
                    return IndustryTypes;
                }
                return null;

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
                while (sdr.Read())
                {
                    GETOpenJobListingResponseModel GetOpenJob = new GETOpenJobListingResponseModel();
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
                    GetOpenJob.IndustryType= sdr["IndustryType"].ToString();
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
                sdr.Close();
                if (OpenJobListing != null && OpenJobListing.Count != 0)
                {
                    return OpenJobListing;
                }
                else {
                    return null;
                }
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
                    GetDistrict.StateId = Convert.ToInt32(sdr["StateId"]);
                    GetDistrict.StateName = sdr["StateName"].ToString();
                    GetDistrict.CreatedBy= sdr["StateId"].ToString();
                    GetDistrict.CreatedOn= sdr["StateId"].ToString();
                    GetDistrict.UpdatedBy = sdr["StateId"].ToString();
                    GetDistrict.UpdatedOn = sdr["StateId"].ToString();
                    GetDistrict.isActive = Convert.ToBoolean(sdr["isActive"]);
                    DistrictList.Add(GetDistrict);
                }
                sdr.Close();
                if (DistrictList != null && DistrictList.Count!=0)
                {
                    return DistrictList;
                }
                else {
                    return null;
                }
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
                if (IndustryList != null && IndustryList.Count != 0)
                {
                    return IndustryList;
                }
                else {
                    return null;
                }
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
                        IsActive=Convert.ToBoolean(sdr["IsActive"]),
                    };
                    GetSkillTypeList.Add(GetSkill);
                }
                sdr.Close();
                if (GetSkillTypeList != null && GetSkillTypeList.Count != 0)
                {
                    return GetSkillTypeList;
                }
                else { return null; }
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
                        IsActive=Convert.ToBoolean(sdr["IsActive"]),
                    };
                    GetLocationsList.Add(GetLocation);
                }
                sdr.Close();
                if (GetLocationsList != null && GetLocationsList.Count != 0)
                {
                    return GetLocationsList;
                }
                else {
                    return null;
                }
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
        }
    }
}
