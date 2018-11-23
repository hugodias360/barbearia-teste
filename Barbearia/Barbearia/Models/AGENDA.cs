namespace Barbearia.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class AGENDA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AGENDA()
        {
            ATENDIMENTO = new HashSet<ATENDIMENTO>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(100)]
        public string STATUS { get; set; }

        [Required]
        [StringLength(100)]
        public string NOME { get; set; }

        public DateTime DATA_INICIO { get; set; }

        public DateTime DATA_FIM { get; set; }

        [Column(TypeName = "money")]
        public decimal VALOR { get; set; }

        [Required]
        [StringLength(500)]
        public string COMENTARIO { get; set; }

        public int ID_CABELELEIRO { get; set; }

        public int? ID_PRODUTO { get; set; }

        public int ID_SERVICO { get; set; }

        public virtual CABELELEIRO CABELELEIRO { get; set; }

        public virtual PRODUTO PRODUTO { get; set; }

        public virtual SERVICO SERVICO { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ATENDIMENTO> ATENDIMENTO { get; set; }
    }
}
