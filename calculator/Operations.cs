namespace CalculatorApp
{
    public class AddOperation : IOperation
    {
        private readonly ICalculator _calc;
        public string Key => "add";
        public string Description => "add ( + )";
        public AddOperation(ICalculator calc) => _calc = calc;
        public bool Matches(string input) => input == "add" || input == "+" || input == "plus";
        public double Execute(double a, double b) => _calc.Add(a, b);
    }

    public class SubtractOperation : IOperation
    {
        private readonly ICalculator _calc;
        public string Key => "sub";
        public string Description => "sub ( - )";
        public SubtractOperation(ICalculator calc) => _calc = calc;
        public bool Matches(string input) => input == "sub" || input == "-" || input == "subtract" || input == "minus";
        public double Execute(double a, double b) => _calc.Subtract(a, b);
    }

    public class MultiplyOperation : IOperation
    {
        private readonly ICalculator _calc;
        public string Key => "mul";
        public string Description => "mul ( * )";
        public MultiplyOperation(ICalculator calc) => _calc = calc;
        public bool Matches(string input) => input == "mul" || input == "*" || input == "multiply" || input == "times";
        public double Execute(double a, double b) => _calc.Multiply(a, b);
    }

    public class DivideOperation : IOperation
    {
        private readonly ICalculator _calc;
        public string Key => "div";
        public string Description => "div ( / )";
        public DivideOperation(ICalculator calc) => _calc = calc;
        public bool Matches(string input) => input == "div" || input == "/" || input == "divide";
        public double Execute(double a, double b) => _calc.Divide(a, b);
    }
}
