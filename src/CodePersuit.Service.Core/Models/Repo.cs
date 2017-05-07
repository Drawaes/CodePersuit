using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CodePersuit.Service.Core.Models
{
    public class Repo
    {
        [StringLength(255)]
        [Required]
        public string Name { get; set; }
        public int RepositoryId { get; set; }
        public int OwnerId { get; set; }
    }
}
