using bART_Solutions_test.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bArt_test.Domain.Repositories.Abstract
{
    public interface IIncidentRepository
    {
        IEnumerable<Incident> Get();
        Incident Get(int id);
        void Create(Incident contact);
        void Update(Incident contact);
        Incident Delete(int id);
    }
}
