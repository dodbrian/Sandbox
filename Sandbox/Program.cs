using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using AutoMapper;

namespace Sandbox
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var futureDays = DateTimeEnumerable.FutureFrom(DateTime.Now);
            var startDate = new DateTime(2020, 10, 1).Date;
            var endDate = new DateTime(2020, 12, 31).Date;

            long average = 0;
            int daysCount = 0;

            int runsCount = 1000;

            for (int i = 0; i < runsCount; i++)
            {
                var watch = Stopwatch.StartNew();

                daysCount = futureDays
                    .WithLastOn(endDate)
                    .Where(date => date >= startDate)
                    .Count();

                watch.Stop();

                average += watch.ElapsedMilliseconds;
            }

            Console.WriteLine(daysCount);
            Console.WriteLine($"{(decimal)average / runsCount} ms");
        }

        private static void EnumerateInChunks()
        {
            var range = Enumerable.Range(1, 43);
            var chunks = range.Chunk(6);

            foreach (var chunk in chunks)
            {
                Console.WriteLine(string.Join(',', chunk));
            }
        }

        private static void SimpleEnumeration()
        {
            var enumeration = YieldReturnTest.GenerateTestSequence();

            foreach (var item in enumeration)
            {
                Console.WriteLine(item);
            }
        }

        private static void Projections()
        {
            using (var ctx = new SandboxContext())
            {
                ctx.Database.EnsureCreated();

                var parents = ctx.Parents.Select(ParentShort.Projection).ToList();

                var items = ctx.Items.Select(ItemProjection.Projection).ToList();

                var testFrom = from x in ctx.Parents
                               select x;
            }
        }

        private static void DictionaryMappingTest()
        {
            var dict = new Dictionary<Guid, SomeEntity>
            {
                {Guid.NewGuid(), new SomeEntity {Name = "TestName"}}
            };

            var mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<KeyValuePair<Guid, SomeEntity>, KeyValuePair<Guid, SomeEntityDto>>();
            }).CreateMapper();

            var mapped = mapper.Map<Dictionary<Guid, SomeEntityDto>>(dict);
        }

        private static void ContextTest()
        {
            using (var ctx = new SandboxContext())
            {
                ctx.Database.EnsureCreated();

                var parent = new Parent
                {
                    ChildName = "Test Name",
                    Items = new List<Item>
                    {
                        new Item {Name = "Item1"},
                        new Item {Name = "Item2"},
                        new Item {Name = "Item3"}
                    }
                };

                ctx.Parents.Add(parent);
                ctx.SaveChanges();

                Console.WriteLine("Press any key to delete dependants...");
                Console.ReadLine();

                var firstItem = parent.Items.First();
                parent.Items.Remove(firstItem);
                ctx.SaveChanges();

                Console.WriteLine("Press any key to delete principal...");
                Console.ReadLine();

                ctx.Parents.Remove(parent);
                ctx.SaveChanges();
            }
        }

        private static void AutomapperTest()
        {
            var mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ParentDto, Parent>()
                    .ForMember(dest => dest.ChildName, opt => opt.MapFrom(y => y.Child.ChildName));
                cfg.CreateMap<ChildDto, Parent>();
            }).CreateMapper();

            mapper.ConfigurationProvider.AssertConfigurationIsValid();

            var parentDto = new ParentDto
            {
                Id = 123,
                Child = new ChildDto
                {
                    Id = 456,
                    ChildName = "Test Name"
                }
            };

            var parent = mapper.Map<Parent>(parentDto);

            Console.WriteLine($"Id: {parent.Id}");
            Console.WriteLine($"ChildName: {parent.ChildName}");
        }
    }
}