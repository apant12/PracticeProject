using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SampleApi.Data
{
    public class ProjectEntity
    {
        [Key]
        public long ProjectId { get; set; }

        public string Name { get; set; }

        
        [DefaultValue(false)]
        public Boolean IsActive { get; set; }

        public decimal Lat { get; set; }
        public decimal Long { get; set; } 
    }
}
