//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ASP.NETEntityFramework
{
    using System;
    using System.Collections.Generic;
    
    public partial class Customer
    {
        public int CustomerIDs { get; set; }
        public string CustomerNames { get; set; }
        public Nullable<int> CustomerAges { get; set; }
        public string CustomerCity { get; set; }
        public Nullable<int> CustomerPhone { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerPhoto { get; set; }
        public Nullable<int> IDcITY { get; set; }
    
        public virtual City City1 { get; set; }
    }
}
