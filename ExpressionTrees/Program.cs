using System;
using System.Linq;
using System.Linq.Expressions;

namespace ExpressionTrees
{
    class Program
    {
        static void Main(string[] args)
        {
            var absMethod = Utils.InfoOf(() => Math.Abs(default(double)));
            var nowProperty = Utils.InfoOf(() => DateTime.Now);
            var guidConstructor = Utils.InfoOf(() => new Guid(default(byte[])));
        }

        private static void CustomQueryProvider()
        {
            var table = new Source<int>("numbers");

            var result = from x in table
                         where x > 0
                         select x * x;

            foreach (var x in result)
            {
                Console.WriteLine(x);
            }
        }

        private static void FuncVsExpression()
        {
            Func<int> f = () => 42;
            Expression<Func<int>> g = () => 42;
        }
    }
}
