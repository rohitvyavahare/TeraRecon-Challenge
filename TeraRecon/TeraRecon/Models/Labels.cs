using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;


namespace TeraRecon.Models
{
    public class Labels
    {
        [Key]
        public int Id {get;set;}
        public string item {get; set;}
        public string label {get; set;}
    }

    public class LabelDBContext : DbContext
    {
        public DbSet<Labels> labels { get; set; }
    }
}