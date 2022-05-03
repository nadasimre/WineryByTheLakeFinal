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
    public class WineController : ControllerBase
    {
        IListing logic;
        IModify logic2;
        IHubContext<SignalRHub> hub;

        public WineController(IListing logic, IModify logic2, IHubContext<SignalRHub> hub)
        {
            this.logic = logic;
            this.logic2 = logic2;
            this.hub = hub;
        }

        [HttpGet("{id}")]
        public Wine GetWine(int id)
        {
            return this.logic.GetWine(id);
        }

        [HttpGet("{supplierid}/supplierid")]
        public IList<Wine> GetWines(int supplierid)
        {
            return this.logic.GetWines(supplierid);
        }

        [HttpGet]
        public IList<Wine> GetAllWines()
        {
            return this.logic.GetAllWines();
        }

        [HttpPost]
        public void CreateWine([FromBody] Wine value)
        {
            this.logic2.InsertWine(value);
            this.hub.Clients.All.SendAsync("WineCreated", value);
        }

        [HttpPut]
        public void Put([FromBody] Wine value)
        {
            this.logic2.UpdateWine(value);
            this.hub.Clients.All.SendAsync("WineUpdated", value);
        }

        [HttpDelete("{id}")]
        public void DeleteWine(int id)
        {
            var wineToDelete = this.logic.GetWine(id);
            this.logic2.RemoveWine(id);
            this.hub.Clients.All.SendAsync("WineDeleted", wineToDelete);
        }

    }
}
