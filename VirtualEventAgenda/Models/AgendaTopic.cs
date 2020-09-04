using System;
using System.Text;
using System.Text.Json;
using System.Collections.Generic;

namespace VirtualEventAgenda.Models
{
    public class AgendaTopic
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int? OrderId { get; set; }
        public string Description { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string TeamsUrl { get; set; }
        public string PresentationUrl { get; set; }

        public override string ToString() => JsonSerializer.Serialize<AgendaTopic>(this);
    }
}