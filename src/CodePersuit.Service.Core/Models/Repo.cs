using System;
using System.Collections.Generic;
using System.Text;

namespace CodePersuit.Service.Core.Models
{
    public class Repo
    {
        public string Name { get; set; }
        public int RepositoryId { get; set; }
        public int OwnerId { get; set; }
    }
}
