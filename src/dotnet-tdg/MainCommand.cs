using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using ArgsToClass;
using TestDocGen;

namespace dotnet_tdg
{
    public class MainCommand:ICommand
    {
        public void Run()
        {
            var assemblyFilePath = Extra.FirstOrDefault();

            if (string.IsNullOrWhiteSpace(assemblyFilePath))
            {
                Console.WriteLine("Assembly file path is not found.");
                return;
            }

            var assembly = Assembly.LoadFrom(assemblyFilePath);

            var testDocumentGenType = assembly.GetTypes().FirstOrDefault(type => typeof(ITestDocumentGen).IsAssignableFrom(type));

            if (testDocumentGenType == null)
            {
                Console.WriteLine($"Class is not found. '{nameof(ITestDocumentGen)}'");
                return;
            }

            var testDocumentGen = (ITestDocumentGen)Activator.CreateInstance(testDocumentGenType);

            var testDocument = testDocumentGen.Create();

            var yaml = testDocument.ToYaml();

            File.WriteAllText("test.yaml",yaml);
            Console.WriteLine($"Output '{"test.yaml"}'");
        }

        public List<string> Extra { get; set; }
    }
}