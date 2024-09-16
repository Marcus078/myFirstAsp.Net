
using System.ComponentModel.DataAnnotations;

namespace myFirstAsp.Net.Models
{
    public class Userss {
        [Key]
        public int UserId { get; set; }
        public string Name { get; set; }

    }
}
