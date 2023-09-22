using DuplexCenima.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace DuplexCenima.Models
{
    public class Producer: iEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Profile Picture URL")]
        public string ProfilePictureURL { get; set; }

        [Display(Name = "Full Name")]
        public string FullName { get; set;}

        [Display(Name = "Biography")]
        public string Bio { get; set; }

        //Relationship
        public List <Movie> Movies { get; set; }
    }
}
