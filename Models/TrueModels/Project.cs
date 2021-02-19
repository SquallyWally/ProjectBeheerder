using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ProjectBeheerder.Models.TrueModels
{
    public class Project
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter a name")]
        [StringLength(255)]
        public string Name { get; set; }
        public Categorie Categorie { get; set; }
        public byte CategorieId { get; set; }

        [Display(Name = "Datum")]
        public DateTime DatumToegevoegd { get; set; }
    }
}