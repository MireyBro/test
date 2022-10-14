using bART_Solutions_test.Domain.Entities;
using bART_Solutions_test.Domain;
using bArt_test.Domain.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bArt_test.Domain.Repositories.EntityFramewok
{
    public class EFAccountRepository : IAccountRepository
    {
        private readonly Test_DbContext Context;
        public EFAccountRepository(Test_DbContext context)
        {
            Context = context;
        }

        public IEnumerable<Account> Get()
        {
            return Context.Accounts;
        }
        public Account Get(int Id)
        {
            return Context.Accounts.Find(Id);
        }
        public void Create(Account account)
        {
            var accountfromdb = Context.Accounts.Any(x => x.Name == account.Name);
            if (!accountfromdb)
            {
                Context.Accounts.Add(account);
                Context.SaveChanges();
            }
        }
        public void Update(Account updatedAccount)
        {
            
        }
        public Account Delete(int id)
        {
            Account account = Get(id);
            if (account != null)
            {
                Context.Accounts.Remove(account);
                Context.SaveChanges();
            }
            return account;
        }
    }
}
