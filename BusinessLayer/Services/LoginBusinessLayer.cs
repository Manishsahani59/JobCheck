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
    public class LoginBusinessLayer : ILoginBusinessLayer
    {
        ILoginRepositeryLayer LoginRepositeryLayer;
        public LoginBusinessLayer(ILoginRepositeryLayer di_LoginRepsoiteryLayer)
        {
            LoginRepositeryLayer = di_LoginRepsoiteryLayer;
        }
        
        public async Task<GetLoginDetailsResponseMOdel> GetLoginList(String LoginName, String UserPassword, String UserType)
        {
            try
            {
                var GetLogingDetails= await LoginRepositeryLayer.GetLoginList(LoginName, UserPassword, UserType);
                if (GetLogingDetails != null )
                {
                    return GetLogingDetails;
                }
                return null;
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
        }

       
    }
}
