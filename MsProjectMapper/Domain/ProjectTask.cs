// ------------------------------------------------------------------------------
//  <auto-generated>
//    Generated by Xsd2Code++. Version 5.2.97.0. www.xsd2code.com
//  </auto-generated>
// ------------------------------------------------------------------------------
#pragma warning disable
namespace MsProjectMapper
{
    using System;
    using System.Diagnostics;
    using System.Xml.Serialization;
    using System.Runtime.Serialization;
    using System.Collections;
    using System.Xml.Schema;
    using System.ComponentModel;
    using System.Xml;
    using System.IO;
    using System.Text;
    using System.ComponentModel.DataAnnotations;
    using System.Collections.Generic;

    /// <summary>
    /// There must be at least one task in each Tasks collection.
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.4084.0")]
    [Serializable]
    [DebuggerStepThrough]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.microsoft.com/project")]
    public partial class ProjectTask
    {
        private List<ProjectTaskPredecessorLink> _predecessorLink;
        private List<ProjectTaskExtendedAttribute> _extendedAttribute;
        private List<ProjectTaskBaseline> _baseline;
        private List<ProjectTaskOutlineCode> _outlineCode;
        private List<TimephasedDataType> _timephasedData;
        private static XmlSerializer _serializer;
        /// <summary>
        /// The unique ID of the task.
        /// </summary>
        public int UID { get; set; }
        /// <summary>
        /// The unique GUID of the task.
        /// </summary>
        [RequiredAttribute()]
        [RegularExpressionAttribute("[a-fA-F0-9]{8}-[a-fA-F0-9]{4}-[a-fA-F0-9]{4}-[a-fA-F0-9]{4}-[a-fA-F0-9]{12}")]
        public Guid GUID { get; set; }
        public bool ShouldSerializeGUID() => GUID != Guid.Empty;
        /// <summary>
        /// The position identifier of the task within the list of tasks.
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// The name of the task.
        /// </summary>
        [MaxLengthAttribute(512)]
        [StringLengthAttribute(512)]
        public string Name { get; set; }
        /// <summary>
        /// Whether the task is active.
        /// </summary>
        [Range(0, 1)]
        public int Active { get; set; }
        /// <summary>
        /// Whether the task is in manually scheduled mode.
        /// </summary>
        [Range(0, 1)]
        public int Manual { get; set; }
        /// <summary>
        /// The type of task. Values are: 0=Fixed Units, 1=Fixed Duration, 2=Fixed Work.
        /// </summary>
        public ProjectTaskType Type { get; set; }
        /// <summary>
        /// Whether the task is null.
        /// </summary>
        [Range(0, 1)]
        public int IsNull { get; set; }
        /// <summary>
        /// The date that the task was created.
        /// </summary>
        public System.DateTime CreateDate { get; set; }
        /// <summary>
        /// The contact person for the task.
        /// </summary>
        [MaxLengthAttribute(512)]
        [StringLengthAttribute(512)]
        public string Contact { get; set; }
        /// <summary>
        /// The work breakdown structure code of the task.
        /// </summary>
        public string WBS { get; set; }
        /// <summary>
        /// The rightmost WBS level of the task.
        /// </summary>
        public string WBSLevel { get; set; }
        /// <summary>
        /// The outline number of the task.
        /// </summary>
        [MaxLengthAttribute(512)]
        [StringLengthAttribute(512)]
        public string OutlineNumber { get; set; }
        /// <summary>
        /// The outline level of the task.
        /// </summary>
        public int OutlineLevel { get; set; }
        /// <summary>
        /// The priority of the task from 0 to 1000.
        /// </summary>
        [Range(0, 1000)]
        public int Priority { get; set; }
        /// <summary>
        /// The scheduled start date of the task.
        /// </summary>
        public System.DateTime Start { get; set; }
        /// <summary>
        /// The scheduled finish date of the task.
        /// </summary>
        public System.DateTime Finish { get; set; }
        /// <summary>
        /// The planned duration of the task.
        /// </summary>
        [XmlElement(DataType = "duration")]
        public string Duration { get; set; }
        /// <summary>
        /// Text displayed in the start field when the task is in manually scheduled mode.
        /// </summary>
        public string ManualStart { get; set; }
        /// <summary>
        /// Text displayed in the finish field when the task is in manually scheduled mode.
        /// </summary>
        public string ManualFinish { get; set; }
        /// <summary>
        /// Text displayed in the duration field when the task is in manually scheduled mode.
        /// </summary>
        public string ManualDuration { get; set; }
        /// <summary>
        /// The format for expressing the Duration of the Task. Values are: 3=m, 4=em, 5=h, 6=eh, 7=d, 8=ed, 9=w, 10=ew, 11=mo, 12=emo, 19=%, 20=e%, 21=null, 35=m?, 36=em?, 37=h?, 38=eh?, 39=d?, 40=ed?, 41=w?, 42=ew?, 43=mo?, 44=emo?, 51=%?, 52=e%? and 53=null.
        /// </summary>
        public ProjectTaskDurationFormat DurationFormat { get; set; }
        /// <summary>
        ///  The format for expressing the FreeformDuration of the Task.
        /// </summary>
        public int FreeformDurationFormat { get; set; }
        /// <summary>
        /// The amount of scheduled work for the task.
        /// </summary>
        [XmlElement(DataType = "duration")]
        public string Work { get; set; }
        /// <summary>
        /// The date that the task was stopped.
        /// </summary>
        [DefaultValue(typeof(DateTime), "")]
        public System.DateTime Stop { get; set; }
        /// <summary>
        /// The date that the task resumed.
        /// </summary>
        [DefaultValue(typeof(DateTime), "")]
        public System.DateTime Resume { get; set; }
        /// <summary>
        /// Whether the task can be resumed.
        /// </summary>
        [Range(0, 1)]
        public int ResumeValid { get; set; }
        /// <summary>
        /// Whether the task is effort-driven.
        /// </summary>
        [Range(0, 1)]
        public int EffortDriven { get; set; }
        /// <summary>
        /// Whether the task is a recurring task.
        /// </summary>
        [Range(0, 1)]
        public int Recurring { get; set; }
        /// <summary>
        /// Whether the task is overallocated. This element is informational only.
        /// </summary>
        [Range(0, 1)]
        public int OverAllocated { get; set; }
        /// <summary>
        /// Whether the task is estimated.
        /// </summary>
        [Range(0, 1)]
        public int Estimated { get; set; }
        /// <summary>
        /// Whether the task is a milestone.
        /// </summary>
        [Range(0, 1)]
        public int Milestone { get; set; }
        /// <summary>
        /// Whether the task is a summary task.
        /// </summary>
        [Range(0, 1)]
        public int Summary { get; set; }
        /// <summary>
        /// Whether the task should be displayed as a summary task.
        /// </summary>
        [Range(0, 1)]
        public int DisplayAsSummary { get; set; }
        /// <summary>
        /// Whether the task is in the critical chain.
        /// </summary>
        [Range(0, 1)]
        public int Critical { get; set; }
        /// <summary>
        /// Whether the task is an inserted project.
        /// </summary>
        [Range(0, 1)]
        public int IsSubproject { get; set; }
        /// <summary>
        /// Whether the inserted project is read-only.
        /// </summary>
        [Range(0, 1)]
        public int IsSubprojectReadOnly { get; set; }
        /// <summary>
        /// The source location of the inserted project.
        /// </summary>
        [MaxLengthAttribute(512)]
        [StringLengthAttribute(512)]
        public string SubprojectName { get; set; }
        /// <summary>
        /// Whether the task is external.
        /// </summary>
        [Range(0, 1)]
        public int ExternalTask { get; set; }
        /// <summary>
        /// The source location and task identifier of the external task.
        /// </summary>
        [MaxLengthAttribute(512)]
        [StringLengthAttribute(512)]
        public string ExternalTaskProject { get; set; }
        /// <summary>
        /// The early start date of the task.
        /// </summary>
        public System.DateTime EarlyStart { get; set; }
        /// <summary>
        /// The early finish date of the task.
        /// </summary>
        public System.DateTime EarlyFinish { get; set; }
        /// <summary>
        /// The late start date of the task.
        /// </summary>
        public System.DateTime LateStart { get; set; }
        /// <summary>
        /// The late finish date of the task.
        /// </summary>
        public System.DateTime LateFinish { get; set; }
        /// <summary>
        /// The variance of the task start date from the baseline start date as minutes x 1000.
        /// </summary>
        public int StartVariance { get; set; }
        /// <summary>
        /// The variance of the task finish date from the baseline finish date as minutes x 1000.
        /// </summary>
        public int FinishVariance { get; set; }
        /// <summary>
        /// The variance of task work from the baseline task work as minutes x 1000.
        /// </summary>
        public float WorkVariance { get; set; }
        /// <summary>
        /// The amount of free slack.
        /// </summary>
        public int FreeSlack { get; set; }
        /// <summary>
        /// The amount of total slack.
        /// </summary>
        public int TotalSlack { get; set; }
        /// <summary>
        /// The amount of free slack at the start of the task.
        /// </summary>
        public int StartSlack { get; set; }
        /// <summary>
        /// The amount of free slack at the end of the task.
        /// </summary>
        public int FinishSlack { get; set; }
        /// <summary>
        /// The fixed cost of the task.
        /// </summary>
        public float FixedCost { get; set; }
        /// <summary>
        /// How the fixed cost is accrued against the task. Values are: 1=Start, 2=Prorated and 3=End.
        /// </summary>
        public ProjectTaskFixedCostAccrual FixedCostAccrual { get; set; }
        /// <summary>
        /// The percentage of the task duration completed.
        /// </summary>
        public int PercentComplete { get; set; }
        /// <summary>
        /// The percentage of the task work completed.
        /// </summary>
        public int PercentWorkComplete { get; set; }
        /// <summary>
        /// The projected or scheduled cost of the task.
        /// </summary>
        public decimal Cost { get; set; }
        /// <summary>
        /// The sum of the actual and remaining overtime cost of the task.
        /// </summary>
        public decimal OvertimeCost { get; set; }
        /// <summary>
        /// The amount of overtime work scheduled for the task.
        /// </summary>
        [XmlElement(DataType = "duration")]
        public string OvertimeWork { get; set; }
        /// <summary>
        /// The actual start date of the task.
        /// </summary>
        [DefaultValue(typeof(DateTime), "")]
        public System.DateTime ActualStart { get; set; }
        /// <summary>
        /// The actual finish date of the task.
        /// </summary>
        [DefaultValue(typeof(DateTime), "")]
        public System.DateTime ActualFinish { get; set; }
        /// <summary>
        /// The actual duration of the task.
        /// </summary>
        [XmlElement(DataType = "duration")]
        public string ActualDuration { get; set; }
        /// <summary>
        /// The actual cost of the task.
        /// </summary>
        public decimal ActualCost { get; set; }
        /// <summary>
        /// The actual overtime cost of the task.
        /// </summary>
        public decimal ActualOvertimeCost { get; set; }
        /// <summary>
        /// The actual work for the task.
        /// </summary>
        [XmlElement(DataType = "duration")]
        public string ActualWork { get; set; }
        /// <summary>
        /// The actual overtime work for the task.
        /// </summary>
        [XmlElement(DataType = "duration")]
        public string ActualOvertimeWork { get; set; }
        /// <summary>
        /// The amount of non-overtime work scheduled for the task.
        /// </summary>
        [XmlElement(DataType = "duration")]
        public string RegularWork { get; set; }
        /// <summary>
        /// The amount of time required to complete the unfinished portion of the task.
        /// </summary>
        [XmlElement(DataType = "duration")]
        public string RemainingDuration { get; set; }
        /// <summary>
        /// The remaining projected cost of completing the task.
        /// </summary>
        public decimal RemainingCost { get; set; }
        /// <summary>
        /// The remaining work scheduled to complete the task.
        /// </summary>
        [XmlElement(DataType = "duration")]
        public string RemainingWork { get; set; }
        /// <summary>
        /// The remaining overtime cost projected to finish the task.
        /// </summary>
        public decimal RemainingOvertimeCost { get; set; }
        /// <summary>
        /// The remaining overtime work scheduled to finish the task.
        /// </summary>
        [XmlElement(DataType = "duration")]
        public string RemainingOvertimeWork { get; set; }
        /// <summary>
        /// The actual cost of work performed on the task to-date.
        /// </summary>
        public float ACWP { get; set; }
        /// <summary>
        /// The earned value cost variance.
        /// </summary>
        public float CV { get; set; }
        /// <summary>
        /// The constraint on the start or finish date of the task. Values are: 0=As Soon As Possible, 1=As Late As Possible, 2=Must Start On, 3=Must Finish On, 4=Start No Earlier Than, 5=Start No Later Than, 6=Finish No Earlier Than and 7=Finish No Later Than.
        /// </summary>
        public ProjectTaskConstraintType ConstraintType { get; set; }
        /// <summary>
        /// The task calendar.Refers to a valid UID in the Calendars element of the Microsoft Project XML Schema.
        /// </summary>
        public int CalendarUID { get; set; }
        /// <summary>
        /// The date argument for the task constraint type.
        /// </summary>
        [DefaultValue(typeof(DateTime), "")]
        public System.DateTime ConstraintDate { get; set; }
        /// <summary>
        /// The deadline for the task to be completed.
        /// </summary>
        [DefaultValue(typeof(DateTime), "")]
        public System.DateTime Deadline { get; set; }
        /// <summary>
        /// Whether leveling can adjust assignments.
        /// </summary>
        [Range(0, 1)]
        public int LevelAssignments { get; set; }
        /// <summary>
        /// Whether leveling can split the task.
        /// </summary>
        [Range(0, 1)]
        public int LevelingCanSplit { get; set; }
        /// <summary>
        /// The delay caused by leveling the task.
        /// </summary>
        public int LevelingDelay { get; set; }
        /// <summary>
        /// The format for expressing the duration of the delay. Values are: 3=m, 4=em, 5=h, 6=eh, 7=d, 8=ed, 9=w, 10=ew, 11=mo, 12=emo, 19=%, 20=e%, 21=null, 35=m?, 36=em?, 37=h?, 38=eh?, 39=d?, 40=ed?, 41=w?, 42=ew?, 43=mo?, 44=emo?, 51=%?, 52=e%? and 53=null.
        /// </summary>
        public ProjectTaskLevelingDelayFormat LevelingDelayFormat { get; set; }
        /// <summary>
        /// The start date of the task before it was leveled.
        /// </summary>
        [DefaultValue(typeof(DateTime), "")]
        public System.DateTime PreLeveledStart { get; set; }
        /// <summary>
        /// The finish date of the task before it was leveled.
        /// </summary>
        [DefaultValue(typeof(DateTime), "")]
        public System.DateTime PreLeveledFinish { get; set; }
        /// <summary>
        /// The title of the hyperlink associated with the task.
        /// </summary>
        [MaxLengthAttribute(512)]
        [StringLengthAttribute(512)]
        public string Hyperlink { get; set; }
        /// <summary>
        /// The hyperlink associated with the task.
        /// </summary>
        [MaxLengthAttribute(512)]
        [StringLengthAttribute(512)]
        public string HyperlinkAddress { get; set; }
        /// <summary>
        /// The document bookmark of the hyperlink associated with the task.
        /// </summary>
        [MaxLengthAttribute(512)]
        [StringLengthAttribute(512)]
        public string HyperlinkSubAddress { get; set; }
        /// <summary>
        /// Whether the task ignores the resource calendar.
        /// </summary>
        [Range(0, 1)]
        public int IgnoreResourceCalendar { get; set; }
        /// <summary>
        /// The text notes associated with the task.
        /// </summary>
        public string Notes { get; set; }
        /// <summary>
        /// Whether the GANTT bar of the task is hidden when displayed in Microsoft Project.
        /// </summary>
        [Range(0, 1)]
        public int HideBar { get; set; }
        /// <summary>
        /// Whether the task is rolled up.
        /// </summary>
        [Range(0, 1)]
        public int Rollup { get; set; }
        /// <summary>
        /// The budgeted cost of work scheduled for the task.
        /// </summary>
        public float BCWS { get; set; }
        /// <summary>
        /// The budgeted cost of work performed on the task to-date.
        /// </summary>
        public float BCWP { get; set; }
        /// <summary>
        /// The percentage complete value entered by the Project Manager. This can be used as an alternative for calculating BCWP.
        /// </summary>
        public int PhysicalPercentComplete { get; set; }
        /// <summary>
        /// The method for calculating earned value. Values are: 0=Percent Complete, 1=Physical Percent Complete.
        /// </summary>
        public ProjectTaskEarnedValueMethod EarnedValueMethod { get; set; }
        /// <summary>
        /// The duration through which actual work is protected.
        /// </summary>
        [XmlElement(DataType = "duration")]
        public string ActualWorkProtected { get; set; }
        /// <summary>
        /// The duration through which actual overtime work is protected.
        /// </summary>
        [XmlElement(DataType = "duration")]
        public string ActualOvertimeWorkProtected { get; set; }
        /// <summary>
        /// Whether the task is published.
        /// </summary>
        [Range(0, 1)]
        public int IsPublished { get; set; }
        /// <summary>
        /// The name of the task status manager.
        /// </summary>
        public string StatusManager { get; set; }
        /// <summary>
        /// The start date of the deliverable.
        /// </summary>
        [DefaultValue(typeof(DateTime), "")]
        public System.DateTime CommitmentStart { get; set; }
        /// <summary>
        /// The finish date of the deliverable.
        /// </summary>
        [DefaultValue(typeof(DateTime), "")]
        public System.DateTime CommitmentFinish { get; set; }
        /// <summary>
        /// Whether the task has an associated deliverable or a dependency on an associated deliverable. Values are: 0=The task has no deliverable or dependency on a deliverable, 1=The task has an associated deliverable, 2=The task has a dependency on an associated deliverable.
        /// </summary>
        public ProjectTaskCommitmentType CommitmentType { get; set; }
        public int BoardStatusColumnOrderingID { get; set; }
        public int SprintColumnOrderingID { get; set; }
        public int NextAvailableBoardStatusColumnOrderingID { get; set; }
        public int NextAvailableSprintOrderingID { get; set; }
        public int SprintUID { get; set; }
        public int BoardColumnUID { get; set; }

        /// <summary>
        /// Defines the predecessor task of the task that contains it.
        /// </summary>
        [XmlElement("PredecessorLink")]
        public List<ProjectTaskPredecessorLink> PredecessorLink
        {
            get
            {
                if ((_predecessorLink == null))
                {
                    _predecessorLink = new List<ProjectTaskPredecessorLink>();
                }
                return _predecessorLink;
            }
            set
            {
                _predecessorLink = value;
            }
        }

        /// <summary>
        /// The value of an extended attribute. Two pieces of data are necessary - a pointer back to the extended attribute table which is specified either by the unique ID or the Field ID, and the value which is specified either with the value, or a pointer back to the value list.
        /// </summary>
        [XmlElement("ExtendedAttribute")]
        public List<ProjectTaskExtendedAttribute> ExtendedAttribute
        {
            get
            {
                if ((_extendedAttribute == null))
                {
                    _extendedAttribute = new List<ProjectTaskExtendedAttribute>();
                }
                return _extendedAttribute;
            }
            set
            {
                _extendedAttribute = value;
            }
        }

        /// <summary>
        /// The collection of baseline values of the task.
        /// </summary>
        [XmlElement("Baseline")]
        public List<ProjectTaskBaseline> Baseline
        {
            get
            {
                if ((_baseline == null))
                {
                    _baseline = new List<ProjectTaskBaseline>();
                }
                return _baseline;
            }
            set
            {
                _baseline = value;
            }
        }

        /// <summary>
        /// The value of an outline code. Two pieces of data are necessary - a pointer to the outline code table that is specified by the FieldID, and the value that is specified either by the ValueID or ValueGUID pointer to the value list.
        /// </summary>
        [XmlElement("OutlineCode")]
        public List<ProjectTaskOutlineCode> OutlineCode
        {
            get
            {
                if ((_outlineCode == null))
                {
                    _outlineCode = new List<ProjectTaskOutlineCode>();
                }
                return _outlineCode;
            }
            set
            {
                _outlineCode = value;
            }
        }

        /// <summary>
        /// The time phased data block associated with the task.
        /// </summary>
        [XmlElement("TimephasedData")]
        public List<TimephasedDataType> TimephasedData
        {
            get
            {
                if ((_timephasedData == null))
                {
                    _timephasedData = new List<TimephasedDataType>();
                }
                return _timephasedData;
            }
            set
            {
                _timephasedData = value;
            }
        }

        private static XmlSerializer SerializerXML
        {
            get
            {
                if ((_serializer == null))
                {
                    _serializer = new XmlSerializerFactory().CreateSerializer(typeof(ProjectTask));
                }
                return _serializer;
            }
        }

        #region Serialize/Deserialize
        /// <summary>
        /// Serialize ProjectTask object
        /// </summary>
        /// <returns>XML value</returns>
        public virtual string Serialize()
        {
            StreamReader streamReader = null;
            MemoryStream memoryStream = null;
            try
            {
                memoryStream = new MemoryStream();
                System.Xml.XmlWriterSettings xmlWriterSettings = new System.Xml.XmlWriterSettings();
                System.Xml.XmlWriter xmlWriter = XmlWriter.Create(memoryStream, xmlWriterSettings);
                SerializerXML.Serialize(xmlWriter, this);
                memoryStream.Seek(0, SeekOrigin.Begin);
                streamReader = new StreamReader(memoryStream);
                return streamReader.ReadToEnd();
            }
            finally
            {
                if ((streamReader != null))
                {
                    streamReader.Dispose();
                }
                if ((memoryStream != null))
                {
                    memoryStream.Dispose();
                }
            }
        }

        /// <summary>
        /// Deserializes ProjectTask object
        /// </summary>
        /// <param name="input">string workflow markup to deserialize</param>
        /// <param name="obj">Output ProjectTask object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool Deserialize(string input, out ProjectTask obj, out Exception exception)
        {
            exception = null;
            obj = default(ProjectTask);
            try
            {
                obj = Deserialize(input);
                return true;
            }
            catch (Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool Deserialize(string input, out ProjectTask obj)
        {
            Exception exception = null;
            return Deserialize(input, out obj, out exception);
        }

        public static ProjectTask Deserialize(string input)
        {
            StringReader stringReader = null;
            try
            {
                stringReader = new StringReader(input);
                return ((ProjectTask)(SerializerXML.Deserialize(XmlReader.Create(stringReader))));
            }
            finally
            {
                if ((stringReader != null))
                {
                    stringReader.Dispose();
                }
            }
        }

        public static ProjectTask Deserialize(Stream s)
        {
            return ((ProjectTask)(SerializerXML.Deserialize(s)));
        }
        #endregion

        /// <summary>
        /// Serializes current ProjectTask object into file
        /// </summary>
        /// <param name="fileName">full path of outupt xml file</param>
        /// <param name="exception">output Exception value if failed</param>
        /// <returns>true if can serialize and save into file; otherwise, false</returns>
        public virtual bool SaveToFile(string fileName, out Exception exception)
        {
            exception = null;
            try
            {
                SaveToFile(fileName);
                return true;
            }
            catch (Exception e)
            {
                exception = e;
                return false;
            }
        }

        public virtual void SaveToFile(string fileName)
        {
            StreamWriter streamWriter = null;
            try
            {
                string dataString = Serialize();
                FileInfo outputFile = new FileInfo(fileName);
                streamWriter = outputFile.CreateText();
                streamWriter.WriteLine(dataString);
                streamWriter.Close();
            }
            finally
            {
                if ((streamWriter != null))
                {
                    streamWriter.Dispose();
                }
            }
        }

        /// <summary>
        /// Deserializes xml markup from file into an ProjectTask object
        /// </summary>
        /// <param name="fileName">string xml file to load and deserialize</param>
        /// <param name="obj">Output ProjectTask object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool LoadFromFile(string fileName, out ProjectTask obj, out Exception exception)
        {
            exception = null;
            obj = default(ProjectTask);
            try
            {
                obj = LoadFromFile(fileName);
                return true;
            }
            catch (Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool LoadFromFile(string fileName, out ProjectTask obj)
        {
            Exception exception = null;
            return LoadFromFile(fileName, out obj, out exception);
        }

        public static ProjectTask LoadFromFile(string fileName)
        {
            FileStream file = null;
            StreamReader sr = null;
            try
            {
                file = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                sr = new StreamReader(file);
                string dataString = sr.ReadToEnd();
                sr.Close();
                file.Close();
                return Deserialize(dataString);
            }
            finally
            {
                if ((file != null))
                {
                    file.Dispose();
                }
                if ((sr != null))
                {
                    sr.Dispose();
                }
            }
        }
    }
}
#pragma warning restore