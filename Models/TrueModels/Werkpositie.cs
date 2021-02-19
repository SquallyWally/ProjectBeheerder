using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ProjectBeheerder.Models.TrueModels
{
    public class Werkpositie
    {
        public byte Id { get; set; }
        [Required]
        public string Name { get; set; }
        public byte Niveau { get; set; }
    }
}