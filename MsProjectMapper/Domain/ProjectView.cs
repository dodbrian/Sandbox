﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//    Generated by Xsd2Code++. Version 5.2.97.0. www.xsd2code.com
//  </auto-generated>
// ------------------------------------------------------------------------------

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

#pragma warning disable
namespace MsProjectMapper
{
    /// <summary>
    /// Project view definition
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.4084.0")]
    [Serializable]
    [DebuggerStepThrough]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [XmlType(AnonymousType=true, Namespace="http://schemas.microsoft.com/project")]
    public class ProjectView
    {
        /// <summary>
        /// View name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Whether the view is customized
        /// </summary>
        [DefaultValue(false)]
        public bool IsCustomized { get; set; }
    }
}
#pragma warning restore