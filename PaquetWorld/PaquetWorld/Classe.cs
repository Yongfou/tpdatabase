//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PaquetWorld
{
    using System;
    using System.Collections.Generic;
    
    public partial class Classe
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Classe()
        {
            this.Heros = new HashSet<Hero>();
        }
    
        public int Id { get; set; }
        public string NomClasse { get; set; }
        public string Description { get; set; }
        public int StatBaseStr { get; set; }
        public int StatBaseDex { get; set; }
        public int StatBaseInt { get; set; }
        public int StatBaseVitalite { get; set; }
        public int MondeId { get; set; }
    
        public virtual Monde Monde { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Hero> Heros { get; set; }
    }
}