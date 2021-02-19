using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectBeheerder.Models.TrueModels
{
    public class Werknemer
    {

        
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter a name.")]
        [StringLength(255)]
        public string Name { get; set; }
        public Werkpositie WerkPositie { get; set; }
        public byte WerkpositieId { get; set; }
        public DateTime? GeboorteDatum { get; set; }
    }
}