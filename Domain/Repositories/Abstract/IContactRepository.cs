using bART_Solutions_test.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bArt_test.Domain.Repositories.Abstract
{
    public interface IContactRepository
    {
        IEnumerable<Contact> Get();
        Contact Get(int id);
        void Create(Contact contact);
        void Update(Contact contact);
        Contact Delete(int id);
    }
}
