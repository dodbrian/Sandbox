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
/// The collection of baseline values of the task.
/// </summary>
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.4084.0")]
[Serializable]
[DebuggerStepThrough]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[XmlTypeAttribute(AnonymousType=true, Namespace="http://schemas.microsoft.com/project")]
public partial class ProjectTaskBaseline
{
    private List<TimephasedDataType> _timephasedData;
    private static XmlSerializer _serializer;
    /// <summary>
    /// The unique number of the baseline data record.
    /// </summary>
        [XmlElement(DataType="integer")]
        public string Number { get; set; }
    /// <summary>
    /// Whether this is an Interim Baseline.
    /// </summary>
        [DefaultValue(false)]
        public bool Interim { get; set; }
    /// <summary>
    /// The scheduled start date of the task when the baseline was saved.
    /// </summary>
        public System.DateTime Start { get; set; }
    /// <summary>
    /// The scheduled finish date of the task when the baseline was saved.
    /// </summary>
        public System.DateTime Finish { get; set; }
    /// <summary>
    /// The scheduled duration of the task when the baseline was saved.
    /// </summary>
        [XmlElement(DataType="duration")]
        public string Duration { get; set; }
    /// <summary>
    /// The format for expressing the Duration of the Task baseline. Values are: 3=m, 4=em, 5=h, 6=eh, 7=d, 8=ed, 9=w, 10=ew, 11=mo, 12=emo, 19=%, 20=e%, 21=null, 35=m?, 36=em?, 37=h?, 38=eh?, 39=d?, 40=ed?, 41=w?, 42=ew?, 43=mo?, 44=emo?, 51=%?, 52=e%? and 53=null.
    /// </summary>
        public ProjectTaskBaselineDurationFormat DurationFormat { get; set; }
    /// <summary>
    /// Whether the baseline duration of the task was estimated.
    /// </summary>
        public bool EstimatedDuration { get; set; }
    /// <summary>
    /// The scheduled work of the task when the baseline was saved.
    /// </summary>
        [XmlElement(DataType="duration")]
        public string Work { get; set; }
    /// <summary>
    /// The projected cost of the task when the baseline was saved.
    /// </summary>
        public decimal Cost { get; set; }
    /// <summary>
    /// The budgeted cost of work scheduled for the task.
    /// </summary>
        public float BCWS { get; set; }
    /// <summary>
    /// The budgeted cost of work performed on the task to-date.
    /// </summary>
        public float BCWP { get; set; }
    /// <summary>
    /// The fixed cost of the task when the baseline was saved.
    /// </summary>
        public float FixedCost { get; set; }

    /// <summary>
    /// ProjectTaskBaseline class constructor
    /// </summary>
    public ProjectTaskBaseline()
    {
        Interim = false;
    }

    /// <summary>
    /// The time phased data block associated with the task baseline.
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
                _serializer = new XmlSerializerFactory().CreateSerializer(typeof(ProjectTaskBaseline));
            }
            return _serializer;
        }
    }

    #region Serialize/Deserialize
    /// <summary>
    /// Serialize ProjectTaskBaseline object
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
    /// Deserializes ProjectTaskBaseline object
    /// </summary>
    /// <param name="input">string workflow markup to deserialize</param>
    /// <param name="obj">Output ProjectTaskBaseline object</param>
    /// <param name="exception">output Exception value if deserialize failed</param>
    /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
    public static bool Deserialize(string input, out ProjectTaskBaseline obj, out Exception exception)
    {
        exception = null;
        obj = default(ProjectTaskBaseline);
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

    public static bool Deserialize(string input, out ProjectTaskBaseline obj)
    {
        Exception exception = null;
        return Deserialize(input, out obj, out exception);
    }

    public static ProjectTaskBaseline Deserialize(string input)
    {
        StringReader stringReader = null;
        try
        {
            stringReader = new StringReader(input);
            return ((ProjectTaskBaseline)(SerializerXML.Deserialize(XmlReader.Create(stringReader))));
        }
        finally
        {
            if ((stringReader != null))
            {
                stringReader.Dispose();
            }
        }
    }

    public static ProjectTaskBaseline Deserialize(Stream s)
    {
        return ((ProjectTaskBaseline)(SerializerXML.Deserialize(s)));
    }
    #endregion

    /// <summary>
    /// Serializes current ProjectTaskBaseline object into file
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
    /// Deserializes xml markup from file into an ProjectTaskBaseline object
    /// </summary>
    /// <param name="fileName">string xml file to load and deserialize</param>
    /// <param name="obj">Output ProjectTaskBaseline object</param>
    /// <param name="exception">output Exception value if deserialize failed</param>
    /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
    public static bool LoadFromFile(string fileName, out ProjectTaskBaseline obj, out Exception exception)
    {
        exception = null;
        obj = default(ProjectTaskBaseline);
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

    public static bool LoadFromFile(string fileName, out ProjectTaskBaseline obj)
    {
        Exception exception = null;
        return LoadFromFile(fileName, out obj, out exception);
    }

    public static ProjectTaskBaseline LoadFromFile(string fileName)
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