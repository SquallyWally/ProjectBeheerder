using ProjectBeheerder.Models.TrueModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectBeheerder.ViewModels
{
    public class WerknemerFormViewModel
    {
        public IEnumerable<Werkpositie> Werkposities { get; set; }
        public Werknemer Werknemer { get; set; }
    }
}