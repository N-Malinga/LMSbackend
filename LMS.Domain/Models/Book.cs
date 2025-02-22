using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace LMS.Domain.Models
{
    public class Book
    {
        [Key]
        public int id { get; set; }
        public string title { get; set; }
        public string author { get; set; }
        public string description { get; set; }
        public string imgLink { get; set; }
        public bool isDeleted { get; set; }
    }
}
