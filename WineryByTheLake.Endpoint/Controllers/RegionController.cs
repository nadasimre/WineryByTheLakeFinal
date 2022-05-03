using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;
using WineryByTheLake.Endpoint.Services;
using WineryByTheLake.Logic;
using WineryByTheLake.Models;

namespace WineryByTheLake.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RegionController : ControllerBase
    {
        IListing logic;
        IModify logic2;
        IHubContext<SignalRHub> hub;

        public RegionController(IListing logic, IModify logic2, IHubContext<SignalRHub> hub)
        {
            this.logic = logic;
            this.logic2 = logic2;
            this.hub = hub;
        }

        [HttpGet("{id}")]
        public Region GetRegion(int id)
        {
            return this.logic.GetRegion(id);
        }

        [HttpGet]
        public IList<Region> GetAllRegions()
        {
            return this.logic.GetAllRegions();
        }

        [HttpPost]
        public void CreateRegion([FromBody] Region value)
        {
            this.logic2.InsertRegion(value);
            this.hub.Clients.All.SendAsync("RegionCreated", value);
        }

        [HttpPut]
        public void Put([FromBody] Region value)
        {
            this.logic2.UpdateRegion(value);
            this.hub.Clients.All.SendAsync("RegionUpdated", value);
        }

        [HttpDelete("{id}")]
        public void DeleteRegion(int id)
        {
            var regionToDelete = this.logic.GetRegion(id);
            this.logic2.RemoveRegion(id);
            this.hub.Clients.All.SendAsync("RegionDeleted", regionToDelete);
        }
    }
}
