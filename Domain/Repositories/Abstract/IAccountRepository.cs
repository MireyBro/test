using bART_Solutions_test.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bArt_test.Domain.Repositories.Abstract
{
    public interface IAccountRepository
    {
        IEnumerable<Account> Get();
        Account Get(int id);
        void Create(Account contact);
        void Update(Account contact);
        Account Delete(int id);
    }
}
