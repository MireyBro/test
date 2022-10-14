using Microsoft.AspNetCore.Mvc;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bART_Solutions_test.Domain.Entities
{
    public class Incident
    {       
        [Key]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public virtual ICollection<Account> Accounts { get; set; }
    }
}
