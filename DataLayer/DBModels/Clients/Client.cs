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
    [Table("Cli_Client")]
    public class Client : CoreModel
    {
        public string Name { get; set; } = null!;
        public string NoIdentification { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public Company Company { get; set; } = null!;
        public int CompanyId { get; set; }
        public ICollection<ClientAddress> Addresses { get; set; } = null!;
    }
}
