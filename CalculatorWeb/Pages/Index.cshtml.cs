using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;

namespace CalculatorWeb.Pages
{
    public class IndexModel : PageModel
    {
        private readonly CalculatorApp.ICalculator _calculator;

        public IndexModel(CalculatorApp.ICalculator calculator)
        {
            _calculator = calculator;
        }

        [BindProperty]
        public string Operation { get; set; } = "add";

        [BindProperty]
        public string A { get; set; } = "";

        [BindProperty]
        public string B { get; set; } = "";

        public double? Result { get; set; }
        public string? ErrorMessage { get; set; }

        public void OnGet()
        {
        }

        public void OnPost()
        {
            ErrorMessage = null;
            Result = null;

            if (!double.TryParse(A, out var a))
            {
                ErrorMessage = "Invalid number for A.";
                return;
            }

            if (!double.TryParse(B, out var b))
            {
                ErrorMessage = "Invalid number for B.";
                return;
            }

            try
            {
                Result = Operation.ToLowerInvariant() switch
                {
                    "add" => _calculator.Add(a, b),
                    "sub" => _calculator.Subtract(a, b),
                    "mul" => _calculator.Multiply(a, b),
                    "div" => _calculator.Divide(a, b),
                    _ => throw new InvalidOperationException("Unknown operation")
                };
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }
    }
}
