﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//    Generated by Xsd2Code++. Version 5.2.97.0. www.xsd2code.com
//  </auto-generated>
// ------------------------------------------------------------------------------

using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Xml.Serialization;

#pragma warning disable
namespace MsProjectMapper
{
    /// <summary>
    /// Project board column definition
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.4084.0")]
    [Serializable]
    [DebuggerStepThrough]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [XmlType(AnonymousType=true, Namespace="http://schemas.microsoft.com/project")]
    public class ProjectBoardColumn
    {
        /// <summary>
        /// Board column UID
        /// </summary>
        public int UID { get; set; }
        /// <summary>
        /// The unique GUID of the task.
        /// </summary>
        [Required()]
        [RegularExpressionAttribute("[a-fA-F0-9]{8}-[a-fA-F0-9]{4}-[a-fA-F0-9]{4}-[a-fA-F0-9]{4}-[a-fA-F0-9]{12}")]
        public Guid GUID { get; set; }
        public bool ShouldSerializeGUID() => GUID != Guid.Empty;
        /// <summary>
        /// Board column ID
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// Board column name
        /// </summary>
        public string Name { get; set; }
    }
}
#pragma warning restore
