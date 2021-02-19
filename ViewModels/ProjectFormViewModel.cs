using ProjectBeheerder.Models.TrueModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectBeheerder.ViewModels
{
    public class ProjectFormViewModel
    {

        public int? Id { get; set; }
        public IEnumerable<Categorie> Categories { get; set; }
        public byte? CategorieId { get; set; }

        public string Name { get; set; }
        [Display(Name = "Datum")]

        public DateTime? DatumToegevoegd { get; set; }

        public string Title
        {
            get
            {
                return Id != 0 ? "Edit Project" : "New Project";
            }
        }

        public ProjectFormViewModel()
        {
            Id = 0;
        }
        public ProjectFormViewModel(Project project)
        {
            Id = project.Id;
            Name = project.Name;
            DatumToegevoegd = project.DatumToegevoegd;
            CategorieId = project.CategorieId;
        }

    }
}