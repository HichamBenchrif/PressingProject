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
    
    public partial class ARTICLE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ARTICLE()
        {
            this.ARTICLE_AJOUTE = new HashSet<ARTICLE_AJOUTE>();
            this.B_R = new HashSet<B_R>();
            this.BON_SORTIE = new HashSet<BON_SORTIE>();
        }
    
        public string REF_ARTICLE { get; set; }
        public string ID_CATE { get; set; }
        public string N_FAMILL { get; set; }
        public string LIB_ARTICLE { get; set; }
        public Nullable<decimal> PRIX_REPASSAGE { get; set; }
        public Nullable<decimal> PRIX_LESSIVE { get; set; }
        public byte[] IMAGE { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ARTICLE_AJOUTE> ARTICLE_AJOUTE { get; set; }
        public virtual CATEGORIE_ARTILCLE CATEGORIE_ARTILCLE { get; set; }
        public virtual FAMILL FAMILL { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<B_R> B_R { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BON_SORTIE> BON_SORTIE { get; set; }
    }
}
