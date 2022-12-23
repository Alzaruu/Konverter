using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace конвертер
{
    internal class Processing
    {
        public static string put;
        public static ConsoleKeyInfo key;
        private static string[] text;

        private static Model model1 = new Model();
        private static Model model2 = new Model();
        private static Model model3 = new Model();
        private static List<Model> list = new List<Model>();

        private static void Rabota()
        {
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Нажмите F1, чтобы сохранить файл в одном из 3 форматов, или Escape, чтобы выйти из программы");
            Console.WriteLine("---------------------------------------------------------------------------------------------");
            Console.SetCursorPosition(0, 2);
            key = Console.ReadKey();
            if (key.Key == ConsoleKey.F1)
            {
                Serial();
            }
            if (key.Key == ConsoleKey.Escape)
            {
                return;
            }

        }
        private static void Serial()
        {
            list.Add(model1);
            list.Add(model2);
            list.Add(model3);

            Console.Clear();
            Console.WriteLine("Напищите новый путь с указанием имени и формата нового файла: ");
            Console.WriteLine("---------------------------------------------------");
            string put1 = Console.ReadLine();

            if (put1.EndsWith("json"))
            {
                string json = JsonConvert.SerializeObject(list);
                File.WriteAllText(put1, json);
            }

            if (put1.EndsWith("xml"))
            {
                XmlSerializer xml = new XmlSerializer(typeof(Model));
                using (FileStream fs = new FileStream(put1, FileMode.OpenOrCreate))
                {
                    xml.Serialize(fs, list);
                }
            }

            if (put1.EndsWith("txt"))
            {
                foreach (Model item in list)
                {
                    string a = Convert.ToString(item);
                    File.AppendAllText(put1, a);
                }

            }
            return;

        }

        public static void Deserialtxt()
        {
            Console.Clear();
            text = File.ReadAllLines(put);
            foreach (string line in text)
            {
                Console.WriteLine(line);
            }
            model1.Name = text[0];
            model1.Weight = Convert.ToInt32(text[1]);
            model1.High = Convert.ToInt32(text[2]);

            model2.Name = text[3];
            model2.Weight = Convert.ToInt32(text[4]);
            model2.High = Convert.ToInt32(text[5]);

            model3.Name = text[6];
            model3.Weight = Convert.ToInt32(text[7]);
            model3.High = Convert.ToInt32(text[8]);

            Rabota();
        }

        public static void Deserialjson()
        {
            Console.Clear();
            string txt = File.ReadAllText(put);
            list = JsonConvert.DeserializeObject<List<Model>>(txt);
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i].Name);
                Console.WriteLine(list[i].Weight);
                Console.WriteLine(list[i].High);
            }

            Rabota();
        }

        public static void Deserialxml()
        {
            Console.Clear();
            Model model;
            XmlSerializer xml = new XmlSerializer(typeof(Model));
            using (FileStream fs = new FileStream(put, FileMode.Open))
            {
                model = (Model)xml.Deserialize(fs);
            }
            Console.WriteLine(model);
            Rabota();
        }
    }
}
