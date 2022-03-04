using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.DBModels.Core
{
    public class CoreModel
    {
        public int Id { get; set; }
        public bool Status { get; set; }
        public int CreateBy { get; set; } 
        public DateTime CreatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
