using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            if (args.Any())
            {
                var path = args[0];

                if (File.Exists(path))
                {
                    var service = new HistogramService();
                    try
                    {
                        var results = service.ProcessFile(path);

                        Console.WriteLine($"Value \t Count");
                        foreach (var model in results)
                        {
                            Console.WriteLine($"{model.Key} \t {model.Value}");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                    }

                }
                else
                {
                    Console.WriteLine($"Error: Could not find file at {path}");
                }

            }

            stopWatch.Stop();
            var ts = stopWatch.Elapsed;

            string elapsedTime = $"{ts.Hours:00}:{ts.Minutes:00}:{ts.Seconds:00}.{ts.Milliseconds / 10:00}";
            Console.WriteLine("RunTime " + elapsedTime);

            Console.ReadLine();
        }
    }

    public class HistogramService
    {
        public Dictionary<string, int> ProcessFile(string path)
        {
            var dic = new Dictionary<string, int>();

            if (!File.Exists(path)) return dic;
            using (var fs = File.Open(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            using (var bs = new BufferedStream(fs))
            using (var sr = new StreamReader(bs))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    var source = RemovePunctuation(line);
                    var words = source.ToLower().Split(' ');

                    for (var i = 0; i < words.Length - 1; i++)
                    {
                        var phrase = $"{words[i]} {words[i + 1]}";

                        var ext = dic.FirstOrDefault(r => r.Key == phrase);

                        if (ext.Value > 0)
                        {
                            dic[phrase] = ext.Value + 1;
                        }
                        else
                        {
                            dic.Add(phrase, 1);
                        }

                    }
                }
            }

            return dic;
        }
        
        private static string RemovePunctuation(string input)
        {
            return input.Replace(".", "").Replace("!", "").Replace("?", "").Replace("\"", "").Replace(",", "").Replace("#", "").Replace(":", "").Replace(";", "");
        }
    }
}
