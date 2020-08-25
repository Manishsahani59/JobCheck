using CommanClsLibrary;
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




    }
}
