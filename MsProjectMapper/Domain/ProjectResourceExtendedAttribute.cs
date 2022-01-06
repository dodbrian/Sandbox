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
/// There must be at least one resource in each Resources collection.
/// </summary>
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.4084.0")]
[Serializable]
[DebuggerStepThrough]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[XmlTypeAttribute(AnonymousType=true, Namespace="http://schemas.microsoft.com/project")]
public partial class ProjectResourceExtendedAttribute
{
    private static XmlSerializer _serializer;
    /// <summary>
    /// The project ID (PID) of the custom field.
    /// </summary>
        public string FieldID { get; set; }
    /// <summary>
    /// The actual value of the extended attribute.
    /// </summary>
        public string Value { get; set; }
    /// <summary>
    /// The GUID of the value in the extended attribute lookup table.
    /// </summary>
        [XmlElement(DataType="integer")]
        public string ValueGUID { get; set; }
    /// <summary>
    /// The format for expressing the bulk duration. Values are: 3=m, 4=em, 5=h, 6=eh, 7=d, 8=ed, 9=w, 10=ew, 11=mo, 12=emo, 19=%, 20=e%, 21=null, 35=m?, 36=em?, 37=h?, 38=eh?, 39=d?, 40=ed?, 41=w?, 42=ew?, 43=mo?, 44=emo?, 51=%?, 52=e%? and 53=null.
    /// </summary>
        public ProjectResourceExtendedAttributeDurationFormat DurationFormat { get; set; }

    private static XmlSerializer SerializerXML
    {
        get
        {
            if ((_serializer == null))
            {
                _serializer = new XmlSerializerFactory().CreateSerializer(typeof(ProjectResourceExtendedAttribute));
            }
            return _serializer;
        }
    }

    #region Serialize/Deserialize
    /// <summary>
    /// Serialize ProjectResourceExtendedAttribute object
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
    /// Deserializes ProjectResourceExtendedAttribute object
    /// </summary>
    /// <param name="input">string workflow markup to deserialize</param>
    /// <param name="obj">Output ProjectResourceExtendedAttribute object</param>
    /// <param name="exception">output Exception value if deserialize failed</param>
    /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
    public static bool Deserialize(string input, out ProjectResourceExtendedAttribute obj, out Exception exception)
    {
        exception = null;
        obj = default(ProjectResourceExtendedAttribute);
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

    public static bool Deserialize(string input, out ProjectResourceExtendedAttribute obj)
    {
        Exception exception = null;
        return Deserialize(input, out obj, out exception);
    }

    public static ProjectResourceExtendedAttribute Deserialize(string input)
    {
        StringReader stringReader = null;
        try
        {
            stringReader = new StringReader(input);
            return ((ProjectResourceExtendedAttribute)(SerializerXML.Deserialize(XmlReader.Create(stringReader))));
        }
        finally
        {
            if ((stringReader != null))
            {
                stringReader.Dispose();
            }
        }
    }

    public static ProjectResourceExtendedAttribute Deserialize(Stream s)
    {
        return ((ProjectResourceExtendedAttribute)(SerializerXML.Deserialize(s)));
    }
    #endregion

    /// <summary>
    /// Serializes current ProjectResourceExtendedAttribute object into file
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
    /// Deserializes xml markup from file into an ProjectResourceExtendedAttribute object
    /// </summary>
    /// <param name="fileName">string xml file to load and deserialize</param>
    /// <param name="obj">Output ProjectResourceExtendedAttribute object</param>
    /// <param name="exception">output Exception value if deserialize failed</param>
    /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
    public static bool LoadFromFile(string fileName, out ProjectResourceExtendedAttribute obj, out Exception exception)
    {
        exception = null;
        obj = default(ProjectResourceExtendedAttribute);
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

    public static bool LoadFromFile(string fileName, out ProjectResourceExtendedAttribute obj)
    {
        Exception exception = null;
        return LoadFromFile(fileName, out obj, out exception);
    }

    public static ProjectResourceExtendedAttribute LoadFromFile(string fileName)
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