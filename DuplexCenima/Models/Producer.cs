﻿using System.ComponentModel.DataAnnotations;

namespace DuplexCenima.Models
{
    public class Producer
    {
        [Key]
        public int Id { get; set; }
        public string ProfilePictureURL { get; set; }
        public string FullName { get; set;}
        public string Bio { get; set; }

        //Relationship
        public List <Movie> Movies { get; set; }
    }
}
