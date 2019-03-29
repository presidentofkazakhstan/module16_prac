using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace module16_prac
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = string.Empty;

            Console.WriteLine("Выберите диск, в котором хотите создать файл: ");

            DriveInfo[] drives = DriveInfo.GetDrives();
            for (int i = 0; i < drives.Length; i++)
            {
                if (drives[i].IsReady)
                {
                    Console.WriteLine($"{i}.{drives[i].Name}");
                }
            }
            Console.Write("Выберите диск, в котором хотите создать файл, написав его порядковый номер: ");
            var number = int.Parse(Console.ReadLine());
            path = drives[number].Name;
            Console.WriteLine($"Выбран диск {path}");
            foreach (var directory in drives[number].RootDirectory.EnumerateDirectories())
            {
                Console.WriteLine($"Папка {directory.Name}");
            }
            Console.Write("Напишите название папки, которую хотите создать: ");
            var directoryName = Console.ReadLine();
            path += directoryName;
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            Console.Write("Напишите название файла, который хотите создать: ");
            var fileName = Console.ReadLine();
            path += @"\" + fileName;
            if (!File.Exists(path))
            {
                using (File.Create(path)) ;
            }
            Console.Write("Введите своё имя: ");
            string name = Console.ReadLine();
            Console.Write("Введите свой возраст: ");
            int age = int.Parse(Console.ReadLine());
            Console.Write("Введите свою фамилию: ");
            string familiya = Console.ReadLine();
            using (var streamwriter = new StreamWriter(path))
            {
                streamwriter.WriteLine("Имя: " + name);
                streamwriter.WriteLine("Фамилия: " + familiya);
                streamwriter.WriteLine("Возраст: " + age);
            }
            Console.Read();
        }
    }
}
