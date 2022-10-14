using bART_Solutions_test.Domain;
using bART_Solutions_test.Domain.Entities;
using bArt_test.Domain.Repositories.Abstract;

using System.Collections.Generic;


namespace bArt_test.Domain.Repositories.EntityFramewok
{
    public class EFContactRepository : IContactRepository
    {
        private readonly Test_DbContext Context;
        
        public EFContactRepository(Test_DbContext context)
        {
            Context = context;           
        }
       
        public IEnumerable<Contact> Get()
        {
            return Context.Contacts;
        }
        public Contact Get(int id)
        {
            return Context.Contacts.Find(id);
        }
        public Contact GetByEmail(object email)
        {
            return Context.Contacts.Find(email);
        }
        public void Create(Contact contact)
        {
            Context.Contacts.Add(contact);
            Context.SaveChanges();
        }          
        public void Update(Contact entryContact)
        {
            
        }
            
        public Contact Delete(int id)
        {
            Contact contact = Get(id);
            if (contact != null)
            {
                Context.Contacts.Remove(contact);
                Context.SaveChanges();
            }
            return contact;
        }
    }
}
