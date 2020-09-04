using System;
using System.IO;
using System.Threading.Tasks;
using System.Net.Http;
using System.Linq;
using System.Text;
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
            var result = GetAgendaTopicsAsync().Result;
            return result;
        }

        public async Task<AgendaTopic[]> GetAgendaTopicsAsync()
        {
            try
            {
                var data = await File.ReadAllTextAsync(JsonFileName, Encoding.UTF8).ConfigureAwait(false);
                var result = JsonSerializer.Deserialize<AgendaTopic[]>(data);
                return result.OrderBy(t => t.OrderId).ToArray();        
            }
            catch (Exception ex)
            {
                return null;
            }                       
        }
        
        public async Task SaveAgendaTopicsAsync(AgendaTopic[] topics)
        {
            var json = JsonSerializer.Serialize(topics, new JsonSerializerOptions {
                WriteIndented = true
            });
            await File.WriteAllTextAsync(JsonFileName, json, Encoding.UTF8).ConfigureAwait(false);            
        }
        
    }
}