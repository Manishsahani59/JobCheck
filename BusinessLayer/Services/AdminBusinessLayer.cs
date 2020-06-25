using BusinessLayer.Interfaces;
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
    public class AdminBusinessLayer : IAdminBusinessLayer
    {
        IAdminRepositeryLayer AdminRepositeryLayer;
        public AdminBusinessLayer(IAdminRepositeryLayer di_AdminRepsoiteryLayer) {
            AdminRepositeryLayer = di_AdminRepsoiteryLayer;
        }

        public async Task<List<GetDistrictListResponseModel>> GetDistrictList(int UserId, int DistrictId)
        {
            try
            {
              var GetDistrictList = await AdminRepositeryLayer.GetDistrictList(UserId, DistrictId);
                if (GetDistrictList != null && GetDistrictList.Count != 0)
                {
                    return GetDistrictList;
                }
                return null;
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
        }

        public async Task<List<GetIndustryListResponseModel>> GetIndustryList(int IndustryId, int UserId)
        {
            try
            {
                var GetIndustryList = await AdminRepositeryLayer.GetIndustryList(IndustryId, UserId);
                if (GetIndustryList != null && GetIndustryList.Count != 0)
                {
                    return GetIndustryList;
                }
                else { }
                return null;
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
        }

        public async Task<List<GETIndustryTypeResppnseModel>> GETIndustryType()
        {
            try
            {
               var GETIndustryType=await AdminRepositeryLayer.GETIndustryType();
                if (GETIndustryType.Count != 0 && GETIndustryType!=null)
                {
                    return GETIndustryType;
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

        public async Task<List<GetLocationsListResponseModel>> GetLocationsList(int LocationId, int UserId)
        {
            try
            {
                var GetLocationList = await AdminRepositeryLayer.GetLocationsList(LocationId, UserId);
                if (GetLocationList != null && GetLocationList.Count != 0)
                {
                    return GetLocationList;
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

        public async Task<List<GETOpenJobListingResponseModel>> GETOpenJobListing()
        {
            try
            {
                var GETOpenJobListing = await AdminRepositeryLayer.GETOpenJobListing();
                if (GETOpenJobListing != null && GETOpenJobListing.Count != 0)
                {
                    return GETOpenJobListing;
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
                var GetSkillList = await AdminRepositeryLayer.GetSkillTypeList(SkillTypeId, UserId);
                if (GetSkillList != null && GetSkillList.Count != 0)
                {
                    return GetSkillList;
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
