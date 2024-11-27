
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Model
{
    public class Tasks
    {
        public int Id { get; set; }
        [DefaultValue("")]
        public string TaskName { get; set; }
        public Boolean completed { get; set; }

        [JsonIgnore]
        public Person? person { get; set; } = null;

        public int PersonId {  get; set; }
    }
}
