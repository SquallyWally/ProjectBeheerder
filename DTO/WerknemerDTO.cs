using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectBeheerder.DTO
{
    public class WerknemerDTO
    {
        public int Id { get; set; }
       
        [StringLength(255)]
        public string Name { get; set; }
        public WerkpositieDTO WerkPositie { get; set; }
        public byte WerkpositieId { get; set; }
        public DateTime? GeboorteDatum { get; set; }
    }
}