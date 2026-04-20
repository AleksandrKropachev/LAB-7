using System;

namespace LabWork7
{
    class Program
    {
        static void Main(string[] args)
        {
            Tasks1.GenerateFile1("file1.txt", 10);
            Console.WriteLine(Tasks1.SumMinMax("file1.txt"));

            Tasks1.GenerateFile2("file2.txt", 5, 5);
            Console.WriteLine(Tasks1.SumEven("file2.txt"));

            Tasks1.FirstChars("input.txt", "output.txt");

            Tasks1.GenerateBinaryFile("bin.dat", 10);
            Tasks1.ReadBinary("bin.dat");
            Tasks1.FilterBinary("bin.dat", "res.dat", 3);
            Tasks1.ReadBinary("res.dat");

            Tasks1.GenerateToys("toys.xml");
            Console.WriteLine(Tasks1.CheckToy());

            Tasks2.ReverseList();
            Tasks2.LinkedListInsert();
            Tasks2.Disco();
            Tasks2.EvenWordSymbols("text.txt");
            Tasks2.Entrants("entrants.txt");
        }
    }
}