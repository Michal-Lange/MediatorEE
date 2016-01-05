using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SecureSystemsMediator.Models
{
    public class MediatorPartKey
    {
        [Key]
        public string UserId { get; set; }
        public string PartKey { get; set; }
        public string Module { get; set; }
    }
}