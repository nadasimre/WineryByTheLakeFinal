using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WineryByTheLake.Endpoint.Services;
using WineryByTheLake.Logic;
using WineryByTheLake.Models;

namespace WineryByTheLake.Endpoint.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        IProduct logic;

        public ProductController(IProduct logic)
        {
            this.logic = logic;
        }

        [HttpGet]
        public ICollection<Wine> Red()
        {
            return this.logic.Red();
        }

        [HttpGet]
        public ICollection<Wine> White()
        {
            return this.logic.White();
        }

        [HttpGet]
        public ICollection<Wine> Rose()
        {
            return this.logic.Rose();
        }
    }
}
