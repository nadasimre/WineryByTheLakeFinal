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
    public class SupplierController
    {
        IListing logic;
        IModify logic2;
        IHubContext<SignalRHub> hub;

        public SupplierController(IListing logic, IModify logic2, IHubContext<SignalRHub> hub)   
        {
            this.logic = logic;
            this.logic2 = logic2;
            this.hub = hub;
        }

        [HttpGet("{id}")]
        public Supplier GetSupplier(int id)
        {
            return this.logic.GetSupplier(id);
        }

        [HttpGet("{regionid}/regionid")]
        public IList<Supplier> GetSuppliers(int regionid)
        {
            return this.logic.GetSuppliers(regionid);
        }

        [HttpGet]
        public IList<Supplier> GetAllSuppliers()
        {
            return this.logic.GetAllSuppliers();
        }

        [HttpPost]
        public void CreateSupplier([FromBody] Supplier value)
        {
            this.logic2.InsertSupplier(value);
            this.hub.Clients.All.SendAsync("SupplierCreated", value);
        }

        [HttpPut]
        public void Put([FromBody] Supplier value)
        {
            this.logic2.UpdateSupplier(value);
            this.hub.Clients.All.SendAsync("SupplierUpdated", value);
        }

        [HttpDelete("{id}")]
        public void DeleteSupplier(int id)
        {
            var supplierToDelete = this.logic.GetSupplier(id);
            this.logic2.RemoveSupplier(id);
            this.hub.Clients.All.SendAsync("SupplierDeleted", supplierToDelete);
        }
    }
}
