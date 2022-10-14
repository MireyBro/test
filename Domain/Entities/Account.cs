using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bART_Solutions_test.Domain.Entities
{
    [Index(nameof(Name), IsUnique = true)]
    public class Account
    {
        [Key]
        public int Id { get; set; }
        [Required]              
        public string Name { get; set; }                              
        [Required]
        public virtual ICollection<Contact> Contacts { get; set; }
        public string? IncidentName { get; set; }
        public Incident Incident { get; set; }
    }
}
