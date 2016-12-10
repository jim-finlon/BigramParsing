using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var stringToTest = "";
            if (args.Any())
            {
                var path = args[0];
                if (File.Exists(path))
                {
                    TextReader input = File.OpenText(path);
                    stringToTest = input.ReadToEnd();
                }
                else
                {
                    Console.WriteLine($"Error: Could not find file at {path}, using default text");
                }
            }

            if (stringToTest.Length < 1)
            {
                stringToTest = "Four score and seven years ago our fathers brought forth on this continent, a new nation, conceived in Liberty, and dedicated to the proposition that all men are created equal.";
            }
            
            var service = new HistogramService();
            var results = service.BuildModel(stringToTest);

            Console.WriteLine($"Value \t Count");
            foreach (var model in results)
            {
                Console.WriteLine($"{model.Value} \t {model.Occurences}");
            }
            Console.ReadLine();
        }
    }

    public class HistogramViewModel
    {
        public string Value { get; set; }
        public int Occurences { get; set; }
    }

    public class HistogramService
    {
        public List<HistogramViewModel> BuildModel(string input)
        {
            var results = new List<HistogramViewModel>();

            var source = RemovePunctuation(input);
            var words = source.ToLower().Split(' ');

            for (var i = 0; i < words.Length - 1; i++)
            {
                var phrase = $"{words[i]} {words[i + 1]}";
                var existing = results.FirstOrDefault(r => r.Value == phrase);
                if (existing != null)
                {
                    existing.Occurences += 1;
                }
                else
                {
                    results.Add(new HistogramViewModel
                    {
                        Value = phrase,
                        Occurences = 1
                    });
                }
            }

            return results;
            //return results.OrderByDescending(item => item.Occurences).ThenBy(item => item.Value).ToList();
        }

        private static string RemovePunctuation(string input)
        {
            return input.Replace(".", "").Replace("!", "").Replace("?", "").Replace("\"", "").Replace(",", "");
        }
    }
}
