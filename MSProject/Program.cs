using MsProjectMapper;

namespace MSProject
{
    internal static class Program
    {
        private static void Main()
        {
            var project = new Project();

            project.SaveToFile("TestProject.xml");
        }
    }
}