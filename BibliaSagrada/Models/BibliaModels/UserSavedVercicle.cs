using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BibliaSagrada.Models.BibliaModels
{
    public class UserSavedVercicle
    {
        public int Id { get; set; }

        public string Comment { get; set; }

        [Required]
        public int VercicleId { get; set; }

        public virtual Vercicle Vercicle { get; set; }

        [Required]
        public string ApplicationUserId { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}
