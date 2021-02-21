using ProjectBeheerder.Models.TrueModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjectBeheerder.ViewModels
{
    public class WerknemerFormViewModel
    {
        public IEnumerable<Werkpositie> Werkposities { get; set; }

        public int? Id { get; set; }

        [Required(ErrorMessage = "Please enter a name.")]
        [StringLength(255)]
        public string Name { get; set; }

        public byte? WerkpositieId { get; set; }
        public DateTime? GeboorteDatum { get; set; }

        public string Title
        {
            get
            {
                return Id != 0 ? "Edit Werknemer" : "New Werknemer";
            }
        }

        public WerknemerFormViewModel()
        {
            Id = 0;
        }

        public WerknemerFormViewModel(Werknemer w)
        {
            Id = w.Id;
            Name = w.Name;
            WerkpositieId = w.WerkpositieId;
            GeboorteDatum = w.GeboorteDatum;
        }
    }
}