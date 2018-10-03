using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BibliaSagrada.Models.BibliaModels
{
    public class Vercicle
    {
        public int Id { get; set; }

        [Required]
        public int Number { get; set; }

        [Required]
        public string Text { get; set; }

        [Required]
        public int CharpterId { get; set; }

        public virtual Charpter Charpter { get; set; }
    }
}
