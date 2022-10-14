using bART_Solutions_test.Domain.Entities;
using bART_Solutions_test.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bArt_test.Domain.Repositories.Abstract;

namespace bArt_test.Domain.Repositories.EntityFramewok
{
    public class EFIncidentRepository : IIncidentRepository
    {
        private readonly Test_DbContext Context;
        public EFIncidentRepository(Test_DbContext context)
        {
            Context = context;
        }

        public IEnumerable<Incident> Get()
        {
            return Context.Incidents;
        }
        public Incident Get(int Id)
        {
            return Context.Incidents.Find(Id);
        }
        public void Create(Incident incident)
        {
            Context.Incidents.Add(incident);
            Context.SaveChanges();
        }
        public void Update(Incident updatedIncident)
        {
            
        }
        public Incident Delete(int id)
        {
            Incident incident = Get(id);
            if (incident != null)
            {
                Context.Incidents.Remove(incident);
                Context.SaveChanges();
            }
            return incident;
        }
    }
}
