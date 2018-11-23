namespace Barbearia.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PRODUTO")]
    public partial class PRODUTO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PRODUTO()
        {
            AGENDA = new HashSet<AGENDA>();
            ESTOQUE = new HashSet<ESTOQUE>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(200)]
        public string NOME { get; set; }

        [Column(TypeName = "money")]
        public decimal VALOR { get; set; }

        [StringLength(500)]
        public string ESPECIFICACAO { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AGENDA> AGENDA { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ESTOQUE> ESTOQUE { get; set; }
    }
}
