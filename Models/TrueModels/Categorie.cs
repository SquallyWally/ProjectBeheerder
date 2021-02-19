using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ProjectBeheerder.Models.TrueModels
{
    public class Categorie
    {
        public byte Id { get; set; }
        [Required]
        public string name { get; set; }
        public byte MinimumAantalUren { get; set; }
        public static readonly byte noId = 0;
        public static readonly byte hasId = 1;
    }
}