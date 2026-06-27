Calculator - Interactive CLI

This is a simple interactive calculator implemented in C# using .NET 10.0. It demonstrates a small SOLID-based design: an ICalculator abstraction, concrete Calculator implementation, IOperation implementations for each arithmetic operation, and an OperationFactory to select operations.

Features
- Interactive REPL: run dotnet run --project calculator and enter commands like: add 1 2, mul 3.5 2, div 10 2
- Operations: add, sub, mul, div (also supports symbols + - * /)
- Error handling for invalid input and divide-by-zero

Notes
- Target framework: net10.0

Web UI (static)
- A static web UI was added at CalculatorWeb/wwwroot/index.html which can run in any browser.
- To open locally: open CalculatorWeb/wwwroot/index.html in a browser.
- To serve via a simple static server from the repository root:
  - Using Python: python -m http.server 8000 (then open http://localhost:8000/CalculatorWeb/wwwroot/)
  - Using dotnet: dotnet tool install --global dotnet-serve; dotnet serve -d CalculatorWeb/wwwroot -p 5000

