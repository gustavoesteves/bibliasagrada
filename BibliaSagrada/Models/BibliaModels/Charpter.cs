using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BibliaSagrada.Models.BibliaModels
{
    public class Charpter
    {
        public int Id { get; set; }

        [Required]
        public int Number { get; set; }

        [Required]
        public int BookId { get; set; }

        public virtual Book Book { get; set; }

        public virtual ICollection<Vercicle> IdVercicles { get; set; }
    }
}
