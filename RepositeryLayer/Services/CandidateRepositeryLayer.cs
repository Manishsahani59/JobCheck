using CommanClsLibrary;
using CommonLayer.RequestModels;

using Microsoft.Extensions.Configuration;
using RepositeryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using CommonLayer.CandidateRequestModel;

namespace RepositeryLayer.Services
{
    public class CandidateRepositeryLayer : ICandidateRepositeryLayer
    {
        private readonly IConfiguration _configuration;
        public CandidateRepositeryLayer(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        //GetLocationsListResponseModel GetLocation;
        //SqlDataReader sdr;
        private static string message;



        public string InsertUpdateDeleteCandidatePD(ReqCandidatePersonalDetails sCandidatePersonalDetails)
        {
            MyClass cla = new MyClass();
            List<String> lst = new List<String>();

            List<String> Loglst = new List<String>();

            try
            {
                bool IsLoginInsert = false;
                String ActionType = Convert.ToString(sCandidatePersonalDetails.ActionType);
                String CandidateId = Convert.ToString(sCandidatePersonalDetails.CandidateId);
                String CandidateName = Convert.ToString(sCandidatePersonalDetails.CandidateName);
                String FirstName = Convert.ToString(sCandidatePersonalDetails.FirstName);
                String MiddleName = Convert.ToString(sCandidatePersonalDetails.MiddleName);
                String LastName = Convert.ToString(sCandidatePersonalDetails.LastName);
                String DateOfBirth = Convert.ToString(sCandidatePersonalDetails.DateOfBirth);
                String Gender = Convert.ToString(sCandidatePersonalDetails.Gender);
                String MartialStatus = Convert.ToString(sCandidatePersonalDetails.MartialStatus);
                String MobileNo = Convert.ToString(sCandidatePersonalDetails.MobileNo);
                String LandLineNo = Convert.ToString(sCandidatePersonalDetails.LandLineNo);
                String AlterNameNo = Convert.ToString(sCandidatePersonalDetails.AlterNameNo);
                String EmailId = Convert.ToString(sCandidatePersonalDetails.EmailId);
                String AadharCardNumber = Convert.ToString(sCandidatePersonalDetails.AadharCardNumber);
                String PANNumber = Convert.ToString(sCandidatePersonalDetails.PANNumber);
                String IsActive = Convert.ToString(sCandidatePersonalDetails.IsActive);
                String UserId = Convert.ToString(sCandidatePersonalDetails.UserId);

                String CreatedBy = Convert.ToString(sCandidatePersonalDetails.CreatedBy);
                String LoginName = Convert.ToString(sCandidatePersonalDetails.LoginName);
                String UserPassword = Convert.ToString(sCandidatePersonalDetails.UserPassword);
                String UserType = Convert.ToString(sCandidatePersonalDetails.UserType);
                String RoleId = Convert.ToString(sCandidatePersonalDetails.RoleId);

                if (!String.IsNullOrEmpty(ActionType))
                {
                    lst.Add(ActionType);
                  
                }
                else
                {
                    lst.Add("");
                }

                if (!String.IsNullOrEmpty(CandidateId))
                {
                    lst.Add(CandidateId);
                    
                }
                else
                {
                    lst.Add("");
                }

                if (!String.IsNullOrEmpty(CandidateName))
                {
                    lst.Add(CandidateName);
                }
                else
                {
                    lst.Add("");
                }

                if (!String.IsNullOrEmpty(FirstName))
                {
                    lst.Add(FirstName);
                    
                }
                else
                {
                    lst.Add("");
                }

                if (!String.IsNullOrEmpty(MiddleName))
                {
                    lst.Add(MiddleName);
                    
                }
                else
                {
                    lst.Add("");
                }

                if (!String.IsNullOrEmpty(LastName))
                {
                    lst.Add(LastName);
                    
                }
                else
                {
                    lst.Add("");
                }


                if (!String.IsNullOrEmpty(DateOfBirth))
                {
                    lst.Add(DateOfBirth);
                }
                else
                {
                    lst.Add("");
                }

                if (!String.IsNullOrEmpty(Gender))
                {
                    lst.Add(Gender);
                }
                else
                {
                    lst.Add("");
                }

                if (!String.IsNullOrEmpty(MartialStatus))
                {
                    lst.Add(MartialStatus);
                }
                else
                {
                    lst.Add("");
                }

                if (!String.IsNullOrEmpty(MobileNo))
                {
                    lst.Add(MobileNo);
                    
                }
                else
                {
                    lst.Add("");
                }

                if (!String.IsNullOrEmpty(LandLineNo))
                {
                    lst.Add(LandLineNo);
                }
                else
                {
                    lst.Add("");
                }

                if (!String.IsNullOrEmpty(AlterNameNo))
                {
                    lst.Add(AlterNameNo);
                }
                else
                {
                    lst.Add("");
                }


                if (!String.IsNullOrEmpty(EmailId))
                {
                    lst.Add(EmailId);
                }
                else
                {
                    lst.Add("");
                }

                if (!String.IsNullOrEmpty(AadharCardNumber))
                {
                    lst.Add(AadharCardNumber);
                }
                else
                {
                    lst.Add("");
                }


                if (!String.IsNullOrEmpty(PANNumber))
                {
                    lst.Add(PANNumber);
                }
                else
                {
                    lst.Add("");
                }

                if (!String.IsNullOrEmpty(IsActive))
                {
                    lst.Add(IsActive);
                }
                else
                {
                    lst.Add("");
                }

                if (!String.IsNullOrEmpty(UserId))
                {
                    lst.Add(UserId);
                }
                else
                {
                    lst.Add("");
                }              

                DataSet ds  = cla.GetDataSetByProcedure("usp_InsertUpdateDeleteCandidate", lst);

                if (ds.Tables[0].Rows.Count > 0)
                {

                    message = Convert.ToString(ds.Tables[0].Rows[0]["Message"]);

                    if(!string.IsNullOrEmpty(message) && message.ToLower().Contains("candidate created successfully"))
                    {

                        Loglst.Add(ActionType);//ActionType
                        Loglst.Add("0");//UserId
                        Loglst.Add(FirstName);//FirstName
                        Loglst.Add(MiddleName);//MiddleName
                        Loglst.Add(LastName);//LastName
                        Loglst.Add(LoginName);//LoginName
                        Loglst.Add(UserPassword);//UserPassword
                        Loglst.Add(EmailId);//EmailId
                        Loglst.Add(MobileNo);//MobileNo
                        Loglst.Add(RoleId);//RoleId
                        Loglst.Add(IsActive);//IsActive
                        Loglst.Add(CreatedBy);//CreatedBy
                        Loglst.Add(UserType);//UserType

                        IsLoginInsert = cla.ExecuteByProcedure("usp_InsertUpdateDeleteUserMaster", Loglst);
                        //if (IsLoginInsert)
                        //{
                        //    message = "Insert successful";
                        //}
                        //else
                        //{
                        //    message = "Insert failed";
                        //}
                    }
                }

                return message;

            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
        }

        public string InsertUpdateDeleteCandidateContactDetails(ReqCandidateContactDetails sReqCandidateContactDetails)
        {
            MyClass cla = new MyClass();
            List<String> lst = new List<String>();

            List<String> Loglst = new List<String>();

            try
            {
                bool IsLoginInsert = false;
                String ActionType = Convert.ToString(sReqCandidateContactDetails.ActionType);
                String CandidateContactId = Convert.ToString(sReqCandidateContactDetails.CandidateContactId);
                String CandidateId = Convert.ToString(sReqCandidateContactDetails.CandidateId);                
                String AddressTypeId = Convert.ToString(sReqCandidateContactDetails.AddressTypeId);
                String HouseNo_Building = Convert.ToString(sReqCandidateContactDetails.HouseNo_Building);
                String Street = Convert.ToString(sReqCandidateContactDetails.Street);
                String Area = Convert.ToString(sReqCandidateContactDetails.Area);
                String Town_City = Convert.ToString(sReqCandidateContactDetails.Town_City);
                String StateId = Convert.ToString(sReqCandidateContactDetails.StateId);
                String Country = Convert.ToString(sReqCandidateContactDetails.Country);
                String PINCode = Convert.ToString(sReqCandidateContactDetails.PINCode);
                String ContactNo = Convert.ToString(sReqCandidateContactDetails.ContactNo);
                String CreatedBy = Convert.ToString(sReqCandidateContactDetails.CreatedBy);
                String IsActive = Convert.ToString(sReqCandidateContactDetails.IsActive);
                

                if (!String.IsNullOrEmpty(ActionType))
                {
                    lst.Add(ActionType);

                }
                else
                {
                    lst.Add("");
                }

                if (!String.IsNullOrEmpty(CandidateContactId))
                {
                    lst.Add(CandidateContactId);

                }
                else
                {
                    lst.Add("");
                }

                if (!String.IsNullOrEmpty(CandidateId))
                {
                    lst.Add(CandidateId);

                }
                else
                {
                    lst.Add("");
                }

                if (!String.IsNullOrEmpty(AddressTypeId))
                {
                    lst.Add(AddressTypeId);
                }
                else
                {
                    lst.Add("");
                }

                if (!String.IsNullOrEmpty(HouseNo_Building))
                {
                    lst.Add(HouseNo_Building);

                }
                else
                {
                    lst.Add("");
                }

                if (!String.IsNullOrEmpty(Street))
                {
                    lst.Add(Street);

                }
                else
                {
                    lst.Add("");
                }

                if (!String.IsNullOrEmpty(Area))
                {
                    lst.Add(Area);

                }
                else
                {
                    lst.Add("");
                }


                if (!String.IsNullOrEmpty(Town_City))
                {
                    lst.Add(Town_City);
                }
                else
                {
                    lst.Add("");
                }

                if (!String.IsNullOrEmpty(StateId))
                {
                    lst.Add(StateId);
                }
                else
                {
                    lst.Add("");
                }

                if (!String.IsNullOrEmpty(Country))
                {
                    lst.Add(Country);
                }
                else
                {
                    lst.Add("");
                }

                if (!String.IsNullOrEmpty(PINCode))
                {
                    lst.Add(PINCode);

                }
                else
                {
                    lst.Add("");
                }

                if (!String.IsNullOrEmpty(ContactNo))
                {
                    lst.Add(ContactNo);
                }
                else
                {
                    lst.Add("");
                }

                if (!String.IsNullOrEmpty(CreatedBy))
                {
                    lst.Add(CreatedBy);
                }
                else
                {
                    lst.Add("");
                }


                if (!String.IsNullOrEmpty(IsActive))
                {
                    lst.Add(IsActive);
                }
                else
                {
                    lst.Add("");
                }

                

                DataSet ds = cla.GetDataSetByProcedure("usp_InsertUpdateDeleteCandidateContactDetails", lst);

                if (ds.Tables[0].Rows.Count > 0)
                {

                    message = Convert.ToString(ds.Tables[0].Rows[0]["Message"]);

                   
                }

                return message;

            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
        }



        public string InsertUpdateDeleteCandidateWorkExperience(ReqCandidateWorkExperienceDetails sCandidateWorkExperienceDetails)
        {
            MyClass cla = new MyClass();
            List<String> lst = new List<String>();

            List<String> Loglst = new List<String>();

            try
            {
                bool IsLoginInsert = false;
                String ActionType = Convert.ToString(sCandidateWorkExperienceDetails.ActionType);
                String CandidateWorkExpId = Convert.ToString(sCandidateWorkExperienceDetails.CandidateWorkExpId);
                String CandidateId = Convert.ToString(sCandidateWorkExperienceDetails.CandidateId);
                String CompanyName = Convert.ToString(sCandidateWorkExperienceDetails.CompanyName);
                String FromDate = Convert.ToString(sCandidateWorkExperienceDetails.FromDate);
                String ToDate = Convert.ToString(sCandidateWorkExperienceDetails.ToDate);
                String LastDesignation = Convert.ToString(sCandidateWorkExperienceDetails.LastDesignation);
                String LastCTC = Convert.ToString(sCandidateWorkExperienceDetails.LastCTC);
                String ReferenceName = Convert.ToString(sCandidateWorkExperienceDetails.ReferenceName);
                String ReferenceDesignation = Convert.ToString(sCandidateWorkExperienceDetails.ReferenceDesignation);
                String ReferenceContactNo = Convert.ToString(sCandidateWorkExperienceDetails.ReferenceContactNo);
                String CreatedBy = Convert.ToString(sCandidateWorkExperienceDetails.CreatedBy);
                String IsActive = Convert.ToString(sCandidateWorkExperienceDetails.IsActive);
                

                if (!String.IsNullOrEmpty(ActionType))
                {
                    lst.Add(ActionType);

                }
                else
                {
                    lst.Add("");
                }
                if (!String.IsNullOrEmpty(CandidateWorkExpId))
                {
                    lst.Add(CandidateWorkExpId);

                }
                else
                {
                    lst.Add("");
                }

                if (!String.IsNullOrEmpty(CandidateId))
                {
                    lst.Add(CandidateId);

                }
                else
                {
                    lst.Add("");
                }

                if (!String.IsNullOrEmpty(CompanyName))
                {
                    lst.Add(CompanyName);
                }
                else
                {
                    lst.Add("");
                }

                if (!String.IsNullOrEmpty(FromDate))
                {
                    lst.Add(FromDate);

                }
                else
                {
                    lst.Add("");
                }

                if (!String.IsNullOrEmpty(ToDate))
                {
                    lst.Add(ToDate);

                }
                else
                {
                    lst.Add("");
                }

                if (!String.IsNullOrEmpty(LastDesignation))
                {
                    lst.Add(LastDesignation);

                }
                else
                {
                    lst.Add("");
                }


                if (!String.IsNullOrEmpty(LastCTC))
                {
                    lst.Add(LastCTC);
                }
                else
                {
                    lst.Add("");
                }

                if (!String.IsNullOrEmpty(ReferenceName))
                {
                    lst.Add(ReferenceName);
                }
                else
                {
                    lst.Add("");
                }

                if (!String.IsNullOrEmpty(ReferenceDesignation))
                {
                    lst.Add(ReferenceDesignation);
                }
                else
                {
                    lst.Add("");
                }

                if (!String.IsNullOrEmpty(ReferenceContactNo))
                {
                    lst.Add(ReferenceContactNo);

                }
                else
                {
                    lst.Add("");
                }

                if (!String.IsNullOrEmpty(CreatedBy))
                {
                    lst.Add(CreatedBy);
                }
                else
                {
                    lst.Add("");
                }

                if (!String.IsNullOrEmpty(IsActive))
                {
                    lst.Add(IsActive);
                }
                else
                {
                    lst.Add("");
                }
                DataSet ds = cla.GetDataSetByProcedure("usp_InsertUpdateDeleteCandidateWorkExperienceDetails", lst);

                if (ds.Tables[0].Rows.Count > 0)
                {

                    message = Convert.ToString(ds.Tables[0].Rows[0]["Message"]);

                   
                }

                return message;

            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
        }



    }
}
