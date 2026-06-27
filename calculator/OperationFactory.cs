using System.Collections.Generic;
using System.Linq;

namespace CalculatorApp
{
    public class OperationFactory
    {
        private readonly List<IOperation> _operations;
        public OperationFactory(IEnumerable<IOperation> operations)
        {
            _operations = operations.ToList();
        }

        public IOperation? Get(string input) => _operations.FirstOrDefault(op => op.Matches(input));

        public IEnumerable<IOperation> List() => _operations;
    }
}
