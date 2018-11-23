namespace Barbearia.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CABELELEIRO")]
    public partial class CABELELEIRO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CABELELEIRO()
        {
            AGENDA = new HashSet<AGENDA>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(30)]
        public string LOGIN { get; set; }

        [Required]
        [StringLength(200)]
        public string NOME { get; set; }

        [Required]
        [StringLength(100)]
        public string SENHA { get; set; }

        [Required]
        [StringLength(200)]
        public string EMAIL { get; set; }

        [Required]
        [StringLength(11)]
        public string CELULAR { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AGENDA> AGENDA { get; set; }
    }
}
