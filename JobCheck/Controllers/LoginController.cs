using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using BusinessLayer.Interfaces;
using CommonLayer.RequestModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RepositeryLayer.Services;

using System.Net;

using System.Text;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JobCheck.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        ILoginBusinessLayer LoginBusinessLayer;

        public LoginController(ILoginBusinessLayer Di_LoginBusinessLayer)
        {
            LoginBusinessLayer = Di_LoginBusinessLayer;
        }

        [HttpPost]
        [Route("GetLoginDetails")]
        public IActionResult GetLoginDetails([FromBody] LoginDetails sLogin)
        {

            try
            {
                var Message = LoginBusinessLayer.GetLoginList(sLogin.LoginName, sLogin.UserPassword, sLogin.UserType);
                return Ok(new { Message });
                /// 
               
            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }
        }

    }
}
