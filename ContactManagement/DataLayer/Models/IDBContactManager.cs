using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public interface IDBContactManager
    {

        IList<Contact> AllContacts();

        Contact Add(Contact contact);

        Contact Update(Contact contact);

        bool Delete(int ID);
    }
}
