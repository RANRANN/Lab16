using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using System.Text.Json.Serialization;

namespace Lab16
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string jsonstring = "{\"firstName\":\"Alex\",\"age\":30,\"hobby\":[\"voleyball\",\"chess\"]}";
            Person person = JsonSerializer.Deserialize<Person>(jsonstring);
            Console.WriteLine($"{person.FirstName}\n{person.Age}\n{person.Hobby}");
            Person person1 = new Person()
            {
                FirstName = "Лёша",
                Age = 30,
                Hobby=new string[] { "шашки", "футбол" }
            };
            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                WriteIndented = true
            };
            string jsonstring1 =JsonSerializer.Serialize(person1,options);
            Console.WriteLine(jsonstring1);
            Console.ReadKey();
        }
        class Person
        {
            [JsonPropertyName("firstName")]
            public string FirstName { get; set; }
            [JsonPropertyName("age")]
            [JsonIgnore]
            public int Age { get; set; }
            [JsonPropertyName("hobby")]
            public string[] Hobby { get; set; }
        }
    }
}
