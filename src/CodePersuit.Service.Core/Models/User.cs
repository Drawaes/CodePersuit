using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CodePersuit.Service.Core.Models
{
    public class User
    {
        public int UserId { get; set; }
        [StringLength(255)]
        [Required]
        public string Username { get; set; }
    }
}
