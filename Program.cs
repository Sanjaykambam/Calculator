using System;
using System.Globalization;

namespace CalculatorApp
{
    class Program
    {
        static void Main()
        {
            ICalculator calculator = new Calculator();
            var ops = new IOperation[]
            {
                new AddOperation(calculator),
                new SubtractOperation(calculator),
                new MultiplyOperation(calculator),
                new DivideOperation(calculator)
            };
            var factory = new OperationFactory(ops);

            Console.WriteLine("Calculator - interactive mode. Type 'help' for commands, 'exit' to quit.");

            while (true)
            {
                Console.Write("> ");
                var input = Console.ReadLine();
                if (input == null) break;
                input = input.Trim();
                if (string.Equals(input, "exit", StringComparison.OrdinalIgnoreCase)) break;
                if (string.Equals(input, "help", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Available operations:");
                    foreach (var o in factory.List())
                    {
                        Console.WriteLine($" - {o.Key}: {o.Description}");
                    }
                    Console.WriteLine("Usage: <operation> <number1> <number2>");
                    Console.WriteLine("Examples: add 1 2    mul 3.5 2");
                    continue;
                }

                var parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length != 3)
                {
                    Console.WriteLine("Invalid input. Type 'help' for usage.");
                    continue;
                }

                var opKey = parts[0].ToLowerInvariant();
                if (!double.TryParse(parts[1], NumberStyles.Float, CultureInfo.InvariantCulture, out var a) ||
                    !double.TryParse(parts[2], NumberStyles.Float, CultureInfo.InvariantCulture, out var b))
                {
                    Console.WriteLine("Invalid numbers. Use formats like 1 2 or 3.5");
                    continue;
                }

                var op = factory.Get(opKey);
                if (op == null)
                {
                    Console.WriteLine($"Unknown operation '{opKey}'. Type 'help' to list operations.");
                    continue;
                }

                try
                {
                    var result = op.Execute(a, b);
                    Console.WriteLine($"= {result}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }
    }
}

