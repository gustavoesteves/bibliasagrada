using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BibliaSagrada.Models.BibliaModels
{
    public class Book
    {
        public int Id { get; set; }

        [Required]
        public int Number { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<Charpter> IdCharpters { get; set; }
    }
}
