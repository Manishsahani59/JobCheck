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
    public class LoginRepositeryLayer : ILoginRepositeryLayer
    {
        private readonly IConfiguration _configuration;
        public LoginRepositeryLayer(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        //GetLocationsListResponseModel GetLocation;
        //SqlDataReader sdr;
        private static string message;


     
       

        public async Task<List<GetLoginDetailsResponseMOdel>>GetLoginList(String LoginName, String UserPassword, String UserType)
        {
            try
            {
                List<GetLoginDetailsResponseMOdel> LoginDetails = new List<GetLoginDetailsResponseMOdel>();
                DataTable dt = new DataTable();
                await using(SqlConnection connection = new SqlConnection(_configuration["ConnectionString:DigiJobCheck"]))
                {
                    SqlCommand command = new SqlCommand();
                    command.Connection = connection;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "usp_GetLoginDetails";
                   // await connection.OpenAsync();
                    connection.Open();
                    command.Parameters.AddWithValue("@LoginName", LoginName);
                    command.Parameters.AddWithValue("@UserPassword", UserPassword);
                    command.Parameters.AddWithValue("@UserType", UserType);
                    SqlDataAdapter da = new SqlDataAdapter(command);
                    
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        string sMess = Convert.ToString(dt.Rows[0]["Errormsg"]);
                        GetLoginDetailsResponseMOdel myLoginDetails = new GetLoginDetailsResponseMOdel();
                        if (!string.IsNullOrEmpty(sMess) && sMess.ToLower().Contains("login successful"))
                        {

                            myLoginDetails.UserId = Convert.ToInt32(dt.Rows[0]["UserId"]);
                            myLoginDetails.UserFirstName = Convert.ToString(dt.Rows[0]["UserFirstName"]);
                            myLoginDetails.UserMiddleName = Convert.ToString(dt.Rows[0]["UserMiddleName"]);
                            myLoginDetails.UserLastName = Convert.ToString(dt.Rows[0]["UserLastName"]);
                            myLoginDetails.LoginName = Convert.ToString(dt.Rows[0]["LoginName"]);
                            myLoginDetails.UserPassword = Convert.ToString(dt.Rows[0]["UserPassword"]);
                            myLoginDetails.EmailId = Convert.ToString(dt.Rows[0]["EmailId"]);
                            myLoginDetails.MobileNo = Convert.ToString(dt.Rows[0]["MobileNo"]);
                            myLoginDetails.RoleId = Convert.ToString(dt.Rows[0]["RoleId"]);
                            myLoginDetails.IsActive = Convert.ToString(dt.Rows[0]["IsActive"]);
                            myLoginDetails.CreatedDate = Convert.ToString(dt.Rows[0]["CreatedDate"]);
                            myLoginDetails.CreatedBy = Convert.ToString(dt.Rows[0]["CreatedBy"]);
                            myLoginDetails.UpdatedDate = Convert.ToString(dt.Rows[0]["UpdatedDate"]);
                            myLoginDetails.UpdatedBy = Convert.ToString(dt.Rows[0]["UpdatedBy"]);
                            myLoginDetails.DeletedDate = Convert.ToString(dt.Rows[0]["DeletedDate"]);
                            myLoginDetails.DeletedBy = Convert.ToString(dt.Rows[0]["DeletedBy"]);
                            myLoginDetails.Errormsg = Convert.ToString(dt.Rows[0]["Errormsg"]);
                        }
                        else
                        {
                            myLoginDetails.Errormsg = Convert.ToString(dt.Rows[0]["Errormsg"]);
                        }
                        LoginDetails.Add(myLoginDetails);

                        if (connection != null) { connection.Close(); }
                        command.Dispose();

                }

                

                   
                }
                return (LoginDetails != null && LoginDetails.Count != 0) ? LoginDetails : null;

            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
                // return dt;
            }

            //SqlConnection sqlConnection = new SqlConnection(_configuration["ConnectionString:DigiJobCheck"]);
            //SqlCommand sqlCommand = new SqlCommand("usp_GetLoginDetails", sqlConnection);
            //sqlCommand.CommandType = CommandType.StoredProcedure;
            //sqlCommand.Parameters.AddWithValue("@LoginName", LoginName);
            //sqlCommand.Parameters.AddWithValue("@UserPassword", UserPassword);
            //await sqlConnection.OpenAsync();
            //SqlDataReader sdr = sqlCommand.ExecuteReader();
            //while (sdr.Read())
            //{

            //    GetLoginDetailsResponseMOdel myLoginDetails = new GetLoginDetailsResponseMOdel();
            //    myLoginDetails.UserId = Convert.ToInt32(sdr["UserId"]);
            //    myLoginDetails.UserFirstName = Convert.ToString(sdr["UserFirstName"]);
            //    myLoginDetails.UserMiddleName = Convert.ToString(sdr["UserMiddleName"]);
            //    myLoginDetails.UserLastName = Convert.ToString(sdr["UserLastName"]);
            //    myLoginDetails.LoginName = Convert.ToString(sdr["LoginName"]);
            //    myLoginDetails.UserPassword = Convert.ToString(sdr["UserPassword"]);
            //    myLoginDetails.EmailId = Convert.ToString(sdr["EmailId"]);
            //    myLoginDetails.MobileNo = Convert.ToString(sdr["MobileNo"]);
            //    myLoginDetails.RoleId = Convert.ToString(sdr["RoleId"]);

            //    myLoginDetails.IsActive = Convert.ToString(sdr["IsActive"]);
            //    myLoginDetails.CreatedDate = Convert.ToString(sdr["CreatedDate"]);
            //    myLoginDetails.CreatedBy = Convert.ToString(sdr["CreatedBy"]);
            //    myLoginDetails.UpdatedDate = Convert.ToString(sdr["UpdatedDate"]);
            //    myLoginDetails.UpdatedBy = Convert.ToString(sdr["UpdatedBy"]);
            //    myLoginDetails.DeletedDate = Convert.ToString(sdr["DeletedDate"]);
            //    myLoginDetails.DeletedBy = Convert.ToString(sdr["DeletedBy"]);
            //    myLoginDetails.Errormsg = Convert.ToString(sdr["Errormsg"]);  
            //    LoginDetails.Add(myLoginDetails);
            //}
            //sdr.Close();
            //return (LoginDetails != null && LoginDetails.Count != 0) ? LoginDetails : null;

        }
            //catch (Exception e)
            //{

            //    throw new ApplicationException(e.Message);
            //}
       // }

       
    }
}
