
using DataLayer.DBModels.Core;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.DBModels.Companies
{
    [Table("Sis_Company")]
    public class Company : CoreModel
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string LogoUrl { get; set; } = null!;
    }
}