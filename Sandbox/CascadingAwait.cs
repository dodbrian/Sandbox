using System;
using System.Threading.Tasks;

namespace Sandbox
{
    public static class CascadingAwait
    {
        public static Task Load()
        {
            return Run();
        }

        private static Task Run()
        {
            return Count();
        }

        private static Task Count()
        {
            throw new NotSupportedException();
            // return Task.Run(() => "Some final result");
            // await Task.Run(() => throw new NotSupportedException());
        }
    }
}