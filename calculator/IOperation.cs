namespace CalculatorApp
{
    public interface IOperation
    {
        string Key { get; }
        string Description { get; }
        bool Matches(string input);
        double Execute(double a, double b);
    }
}
