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
    
    public partial class FACTURE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FACTURE()
        {
            this.BON_SORTIE = new HashSet<BON_SORTIE>();
        }
    
        public string ID_FACTUE { get; set; }
        public Nullable<System.DateTime> DATE_FACT { get; set; }
        public Nullable<decimal> MNT_FACT { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BON_SORTIE> BON_SORTIE { get; set; }
    }
}