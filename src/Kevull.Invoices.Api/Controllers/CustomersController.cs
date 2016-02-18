using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kevull.Invoices.Entities;
using Kevull.Invoices.Api.Mappers;
using Kevull.Invoices.Api.Models;
using Kevull.Invoices.Services;
using Microsoft.AspNet.Mvc;
using Microsoft.Extensions.Logging;

namespace Kevull.Invoices.Api.Controllers {

    [Route("api/v1/[controller]")]
    public class CustomersController : Controller {
        //[FromServices]
        //public CustomersService CustomersService { get; set; }
        private ICustomersService CustomersService { get; set; }
        public CustomersController(ICustomersService customersService) {
            CustomersService = customersService;
        }

        // GET: api/customers
        // GET: api/customers?name=searchText
        [HttpGet]
        public async Task<IActionResult> Get(string name=null) {
            List<Customer> customers = null;
            if (name == null) {
                customers = await CustomersService.GetAll();
            } else {
                customers = await CustomersService.SearchByName(name);
            }
            if (customers.Count == 0)
                return HttpNotFound();
            else
                return Ok(CustomerMapper.ToModel(customers));
        }

        // GET: api/customers/2
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id) {
            if (id <= 0)
                return HttpNotFound();
            Customer customer = await CustomersService.Get(id);
            if (customer == null)
                return HttpNotFound();
            else
                return new ObjectResult(CustomerMapper.ToModel(customer));
        }

        // GET: api/customerCs/search/searchedText
        //[HttpGet("search/{name}")]
        //public IActionResult Get(string name) {
        //    var customers = CustomersService.GetAll().Where(x => x.Name.Contains(name));
        //    return new ObjectResult(customers);
        //}

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CustomerModel customer) {
            if (customer == null || customer.Id != 0)
                return HttpBadRequest();
            if (!ModelState.IsValid)
                return HttpBadRequest(ModelState);
            try {
                await CustomersService.Save(CustomerMapper.ToEntity(customer));
            } catch (Exception ex) {
                return new HttpErrorResult(
                       new ErrorMessage("No se ha podido actualizar el cliente " + customer.Name, ex.Message));

            }
            return CreatedAtRoute(new { controller = "Customers", id = customer.Id }, customer);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] CustomerModel customer) {
            if (customer == null || id != customer.Id)
                return HttpBadRequest();
            if (!ModelState.IsValid)
                return HttpBadRequest(ModelState);
            try {
                await CustomersService.Save(CustomerMapper.ToEntity(customer));
            } catch (Exception ex) {
                return new HttpErrorResult(
                       new ErrorMessage("No se ha podido actualizar el cliente " + id.ToString(), ex.Message));
            }
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id) {
            if (id <= 0)
                return HttpNotFound();
            try {
                await CustomersService.Delete(id);
            } catch (Microsoft.Data.Entity.DbUpdateConcurrencyException) {
                return  new HttpWarningResult(
                    new ErrorMessage(LogLevel.Warning, ApiErrorCodes.ConcurrencyException,
                    "El cliente " + id.ToString() + " no se ha encontrado o ha sido borrado por otro proceso."));
            } catch (Exception ex) {
                return new HttpErrorResult(
                       new ErrorMessage("No se ha podido borrar cliente " + id.ToString(), ex.Message));
            }
            return Ok();
        }
    }
}
