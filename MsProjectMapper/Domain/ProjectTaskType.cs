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
/// The type of task. Values are: 0=Fixed Units, 1=Fixed Duration, 2=Fixed Work.
/// </summary>
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.4084.0")]
[Serializable]
[XmlTypeAttribute(AnonymousType=true, Namespace="http://schemas.microsoft.com/project")]
public enum ProjectTaskType
{
    [XmlEnumAttribute("0")]
    FixedUnits,
    [XmlEnumAttribute("1")]
    FixedDuration,
    [XmlEnumAttribute("2")]
    FixedWork,
}
}
#pragma warning restore