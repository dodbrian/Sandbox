using System;
using MsProjectMapper;

namespace MSProject;

internal static class Program
{
    private static readonly Guid ProjectId = Guid.NewGuid();
    private static readonly DateTime CreatedOn = DateTime.Now;

    private static readonly DateTime Task1Start = DateTime.Today.AddDays(2).UnspecifiedKind();
    private static readonly DateTime Task1Finish = DateTime.Today.AddDays(5).UnspecifiedKind();
    private static readonly DateTime Task2Start = DateTime.Today.AddDays(2).UnspecifiedKind();
    private static readonly DateTime Task2Finish = DateTime.Today.AddDays(5).UnspecifiedKind();
    private static readonly DateTime Task3Start = DateTime.Today.AddDays(6).UnspecifiedKind();
    private static readonly DateTime Task3Finish = DateTime.Today.AddDays(9).UnspecifiedKind();

    private const string ProjectManager = "Test Project Manager Name";
    private const string ProjectName = "Ms Export Test Project";

    private static void Main()
    {
        // LoadAndExportExistingFile();
        CreateProjectFromScratch();
    }

    private static void LoadAndExportExistingFile()
    {
        var project = Project.LoadFromFile("Junge Pflege, Kuppenheim_28.04.2021.xml");

        project.StartDate = DateTime.SpecifyKind(project.StartDate, DateTimeKind.Unspecified);
        project.FinishDate = DateTime.SpecifyKind(project.FinishDate, DateTimeKind.Unspecified);

        project.SaveToFile("Junge Pflege, Kuppenheim_28.04.2021-exported.xml");
    }

    private static void CreateProjectFromScratch()
    {
        var project = new Project
        {
            SaveVersion = 14,
            GUID = ProjectId,
            Name = ProjectName,
            Manager = ProjectManager,
            CreationDate = CreatedOn.UnspecifiedKind(),
            LastSaved = DateTime.UtcNow.UnspecifiedKind(),
            StartDate = DateTime.UtcNow.Date.AddMonths(-1).UnspecifiedKind(),
            FinishDate = DateTime.UtcNow.Date.AddMonths(1).UnspecifiedKind(),
            CurrentDate = DateTime.UtcNow.UnspecifiedKind(),
            StatusDate = DateTime.UtcNow.UnspecifiedKind(),
            ExtendedCreationDate = new(1984, 1, 1),
            ScheduleFromStart = 1,
            DefaultStartTime = new(1, 1, 1, 8, 0, 0),
            DefaultFinishTime = new(1, 1, 1, 17, 0, 0),
            WeekStartDay = ProjectWeekStartDay.Monday,
            MinutesPerDay = 480,
            MinutesPerWeek = 2400,
            DaysPerMonth = 20,
            DefaultTaskType = ProjectDefaultTaskType.FixedDuration,
            DefaultFixedCostAccrual = ProjectDefaultFixedCostAccrual.End,
            DurationFormat = ProjectDurationFormat.Day,
            WorkFormat = ProjectWorkFormat.Day,
            HonorConstraints = 0,
            InsertedProjectsLikeSummary = 0,
            Autolink = 0,
            SpreadActualCost = 0,
            TaskUpdatesResource = 1,
            ProjectExternallyEdited = 0,
            UpdateManuallyScheduledTasksWhenEditingLinks = 1,
            SprintLength = 2,
            AgileMode = 2,
            CurrencySymbol = "€",
            CurrencyDigits = 0,
            CurrencyCode = "EUR",
            CurrencySymbolPosition = ProjectCurrencySymbolPosition.AfterWithSpace,
            Tasks =
            [
                new()
                {
                    ID = 1,
                    UID = 1,
                    GUID = Guid.NewGuid(),
                    OutlineLevel = 1,
                    Rollup = 1,
                    Summary = 1,
                    Type = ProjectTaskType.FixedDuration,
                    Manual = 0,
                    WBS = "1",
                    OutlineNumber = "1",
                    Name = "Node 1",
                    Milestone = 0,
                    CreateDate = DateTime.Today.UnspecifiedKind(),
                    Start = Task1Start,
                    Finish = Task1Finish,
                    EarlyStart = Task1Start,
                    EarlyFinish = Task1Finish,
                    LateStart = Task1Start,
                    LateFinish = Task1Finish,
                    ManualStart = Task1Start.ToString("O"),
                    ManualFinish = Task1Finish.ToString("O"),
                    Active = 1,
                    Critical = 1,
                    FixedCostAccrual = ProjectTaskFixedCostAccrual.End,
                    CalendarUID = -1,
                    LevelAssignments = 1,
                    LevelingCanSplit = 1,
                    LevelingDelayFormat = ProjectTaskLevelingDelayFormat.Item8,
                    SprintUID = -1,
                    BoardColumnUID = -1,
                    DurationFormat = ProjectTaskDurationFormat.Item7,
                    Priority = 500,
                },

                new()
                {
                    ID = 2,
                    UID = 2,
                    GUID = Guid.NewGuid(),
                    OutlineLevel = 2,
                    Rollup = 0,
                    Summary = 0,
                    Type = ProjectTaskType.FixedUnits,
                    Manual = 0,
                    WBS = "1.1",
                    OutlineNumber = "1.1",
                    Name = "Leaf 1",
                    Milestone = 0,
                    CreateDate = DateTime.Today.UnspecifiedKind(),
                    Start = Task2Start,
                    Finish = Task2Finish,
                    EarlyStart = Task2Start,
                    EarlyFinish = Task2Finish,
                    LateStart = Task2Start,
                    LateFinish = Task2Finish,
                    ManualStart = Task2Start.ToString("O"),
                    ManualFinish = Task2Finish.ToString("O"),
                    Active = 1,
                    Critical = 0,
                    FixedCostAccrual = ProjectTaskFixedCostAccrual.End,
                    CalendarUID = -1,
                    LevelAssignments = 1,
                    LevelingCanSplit = 1,
                    LevelingDelayFormat = ProjectTaskLevelingDelayFormat.Item8,
                    SprintUID = -1,
                    BoardColumnUID = -1,
                    DurationFormat = ProjectTaskDurationFormat.Item7,
                    Duration = "PT32H",
                    Priority = 500,
                },

                new()
                {
                    ID = 3,
                    UID = 3,
                    GUID = Guid.NewGuid(),
                    OutlineLevel = 2,
                    Rollup = 0,
                    Summary = 0,
                    Type = ProjectTaskType.FixedUnits,
                    Manual = 0,
                    WBS = "1.1",
                    OutlineNumber = "1.1",
                    Name = "Leaf 2",
                    Milestone = 0,
                    CreateDate = DateTime.Today.UnspecifiedKind(),
                    Start = Task2Start,
                    Finish = Task2Finish,
                    EarlyStart = Task2Start,
                    EarlyFinish = Task2Finish,
                    LateStart = Task2Start,
                    LateFinish = Task2Finish,
                    ManualStart = Task2Start.ToString("O"),
                    ManualFinish = Task2Finish.ToString("O"),
                    Active = 1,
                    Critical = 0,
                    FixedCostAccrual = ProjectTaskFixedCostAccrual.End,
                    CalendarUID = -1,
                    LevelAssignments = 1,
                    LevelingCanSplit = 1,
                    LevelingDelayFormat = ProjectTaskLevelingDelayFormat.Item8,
                    SprintUID = -1,
                    BoardColumnUID = -1,
                    DurationFormat = ProjectTaskDurationFormat.Item7,
                    Duration = "PT32H",
                    Priority = 500,
                    ConstraintType = ProjectTaskConstraintType.Item4,
                    ConstraintDate = Task3Start
                }
            ]
        };

        project.SaveToFile("TestProject.xml");
    }
}
