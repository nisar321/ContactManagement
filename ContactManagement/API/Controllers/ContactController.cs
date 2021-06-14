using BusinessLayer.Models;
using BusinessLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    public class ContactController : ApiController
    {
        private readonly IContactRepository repository;
        public ContactController(IContactRepository contactRepository)
        {
            repository = contactRepository;
        }

        [HttpGet]
        public IList<Contact> Get()
        {
            return repository.GetAll();
            
        }


        [HttpPost]
        public string Add(Contact contact)
        {
            
            if(!repository.Add(contact))
            {
                return "Error adding contact";
            }

            return "Contact Added Successfully!!!";

        }

        [HttpPut]
        public string Update(Contact contact)
        {

            if (!repository.Update(contact))
            {
                return "Error modifying contact";
            }

            return "Contact Modified Successfully!!!";

        }

        [HttpDelete]
        public string Delete(int ID)
        {

            if (!repository.Delete(ID))
            {
                return "Error deleting contact Or No active contact found";
            }

            return "Contact is inactive now";

        }
    }
}
