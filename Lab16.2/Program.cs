using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Lab16._1;
using System.Text.Json;

namespace Lab16._2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string jsonstring = String.Empty;
            using (StringReader sr = new StringReader("../../../Products.json"))
            {
                jsonstring = sr.ReadToEnd();
            }
            Товар[] товар = JsonSerializer.Deserialize<Товар[]>(jsonstring);

            Товар maxPrice = товар[0];
            foreach (Товар т in jsonstring)
            {
                if (т.Price > maxPrice.Price)
                {
                    maxPrice = т;
                }
            }
            Console.WriteLine($"{maxPrice.ProductID},{maxPrice.Name},{maxPrice.Price}");
        }
    }
}
