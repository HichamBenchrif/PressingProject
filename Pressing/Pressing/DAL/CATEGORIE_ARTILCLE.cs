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
    
    public partial class CATEGORIE_ARTILCLE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CATEGORIE_ARTILCLE()
        {
            this.ARTICLEs = new HashSet<ARTICLE>();
        }
    
        public string ID_CATE { get; set; }
        public string LIB_CAT_ART { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ARTICLE> ARTICLEs { get; set; }
    }
}
