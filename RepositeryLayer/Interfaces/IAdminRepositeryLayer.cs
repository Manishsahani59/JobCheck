using CommonLayer.ResponseModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RepositeryLayer.Interfaces
{
   public interface IAdminRepositeryLayer
    {
        Task<List<GETIndustryTypeResppnseModel>> GETIndustryType();
        Task<List<GETOpenJobListingResponseModel>> GETOpenJobListing();
        Task<List<GetDistrictListResponseModel>> GetDistrictList(int UserId, int DistrictId);
        Task<List<GetIndustryListResponseModel>> GetIndustryList(int IndustryId, int UserId);
        Task<List<GetSkillTypeListResponseModel>> GetSkillTypeList(int SkillTypeId, int UserId);
        Task<List<GetLocationsListResponseModel>> GetLocationsList(int LocationId, int UserId);
    }
}
