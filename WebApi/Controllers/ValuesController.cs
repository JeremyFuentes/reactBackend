﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        #region Prueba
        [HttpGet("Prueba")]

        public string Get() 
        { 
            return "Hola Mundo";
        }
        #endregion
    }
}
