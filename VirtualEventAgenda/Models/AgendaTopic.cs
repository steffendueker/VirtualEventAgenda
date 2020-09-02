using System;
using System.Collections.Generic;

namespace VirtualEventAgenda.Models
{
    public class AgendaTopic
    {
        public string Title { get; set; }
        public int OrderId { get; set; }
        public string Description { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string TeamsUrl { get; set; }
        public string PresentationUrl { get; set; }
    
    }
}