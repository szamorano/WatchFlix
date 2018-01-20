using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WatchFlix.Models;
using System.Data.Entity;
using WatchFlix.DTOs;
using AutoMapper;

namespace WatchFlix.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext db;

        public CustomersController()
        {
            db = new ApplicationDbContext();
        }

        // GET /api/customers
        public IHttpActionResult GetCustomers()
        {
            var customerDtos = db.Customers.ToList().Select(Mapper.Map<Customer, CustomerDTO>);

            return Ok(customerDtos);
        }

        // GET /api/customers/1
        public IHttpActionResult GetCustomer(int id)
        {
            var customer = db.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return NotFound();

            return Ok(Mapper.Map<Customer, CustomerDTO>(customer));
        }

        // POST /api/customers
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDTO customerDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var customer =  Mapper.Map<CustomerDTO, Customer> (customerDTO);
            db.Customers.Add(customer);
            db.SaveChanges();

            customerDTO.Id = customer.Id;

            return Created(new Uri(Request.RequestUri + "/" + customer.Id), customerDTO);
        }

        // PUT /api/customers/1
        [HttpPut]
        public IHttpActionResult UpdateCustomer(int id, CustomerDTO customerDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var customerInDb = db.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
                return NotFound();

            Mapper.Map(customerDTO, customerInDb);


            db.SaveChanges();

            return Ok();
        }

        // DELETE /api/customers/1
        [HttpDelete]
        public IHttpActionResult DeleteCustomer(int id)
        {
            var customerInDb = db.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
                return NotFound();

            db.Customers.Remove(customerInDb);
            db.SaveChanges();

            return Ok();
        }

    }
}
