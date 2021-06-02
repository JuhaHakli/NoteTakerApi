using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;

namespace NoteTakerApi.Models
{
    public class Note
    {
        public int Id { get; set; }
        public string Text { get; set; }
    }
}
