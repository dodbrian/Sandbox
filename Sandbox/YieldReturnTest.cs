using System.Collections;

namespace Sandbox
{
    public class YieldReturnTest
    {
        public static IEnumerable GenerateTestSequence()
        {
            yield return "string1";
            yield return "string2";
            yield return "string3";
        }
    }
}