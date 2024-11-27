using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Model
{
    public class Person
    {
        [JsonIgnore]
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        [DefaultValue("")]
        public string FirstName { get; set; }
        [DefaultValue("")]
        public string LastName { get; set; }

        [JsonIgnore]
        public IEnumerable<Tasks> Tasks { get; set; } = Enumerable.Empty<Tasks>();

    }
}


