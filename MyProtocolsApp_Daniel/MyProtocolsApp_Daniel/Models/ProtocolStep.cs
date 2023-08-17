using System;
using System.Collections.Generic;
using System.Text;

namespace MyProtocolsApp_Daniel.Models
{
    public class ProtocolStep
    {
        
        public int ProtocolStepsId { get; set; }
        public string Step { get; set; } = null!;
        public string? Description { get; set; }
        public int UserId { get; set; }

        //public virtual User? User { get; set; } = null!;

        //public virtual ICollection<Protocol>? ProtocolProtocols { get; set; }
    }
}
