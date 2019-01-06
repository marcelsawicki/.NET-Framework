using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CyrensService.Models
{
    public class Stories
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Picture { get; set; }
        public string Subscription { get; set; }
        public string Comment { get; set; }
        public int Likes { get; set; }
        public int Unlikes { get; set; }
    }
}
