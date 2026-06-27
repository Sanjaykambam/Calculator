Calculator - Interactive CLI

This is a simple interactive calculator implemented in C# using .NET 10.0. It demonstrates a small SOLID-based design: an ICalculator abstraction, concrete Calculator implementation, IOperation implementations for each arithmetic operation, and an OperationFactory to select operations.

Features
- Interactive REPL: run dotnet run --project calculator and enter commands like: add 1 2, mul 3.5 2, div 10 2
- Operations: add, sub, mul, div (also supports symbols + - * /)
- Error handling for invalid input and divide-by-zero

Notes
- Target framework: net10.0
