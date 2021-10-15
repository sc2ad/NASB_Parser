using NASB_Parser;
using System;
using System.Diagnostics;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace JsonDumper
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Enter path to exported TextAsset data...");
            var p = @"D:\NASB_Managed\char_apple.txt";
            while (!File.Exists(p))
            {
                Console.WriteLine("Enter a valid path!");
                p = Console.ReadLine();
            }
            var watch = new Stopwatch();
            watch.Start();
            BulkSerializer ser;
            using (var fsread = File.OpenRead(p))
                ser = new BulkSerializer(fsread);
            watch.Stop();
            Console.WriteLine($"Parsing took: {watch.Elapsed}");
            watch.Reset();
            watch.Start();
            var data = new SerialMoveset(ser);
            watch.Stop();
            Console.WriteLine($"Creation of type structure took: {watch.Elapsed}");
            watch.Reset();
            JsonSerializerOptions options = new()
            {
                Converters = { new JsonStringEnumConverter() }
            };
            Console.WriteLine("Json dump...");
            watch.Start();
            using var fs = File.OpenWrite("output.json");
            using var writer = new Utf8JsonWriter(fs);
            JsonSerializer.Serialize(writer, data, options);
            watch.Stop();
            Console.WriteLine($"Creation of JSON took: {watch.Elapsed}");
            Console.WriteLine("Success!");
        }
    }
}