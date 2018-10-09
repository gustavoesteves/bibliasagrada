using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BibliaSagrada.Models.BibliaModels
{
    public class BibleUserDetail
    {
        public int Id { get; set; }

        [Required]
        public int Book { get; set; }

        [Required]
        public int Charpter { get; set; }

        [Required]
        public int Vercicle { get; set; }

        [Required]
        [RegularExpression(@"\d[1-9]|20", ErrorMessage = "Podemos exibir de 1 a 10 vercículos.")]
        public int NumbersVercicle { get; set; }

        [Required]
        public bool Inline { get; set; }

        [Required]
        public string ApplicationUserId { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}
