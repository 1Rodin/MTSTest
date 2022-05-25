using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FindInFiles.Library;

namespace FindInFiles
{
    class Program
    {

        static void Main(string[] args)
        {

            Console.WriteLine("Выберите тип файла введя номер");
            Console.WriteLine("1. CSS\n2. HTML\n3. TXT");
            var typefile = Console.ReadLine();

            switch (typefile)
            {
                case "1":
                    CSS();
                    break;
                case "2":
                    HTML();
                    break;
                case "3":
                    Def();
                    break;
                default:
                    Console.WriteLine("Нет такого файла");
                    break;

            }



            void CSS()
            {
                Console.WriteLine("Введите путь к файлу полностью");
                FindManager m = new FindManager();
                var filepath = Console.ReadLine().Trim('"');
                var Extension = ".css";
                if (filepath.Contains(Extension))
                {
                    try
                    {
                        var dir = Path.GetDirectoryName(filepath);
                        var res = m.ParsCSS(filepath);
                        Console.WriteLine(res);
                        var save = res.ToString();
                        var repPath = Path.Combine(dir, save+".txt");
                        using( FileStream fs = File.Create(repPath)) {
                            byte[] re = new UTF8Encoding(true).GetBytes(res.Value.ToString());
                            fs.Write(re, 0, re.Length);
                        }                        
                       
                        Console.ReadLine();
                    }
                    catch (Exception Ex)
                    {
                        Console.WriteLine("ОШИБКА:" + Ex.ToString());
                    }
                }
                else
                {
                    Console.WriteLine("Файл не соответствует");
                    Console.ReadLine();
                }

            }

            void HTML()
            {
                Console.WriteLine("Введите путь к файлу полностью");
                FindManager m = new FindManager();
                var filepath = Console.ReadLine().Trim('"');
                var Extension = ".html";
                if (filepath.Contains(Extension))
                {
                    try
                    {
                        var dir = Path.GetDirectoryName(filepath);
                        var res = m.ParseHTML(filepath);
                        Console.WriteLine(res);
                        var save = res.ToString();
                        var repPath = Path.Combine(dir, save + ".txt");
                        using (FileStream fs = File.Create(repPath))
                        {
                            byte[] re = new UTF8Encoding(true).GetBytes(res.Value.ToString());
                            fs.Write(re, 0, re.Length);
                        }
                        Console.ReadLine();
                    }
                    catch (Exception Ex)
                    {
                        Console.WriteLine("ОШИБКА:" + Ex.ToString());
                    }
                }
                else
                {
                    Console.WriteLine("Файл не соответствует");
                    Console.ReadLine();
                }
            }

            void Def()
            {
                Console.WriteLine("Введите путь к файлу полностью");
                FindManager m = new FindManager();
                var filepath = Console.ReadLine().Trim('"');
                var Extension = ".txt";
                if (filepath.Contains(Extension))
                {
                    try
                    {
                        var dir = Path.GetDirectoryName(filepath);
                        var res = m.ParseDef(filepath);
                        Console.WriteLine(res);
                        var save = res.ToString();
                        var repPath = Path.Combine(dir, save + ".txt");
                        using (FileStream fs = File.Create(repPath))
                        {
                            byte[] re = new UTF8Encoding(true).GetBytes(res.Value.ToString());
                            fs.Write(re, 0, re.Length);
                        }
                        Console.ReadLine();
                    }
                    catch (Exception Ex)
                    {
                        Console.WriteLine("ОШИБКА:" + Ex.ToString());
                    }
                }
                else
                {
                    Console.WriteLine("Файл не соответствует");
                    Console.ReadLine();
                }
            }






        }


    }
}
