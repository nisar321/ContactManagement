using BusinessLayer.Models;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly IDBContactManager dbContactManager;
        public ContactRepository()
        {
            dbContactManager = new DBContactManager();
        }

        private DataLayer.Contact GetContactObject(Contact contact)
        {

            var c = new DataLayer.Contact
            {
                ID = contact.ID,
                First_Name = contact.FirstName,
                Last_Name = contact.LastName,
                EMail = contact.EMail,
                Phone_Number = contact.PhoneNumber,
                IsActive = true
            };

            return c;

        }

        public bool Add(Contact contact)
        {
            var result = dbContactManager.Add(GetContactObject(contact));
            if (result == null)
            {
                return false;
            }

            return true;
        }

        public bool Delete(int ID)
        {
            return dbContactManager.Delete(ID);
        }

        public IList<Contact> GetAll()
        {
            return dbContactManager.AllContacts().Select(x => new Contact
            {
                FirstName = x.First_Name,
                LastName = x.Last_Name,
                EMail = x.EMail,
                PhoneNumber = x.Phone_Number
            }).ToList();
        }

        public bool Update(Contact contact)
        {
            var result = dbContactManager.Update(GetContactObject(contact));
            if (result == null)
            {
                return false;
            }

            return true;
        }

    }
}
