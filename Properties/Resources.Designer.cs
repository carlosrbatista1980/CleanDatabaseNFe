﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CleanDatabaseNFe.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("CleanDatabaseNFe.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        public static System.Drawing.Bitmap loading {
            get {
                object obj = ResourceManager.GetObject("loading", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        public static System.Drawing.Bitmap maxresdefault {
            get {
                object obj = ResourceManager.GetObject("maxresdefault", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to /* To prevent any potential data loss issues, you should review this script in detail before running it outside the context of the database designer.*/
        ///USE NFE
        ///BEGIN TRANSACTION
        ///SET QUOTED_IDENTIFIER ON
        ///SET ARITHABORT ON
        ///SET NUMERIC_ROUNDABORT OFF
        ///SET CONCAT_NULL_YIELDS_NULL ON
        ///SET ANSI_NULLS ON
        ///SET ANSI_PADDING ON
        ///SET ANSI_WARNINGS ON
        ///COMMIT
        ///BEGIN TRANSACTION
        ///GO
        ///ALTER TABLE dbo.NFe
        ///	DROP CONSTRAINT FK_NFe_Lote
        ///GO
        ///COMMIT
        ///BEGIN TRANSACTION
        ///GO
        ///ALTER TABLE dbo.NFeCloudQueue
        ///	DROP CONSTRAINT [rest of string was truncated]&quot;;.
        /// </summary>
        public static string sqlCONFIGURATION {
            get {
                return ResourceManager.GetString("sqlCONFIGURATION", resourceCulture);
            }
        }
    }
}