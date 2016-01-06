using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SecureSystemsMediator.Models
{
    public class MediatorPartKey
    {
        [Key]
        [Column(TypeName = "VARCHAR")]
        [StringLength(128)]
        public string UserServiceKey { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(128)]
        public string PartKey { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(128)]
        public string Module { get; set; }
    }
}