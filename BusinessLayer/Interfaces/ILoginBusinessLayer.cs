using CommonLayer.RequestModels;
using CommonLayer.ResponseModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
    public interface ILoginBusinessLayer
    {
               
        Task<GetLoginDetailsResponseMOdel> GetLoginList(String LoginName, String UserPassword, String UserType);
       
        
    }

}
