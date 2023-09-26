using DuplexCenima.Data;
using DuplexCenima.Data.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DuplexCenima.Models
{
    public class NewMovieVM
    {
        public int Id { get; set;}   

        [Display(Name = "Movie Name")]
        [Required(ErrorMessage ="Name Is Require")]

        public string Name { get; set; }

        [Display(Name = "Movie description")]
        [Required(ErrorMessage = "description Is Require")]

        public string Description { get; set; }

        [Display(Name = "Price In $")]
        [Required(ErrorMessage = "Price Is Require")]
        public double Price { get; set; }
        
        [Display(Name = "Movie Poster URL")]
        [Required(ErrorMessage = "Movie poster URL Is Require")]
        public string ImageURL { get; set; }
        
        [Display(Name = "Start Date")]
        [Required(ErrorMessage = "Start Date is Required")]
        public DateTime StartDate { get; set; }

        [Display(Name = "End Date")]
        [Required(ErrorMessage = "End Date is Required")]
        public DateTime EndDate { get; set; }
        
        [Display(Name = "Select a Category")]
        [Required(ErrorMessage = "Movie Category is Required")]
        public MovieCategory MovieCategory { get; set; }

        [Display(Name = "Select Actors's ")]
        [Required(ErrorMessage = "Movie Actor's is Required")]
        //relationship
        public List<int> ActorIds{ get; set; }

        [Display(Name = "Select a Cinema")]
        [Required(ErrorMessage = "Movie Cinema's is Required")]
        public int CinemaId { get; set; }
        
        [Display(Name = "Select Actors's ")]
        [Required(ErrorMessage = "Movie Actor's is Required")]
        public int ProducerId { get; set; }

    }
}
