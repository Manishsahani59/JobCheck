using CommonLayer.RequestModels;
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
        Task<List<GetQualificationTypeList>> GetQualificationTypeList(int QualificationTypeId, int UserId);
        Task<List<GetStateListResponseModel>> GetStateList(int stateId, int UserId);
        Task<List<GetDepartmentListResponseModel>> GetDepartmentList(int DepartmentId, int UserId);
        Task<List<DesignationlistResponseModel>> GetDesignationlist(int DesignationId, int UserId);
        
        string InsertUpdateDeleteLocation(LocationRequestModel LocationInfo);
        string Department_InsertUpdateDelete(DepartmentRequestModel DepartmentInfo);
        string InsertUpdateDeleteIndustryType(IndustryTypeRequestModel IndustryTypeInfo);
        string InsertUpdateDeleteDistrict(DistrictRequestModel DistrictInfo);
        string InsertUpdateDeleteQualificationType(QualificationRequestModel QualificationInfo);
        string InsertUpdateDeleteDesignation(DesignationRequestModel DesignationInfo);
        string InsertUpdateDeleteState(StateRequestModel StateInfo);
        string InsertUpdateDeleteSkillType(SkillTypeRequestModel SkillTypeInfo);

        string InsertUpdateDeleteJobType(JobTypeRequestModel JobTypeInfo);

    }
}
