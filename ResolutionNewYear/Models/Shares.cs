using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ResolutionNewYear.Models
{
    public class Shares
    {
        public int Id { get; set; }
        public string SharedTo { get; set; }
        public string Message { get; set; }
        public string SharedBy { get; set; }
        public int PageId { get; set; }
    }
}