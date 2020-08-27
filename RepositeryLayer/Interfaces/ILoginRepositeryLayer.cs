using CommonLayer.RequestModels;
using CommonLayer.ResponseModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RepositeryLayer.Interfaces
{
   public interface ILoginRepositeryLayer
    {
       
        Task<GetLoginDetailsResponseMOdel> GetLoginList(String LoginName, String UserPassword, String UserType);
        

    }
}
