using System;
using Aspose.Tasks;
using Aspose.Tasks.Util;

namespace MSProject
{
    class Program
    {
        static void Main(string[] args)
        {
            var project = new Project("Junge Pflege, Kuppenheim_28.04.2021-edited.mpp");

            Console.WriteLine($"Project Version: {project.Get(Prj.SaveVersion)}");
            Console.WriteLine($"Last Saved: {project.Get(Prj.LastSaved).ToShortDateString()}");

            // Display default properties
            Console.WriteLine($"New Task Default Start: {project.Get(Prj.DefaultStartTime).ToShortDateString()}");
            Console.WriteLine($"New Task Default Type: {project.Get(Prj.DefaultTaskType)}");
            Console.WriteLine($"Resource Default Standard Rate: {project.Get(Prj.DefaultStandardRate)}");
            Console.WriteLine($"Resource Default Overtime Rate: {project.Get(Prj.DefaultOvertimeRate)}");
            Console.WriteLine($"Default Task EV Method: {project.Get(Prj.DefaultTaskEVMethod)}");
            Console.WriteLine($"Default Cost Accrual: {project.Get(Prj.DefaultFixedCostAccrual)}");

            // Display currency properties
            Console.WriteLine($"Currency Code: {project.Get(Prj.CurrencyCode)}");
            Console.WriteLine($"Currency Digits: {project.Get(Prj.CurrencyDigits)}");
            Console.WriteLine($"Currency Symbol: {project.Get(Prj.CurrencySymbol)}");
            Console.WriteLine($"Currency Symbol Position{project.Get(Prj.CurrencySymbolPosition)}");

            // custom properties are available through the typed collection
            foreach (var property in project.CustomProps)
            {
                Console.WriteLine($"{property.Name}({property.Type}): {property.Value}");
            }

            // built-in properties are available directly
            Console.WriteLine($"Author: {project.BuiltInProps.Author}");
            Console.WriteLine($"Title: {project.BuiltInProps.Title}");

            // or as an item of built-in property collection
            foreach (var property in project.BuiltInProps)
            {
                Console.WriteLine($"{property.Name}: {property.Value}");
            }

            foreach (var ocd in project.OutlineCodes)
            {
                Console.WriteLine($"Alias = {ocd.Alias}");
                Console.WriteLine(ocd.AllLevelsRequired
                    ? "It contains property: must have all levels"
                    : "It does not contain property: must have all levels");

                Console.WriteLine(ocd.Enterprise
                    ? "It is an enterprise custom outline code."
                    : "It is not an enterprise custom outline code.");

                Console.WriteLine(
                    $"Reference to another custom field for which this outline code definition is an alias is = {ocd.EnterpriseOutlineCodeAlias}");

                Console.WriteLine($"Field Id = {ocd.FieldId}");
                Console.WriteLine($"Field Name = {ocd.FieldName}");
                Console.WriteLine($"Phonetic Alias = {ocd.PhoneticAlias}");
                Console.WriteLine($"Guid = {ocd.Guid}");

                // Display outline code masks
                foreach (var outlineMask in ocd.Masks)
                {
                    Console.WriteLine($"Level of a mask = {outlineMask.Level}");
                    Console.WriteLine($"Mask = {outlineMask}");
                }

                // Display out line code values
                foreach (var outlineMask1 in ocd.Values)
                {
                    Console.WriteLine($"Description of outline value = {outlineMask1.Description}");
                    Console.WriteLine($"Value Id = {outlineMask1.ValueId}");
                    Console.WriteLine($"Value = {outlineMask1.Value}");
                    Console.WriteLine($"Type = {outlineMask1.Type}");
                }
            }

            var collector = new ChildTasksCollector();

            // Collect all the tasks from RootTask using TaskUtils
            TaskUtils.Apply(project.RootTask, collector, 0);

            // Parse through all the collected tasks
            foreach (var task in collector.Tasks)
            {
                Console.WriteLine($"Task Id: {task.Get(Tsk.Id)}");
                Console.WriteLine($"Task Uid: {task.Get(Tsk.Uid)}");
                Console.WriteLine($"Task Name: {task.Get(Tsk.Name)}");
                Console.WriteLine($"Task Start: {task.Get(Tsk.Start)}");
                Console.WriteLine($"Task Finish: {task.Get(Tsk.Finish)}");
                Console.WriteLine($"Task Type: {task.Get(Tsk.Type)}");
                Console.WriteLine($"Task IsNull: {task.Get(Tsk.IsNull)}");
                Console.WriteLine($"Task IsSummary: {task.Get(Tsk.IsSummary)}");
            }

            // Read extended attributes for tasks
            foreach (var task in project.RootTask.Children)
            {
                foreach (var ea in task.ExtendedAttributes)
                {
                    Console.WriteLine(ea.FieldId);
                    Console.WriteLine(ea.ValueGuid);

                    switch (ea.AttributeDefinition.CfType)
                    {
                        case CustomFieldType.Date:
                        case CustomFieldType.Start:
                        case CustomFieldType.Finish:
                            Console.WriteLine(ea.DateValue);
                            break;

                        case CustomFieldType.Text:
                            Console.WriteLine(ea.TextValue);
                            break;

                        case CustomFieldType.Duration:
                            Console.WriteLine(ea.DurationValue.ToString());
                            break;

                        case CustomFieldType.Cost:
                        case CustomFieldType.Number:
                            Console.WriteLine(ea.NumericValue);
                            break;

                        case CustomFieldType.Flag:
                            Console.WriteLine(ea.FlagValue);
                            break;
                        
                        case CustomFieldType.Null:
                            Console.WriteLine(ea.NumericValue);
                            break;
                        
                        case CustomFieldType.OutlineCode:
                            Console.WriteLine(ea.TextValue);
                            break;
                        
                        case CustomFieldType.RBS:
                            Console.WriteLine(ea.TextValue);
                            break;
                        
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }
            }

            foreach (var resource in project.Resources)
            {
                Console.WriteLine($"Resource Name: {resource.Get(Rsc.Name)}");
                Console.WriteLine($"Resource Code: {resource.Get(Rsc.Code)}");
            }

            // project.Save("Junge Pflege, Kuppenheim_28.04.2021-edited.xml", SaveFileFormat.XML);
        }
    }
}