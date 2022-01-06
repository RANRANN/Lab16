using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Unicode;
using System.Threading.Tasks;

namespace Lab16._1
{
    internal class Товар
    {
        [JsonPropertyName("Код товара")]
        public ushort ProductID { get; set; }
        [JsonPropertyName("Название товара")]
        public string Name { get; set; }
        [JsonPropertyName("Цена товара")]
        public double Price { get; set; }
        public static string Enter()
        {
            const int n = 5;
            string jsonstring = String.Empty;
            Товар[] товар = new Товар[n];
            for (int i = 0; i < n; i++)
            {
                switch (i)
                {
                    case 0:
                        {
                            Console.WriteLine("Первый товар");
                            break;
                        }
                    case 1:
                        {
                            Console.WriteLine("Второй товар");
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("Третий товар");
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("Четвёртый товар");
                            break;
                        }
                    case 4:
                        {
                            Console.WriteLine("Пятый товар");
                            break;
                        }
                }
                Console.Write("  Введите код товара - ");
                ushort productID = Convert.ToUInt16(Console.ReadLine());
                Console.Write("  Введите название товара - ");
                string name = Console.ReadLine();
                Console.Write("  Введите цену товара - ");
                double price = Convert.ToDouble(Console.ReadLine());
                товар[i] = new Товар() { ProductID = productID, Name = name, Price = price };
            }
            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                WriteIndented = true
            };
            return jsonstring = JsonSerializer.Serialize(товар, options);
        }
        public void Write()
        {
            string товар = Товар.Enter();

            using (StreamWriter sw = new StreamWriter("../../../Products.json"))
            {
                sw.WriteLine(товар);
            }
        }

    }
}
