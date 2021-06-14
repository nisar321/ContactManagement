using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class DBContactManager : IDBContactManager
    {
        private Contact ManageNull(Contact OriginalContact, Contact MatchedContact)
        {
            OriginalContact.ID = OriginalContact.ID == null ? MatchedContact.ID : OriginalContact.ID;
            OriginalContact.First_Name = OriginalContact.ID == null ? MatchedContact.First_Name : OriginalContact.First_Name;
            OriginalContact.Last_Name= OriginalContact.Last_Name == null ? MatchedContact.Last_Name : OriginalContact.Last_Name;
            OriginalContact.EMail = OriginalContact.EMail == null ? MatchedContact.EMail : OriginalContact.EMail;
            OriginalContact.Phone_Number = OriginalContact.Phone_Number == null ? MatchedContact.Phone_Number : OriginalContact.Phone_Number;
            return OriginalContact;
        }

        public Contact Add(Contact contact)
        {
            Contact result = null;
            try
            {
                using (var db = new ContactManagerEntities())
                {
                    var existingContact = db.Contacts.Where(x => x.EMail == contact.EMail
                    && x.First_Name == contact.First_Name
                    && x.Last_Name == contact.Last_Name
                    && x.Phone_Number == contact.Phone_Number)
                        .FirstOrDefault();
                    if (existingContact != null)
                    {
                        return null;
                    }

                    result = db.Contacts.Add(contact);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                result = null;
            }

            return result;
        }

        public bool Delete(int ID)
        {
            try
            {
                using (var db = new ContactManagerEntities())
                {
                    var result = db.Contacts.Where(x => x.ID == ID && x.IsActive == true).FirstOrDefault();
                    if (result == null)
                    {
                        return false;
                    }
                    result.IsActive = false;
                    db.Entry(result).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return true;

                }
            }
            catch (Exception ex)
            {

            }

            return false;
        }

        public IList<Contact> AllContacts()
        {
            IList<Contact> contacts = null;
            using (var db = new ContactManagerEntities())
            {
                contacts = db.Contacts.ToList();
            }

            return contacts;
        }

        public Contact Update(Contact contact)
        {
            Contact result = null;
            try
            {
                using (var db = new ContactManagerEntities())
                {
                    result = db.Contacts.Where(x => x.ID == contact.ID).FirstOrDefault();
                    if (result == null)
                    {
                        return null;
                    }

                    result.First_Name = contact.First_Name == null ? result.First_Name : contact.First_Name;
                    result.Last_Name = contact.Last_Name == null ? result.Last_Name : contact.Last_Name;
                    result.EMail = contact.EMail == null ? result.EMail : contact.EMail;
                    result.Phone_Number = contact.Phone_Number == null ? result.Phone_Number : contact.Phone_Number;
                    db.Entry(result).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                result = null;
            }

            return result;
        }
    }
}
