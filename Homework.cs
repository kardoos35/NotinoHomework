using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;
using Newtonsoft.Json;

namespace Notino.Homework
{
    public class Document // shoud be in different file
    {
        public string Title { get; set; }
        public string Text { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var sourceFileName = Path.Combine(Environment.CurrentDirectory, "..\\..\\..\\Source Files\\Document1.xml"); // better in method because of code redundancy
            var targetFileName = Path.Combine(Environment.CurrentDirectory, "..\\..\\..\\Target Files\\Document1.json");

            try
            {
                FileStream sourceStream = File.Open(sourceFileName, FileMode.Open); // first check File.Exist and wrap by using
                var reader = new StreamReader(sourceStream); // wrap by using
                string input = reader.ReadToEnd(); // input should be declare outside of try
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);  // just throw ex
            }

            var xdoc = XDocument.Parse(input); // I would wrapped all xdoc to try catch 
            var doc = new Document
            {
                Title = xdoc.Root.Element("title").Value, // Root can be null. Use ? operator
                Text = xdoc.Root.Element("text").Value
            };

            var serializedDoc = JsonConvert.SerializeObject(doc);

            var targetStream = File.Open(targetFileName, FileMode.Create, FileAccess.Write); // check File.Exist first
            var sw = new StreamWriter(targetStream);
            sw.Write(serializedDoc); // wrap by using or use .dispose 
            // I would delete empty rows, formatted code is easier to read.

        }
    }
}
