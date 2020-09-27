using System;
using System.Linq;
using System.Linq.Expressions;
using LinqKit;

namespace ExpressionTrees
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            Expression<Func<SampleClass, bool>> criteria1 = p => p.NumericProp > 10;
            Expression<Func<SampleClass, bool>> criteria2 = p => criteria1.Invoke(p) || p.StringProp.Contains("test");

            Console.WriteLine(criteria1.Expand().ToString());
            Console.WriteLine(criteria2.Expand().ToString());
        }

        private static void InfoDemo()
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

            foreach (var x in result) Console.WriteLine(x);
        }

        private static void FuncVsExpression()
        {
            Func<int> f = () => 42;
            Expression<Func<int>> g = () => 42;
        }
    }
}