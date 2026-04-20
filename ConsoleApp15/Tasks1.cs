using System;
using System.IO;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace LabWork7
{
    class Tasks1
    {
        // ---------- 1 ----------
        public static void GenerateFile1(string path, int n)
        {
            Random rnd = new Random();
            using (StreamWriter sw = new StreamWriter(path))
            {
                for (int i = 0; i < n; i++)
                    sw.WriteLine(rnd.Next(-100, 100));
            }
        }

        public static int SumMinMax(string path)
        {
            int min = int.MaxValue;
            int max = int.MinValue;

            using (StreamReader sr = new StreamReader(path))
            {
                string? line;
                while ((line = sr.ReadLine()) != null)
                {
                    int num = int.Parse(line);
                    if (num < min) min = num;
                    if (num > max) max = num;
                }
            }

            return min + max;
        }

        // ---------- 2 ----------
        public static void GenerateFile2(string path, int rows, int cols)
        {
            Random rnd = new Random();
            using (StreamWriter sw = new StreamWriter(path))
            {
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                        sw.Write(rnd.Next(0, 100) + " ");

                    sw.WriteLine();
                }
            }
        }

        public static int SumEven(string path)
        {
            int sum = 0;

            using (StreamReader sr = new StreamReader(path))
            {
                string? line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] parts = line.Split(' ');

                    for (int i = 0; i < parts.Length; i++)
                    {
                        if (parts[i].Length > 0)
                        {
                            int num = int.Parse(parts[i]);
                            if (num % 2 == 0)
                                sum += num;
                        }
                    }
                }
            }

            return sum;
        }

        // ---------- 3 ----------
        public static void FirstChars(string input, string output)
        {
            using (StreamReader sr = new StreamReader(input))
            using (StreamWriter sw = new StreamWriter(output))
            {
                string? line;
                while ((line = sr.ReadLine()) != null)
                {
                    if (line.Length > 0)
                        sw.WriteLine(line[0]);
                }
            }
        }

        // ---------- 4 ----------
        public static void GenerateBinaryFile(string path, int n)
        {
            Random rnd = new Random();
            using (BinaryWriter bw = new BinaryWriter(File.Open(path, FileMode.Create)))
            {
                for (int i = 0; i < n; i++)
                    bw.Write(rnd.Next(0, 100));
            }
        }

        public static void ReadBinary(string path)
        {
            using (BinaryReader br = new BinaryReader(File.Open(path, FileMode.Open)))
            {
                while (br.BaseStream.Position < br.BaseStream.Length)
                {
                    int num = br.ReadInt32();
                    Console.Write(num + " ");
                }
            }
            Console.WriteLine();
        }

        public static void FilterBinary(string input, string output, int k)
        {
            using (BinaryReader br = new BinaryReader(File.Open(input, FileMode.Open)))
            using (BinaryWriter bw = new BinaryWriter(File.Open(output, FileMode.Create)))
            {
                while (br.BaseStream.Position < br.BaseStream.Length)
                {
                    int num = br.ReadInt32();
                    if (num % k != 0)
                        bw.Write(num);
                }
            }
        }

        // ---------- 5 ----------
        public static void GenerateToys(string path)
        {
            List<Toy> toys = new List<Toy>();

            toys.Add(new Toy("Мяч", 200, 1, 5));
            toys.Add(new Toy("Кукла", 500, 3, 7));
            toys.Add(new Toy("Конструктор", 800, 4, 10));

            XmlSerializer xs = new XmlSerializer(typeof(List<Toy>));

            using (FileStream fs = new FileStream(path, FileMode.Create))
            {
                xs.Serialize(fs, toys);
            }
        }

        public static bool CheckToy()
        {
            XmlSerializer xs = new XmlSerializer(typeof(List<Toy>));

            using (FileStream fs = new FileStream("toys.xml", FileMode.Open))
            {
                List<Toy>? toys = xs.Deserialize(fs) as List<Toy>;

                if (toys == null) return false;

                for (int i = 0; i < toys.Count; i++)
                {
                    if (toys[i].Name != "Мяч" &&
                        toys[i].MinAge <= 3 &&
                        toys[i].MaxAge >= 3)
                        return true;
                }
            }

            return false;
        }
    }

    public class Toy
    {
        public string Name = "";
        public int Price;
        public int MinAge;
        public int MaxAge;

        public Toy() { }

        public Toy(string name, int price, int min, int max)
        {
            Name = name;
            Price = price;
            MinAge = min;
            MaxAge = max;
        }
    }
}