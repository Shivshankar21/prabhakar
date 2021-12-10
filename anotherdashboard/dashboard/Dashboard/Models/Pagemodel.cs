using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Dashboard.Models
{
    public class Pagemodel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Page_Name { get; set; }
        public string Slug { get; set; }
        public string Category { get; set; }

    }
}
