//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Pressing.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class B_R
    {
        public string ID_BON_R { get; set; }
        public string ID_SERVICE { get; set; }
        public string REF_ARTICLE { get; set; }
        public Nullable<short> QNTE_S { get; set; }
        public string COULEUR { get; set; }
        public Nullable<System.DateTime> DATE_DISP { get; set; }
        public Nullable<decimal> REMIS { get; set; }
    
        public virtual ARTICLE ARTICLE { get; set; }
        public virtual BON_RECEPTION BON_RECEPTION { get; set; }
        public virtual SERVICE SERVICE { get; set; }
    }
}
