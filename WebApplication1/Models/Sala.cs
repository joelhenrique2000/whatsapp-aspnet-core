using RepositoryHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    [Table("Sala")]
    public class Sala {
        [PrimaryKey]
        [IdentityIgnore]
        public long Id { get; set; }

        public string Titulo { get; set; }

        [IdentityIgnore]
        public string IdUsuario { get; set; }

        [IdentityIgnore]
        public long IdSala { get; set; }
    }
}
