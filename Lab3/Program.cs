using System;
using System.IO;
using System.Text;

class Program
{
    static void Writer()
    {
        string path = "Data.txt";
        using (FileStream fs = new FileStream(path, FileMode.Create))
        {
            using (StreamWriter sw = new StreamWriter(fs, Encoding.UTF8))
            {
                Console.WriteLine("Writer");
                Console.WriteLine();

                sw.WriteLine("username: myUserName");
                sw.WriteLine("password: myPassword");
                Console.WriteLine();
                Console.WriteLine("_______________________________");
            }
        }
    }

    static void Read()
    {
        string path1 = "example.txt";
        using (FileStream fs = new FileStream(path1, FileMode.Open))
        {
            using (StreamReader sr = new StreamReader(fs, Encoding.UTF8))
            {
                string line;
                Console.WriteLine("Read");
                Console.WriteLine();
                while ((line = sr.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            }
        }
    }

    static void Main(string[] args)
    {
        Writer();
        Read();
    }
}
