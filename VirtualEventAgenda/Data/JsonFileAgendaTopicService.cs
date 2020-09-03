using System;
using System.IO;
using System.Threading.Tasks;
using System.Net.Http;
using System.Linq;
using System.Text.Json;
using System.Collections.Generic;
using VirtualEventAgenda.Models;
using Microsoft.AspNetCore.Hosting;

namespace VirtualEventAgenda.Data
{
    public class JsonFileAgendaTopicService
    {
      public JsonFileAgendaTopicService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }

        public IWebHostEnvironment WebHostEnvironment { get; }

        private string JsonFileName
        {
            get { return Path.Combine(WebHostEnvironment.WebRootPath, "data", "agenda.json"); }
        }

        public IEnumerable<AgendaTopic> GetAgendaTopics()
        {
            using(var jsonFileReader = File.OpenText(JsonFileName))
            {
                return JsonSerializer.Deserialize<AgendaTopic[]>(jsonFileReader.ReadToEnd(),
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
            }
        }
        
    }
}