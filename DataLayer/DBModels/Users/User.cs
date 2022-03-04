using DataLayer.DBModels.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using DataLayer.DBModels.Companies;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.DBModels
{
    [Table("Usr_User")]
    public class User : CoreModel
    {
        public string FirebaseId { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public Company Company { get; set; } = null!;
        public int CompanyId { get; set; }
    }
}
