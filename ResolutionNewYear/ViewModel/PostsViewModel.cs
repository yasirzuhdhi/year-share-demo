using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ResolutionNewYear.Models;

namespace ResolutionNewYear.ViewModel
{
    public class PostViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public ICollection<Posted> Posts { get; set; }
    }
    public class Posted
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public int PageId { get; set; }
        public PostType PostedType { get; set; }
    }
}