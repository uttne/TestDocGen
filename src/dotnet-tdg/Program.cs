using System;
using System.Collections;
using ArgsToClass;

namespace dotnet_tdg
{
    class Program
    {
        static void Main(string[] args)
        {
            var parser = new ArgsParser<MainCommand>();

            IArgsData<MainCommand> data;
            try
            {
                data = parser.Parse(args);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

            data.RunCommand();
        }
    }
}
