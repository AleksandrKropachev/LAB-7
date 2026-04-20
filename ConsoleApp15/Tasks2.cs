using System;
using System.IO;
using System.Collections.Generic;

namespace LabWork7
{
    class Tasks2
    {
        // ---------- 6 ----------
        public static void ReverseList()
        {
            List<int> list = new List<int> { 1, 2, 3, 4 };
    
            Console.WriteLine("До:");
            foreach (int x in list)
                Console.Write(x + " ");
            Console.WriteLine();

            int left = 0;
            int right = list.Count - 1;

            while (left < right)
            {
                int temp = list[left];
                list[left] = list[right];
                list[right] = temp;

                слева++;
                справа--;
            }

            Console.WriteLine("После:");
            foreach (int x in list)
                Console.Write(x + " ");
            Console.WriteLine();
}

        // ---------- 7 ----------
        public static void LinkedListInsert()
        {
            LinkedList<int> list = new LinkedList<int>();
            list.AddLast(1);
            list.AddLast(2);
            list.AddLast(3);

            LinkedListNode<int>? node = list.Find(2);

            if (node != null)
            {
                list.AddBefore(node, 99);
                list.AddAfter(node, 99);
            }

            foreach (int item in list)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }

        // ---------- 8 ----------
        public static void Disco()
        {
            HashSet<string> all = new HashSet<string> { "A", "B", "C", "D" };

            HashSet<string> s1 = new HashSet<string> { "A", "B" };
            HashSet<string> s2 = new HashSet<string> { "B", "C" };
            HashSet<string> s3 = new HashSet<string> { "B", "D" };

            Console.WriteLine("Все дискотеки:");
            Print(all);

            Console.WriteLine("Студент 1:");
            Print(s1);

            Console.WriteLine("Студент 2:");
            Print(s2);

            Console.WriteLine("Студент 3:");
            Print(s3);

            // 1. Все студенты
            HashSet<string> intersection = new HashSet<string>(s1);
            Console.WriteLine("\nНачальное пересечение:");
            Print(intersection);

            intersection.IntersectWith(s2);
            Console.WriteLine("После пересечения с s2:");
            Print(intersection);

            intersection.IntersectWith(s3);
            Console.WriteLine("После пересечения с s3:");
            Print(intersection);

            // 2. Хотя бы один
            HashSet<string> union = new HashSet<string>(s1);
            Console.WriteLine("\nНачальное объединение:");
            Print(union);

            union.UnionWith(s2);
            Console.WriteLine("После объединения с s2:");
            Print(union);

            union.UnionWith(s3);
            Console.WriteLine("После объединения с s3:");
            Print(union);

            // 3. Никто
            HashSet<string> none = new HashSet<string>(all);
            Console.WriteLine("\nДо Except:");
            Print(none);

            none.ExceptWith(union);
            Console.WriteLine("После Except:");
            Print(none);
        }

        private static void Print(HashSet<string> set)
        {
            foreach (var x in set)
                Console.Write(x + " ");
            Console.WriteLine();
        }

        // ---------- 9 ----------
        public static void EvenWordSymbols(string path)
        {
            string text = File.ReadAllText(path);
            string[] words = text.Split(' ');

            HashSet<char> set = new HashSet<char>();

            for (int i = 1; i < words.Length; i += 2)
            {
                string w = words[i];

                for (int j = 0; j < w.Length; j++)
                    set.Add(w[j]);
            }

            List<char> list = new List<char>(set);
            list.Sort();

            for (int i = 0; i < list.Count; i++)
                Console.Write(list[i] + " ");

            Console.WriteLine();
        }

        // ---------- 10 ----------
        public static void Entrants(string path)
        {
            using (StreamReader sr = new StreamReader(path))
            {
                string? firstLine = sr.ReadLine();
                if (firstLine == null) return;

                int n = int.Parse(firstLine);

                SortedList<string, string> result = new SortedList<string, string>();

                for (int i = 0; i < n; i++)
                {
                    string? line = sr.ReadLine();
                    if (line == null) continue;

                    string[] parts = line.Split(' ');

                    if (parts.Length < 5) continue;

                    string surname = parts[0];
                    string name = parts[1];

                    int a = int.Parse(parts[2]);
                    int b = int.Parse(parts[3]);
                    int c = int.Parse(parts[4]);

                    if (a >= 30 && b >= 30 && c >= 30 && (a + b + c) >= 140)
                    {
                        result.Add(surname + " " + name, "");
                    }
                }

                foreach (var item in result)
                    Console.WriteLine(item.Key);
            }
        }
    }
}
