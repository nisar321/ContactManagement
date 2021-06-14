
using BusinessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Repositories
{
    public interface IContactRepository
    {
        IList<Contact> GetAll();

        bool Add(Contact contact);

        bool Update(Contact contact);

        bool Delete(int ID);
    }
}
