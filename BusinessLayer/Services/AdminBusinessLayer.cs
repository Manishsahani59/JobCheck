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
    public class AdminBusinessLayer : IAdminBusinessLayer
    {
        IAdminRepositeryLayer AdminRepositeryLayer;
        public AdminBusinessLayer(IAdminRepositeryLayer di_AdminRepsoiteryLayer)
        {
            AdminRepositeryLayer = di_AdminRepsoiteryLayer;
        }

        public string InsertUpdateDeleteDesignation(DesignationRequestModel DesignationInfo)
        {
            try
            {
                var Message = AdminRepositeryLayer.InsertUpdateDeleteDesignation(DesignationInfo);
                return Message;
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
                var Message = AdminRepositeryLayer.InsertUpdateDeleteState(StateInfo);
                return Message;
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
                var Message = AdminRepositeryLayer.InsertUpdateDeleteQualificationType(QualificationInfo);
                return Message;
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
                var GetLocation = AdminRepositeryLayer.InsertUpdateDeleteLocation(LocationInfo);
                return GetLocation;
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
                var Message = AdminRepositeryLayer.Department_InsertUpdateDelete(DepartmentInfo);
                return Message;
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
                var Message = AdminRepositeryLayer.InsertUpdateDeleteIndustryType(IndustryTypeInfo);
                return Message;
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
                var Message = AdminRepositeryLayer.InsertUpdateDeleteDistrict(DistrictInfo);
                return Message;
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
            return null;
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
                var GETIndustryType = await AdminRepositeryLayer.GETIndustryType();
                if (GETIndustryType.Count != 0 && GETIndustryType != null)
                {
                    return GETIndustryType;
                }
                else
                {
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
                else
                {
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
                else
                {
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
                else
                {
                    return null;
                }
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
                var GetQualificationType = await AdminRepositeryLayer.GetQualificationTypeList(QualificationTypeId, UserId);
                if (GetQualificationType != null && GetQualificationType.Count != 0)
                {
                    return GetQualificationType;
                }
                else
                {
                    return null;
                }
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
                var GetStateList = await AdminRepositeryLayer.GetStateList(stateId, UserId);
                if (GetStateList != null && GetStateList.Count != 0)
                {
                    return GetStateList;
                }
                else
                {
                    return null;
                }
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
                var GetDepartmentList = await AdminRepositeryLayer.GetDepartmentList(DepartmentId, UserId);
                if (GetDepartmentList != null && GetDepartmentList.Count != 0)
                {
                    return GetDepartmentList;
                }
                else
                {
                    return null;
                }
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
                var GetDepartmentList = await AdminRepositeryLayer.GetDesignationlist(DesignationId, UserId);
                return (GetDepartmentList != null && GetDepartmentList.Count != 0) ? GetDepartmentList : null;
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }


        }
    }
}
