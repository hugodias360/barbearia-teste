namespace Barbearia.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ATENDIMENTO")]
    public partial class ATENDIMENTO
    {
        public int ID { get; set; }

        [Required]
        [StringLength(100)]
        public string STATUS { get; set; }

        [Required]
        [StringLength(100)]
        public string CHECKIN { get; set; }

        [Required]
        [StringLength(200)]
        public string CHECKOUT { get; set; }

        [Column(TypeName = "money")]
        public decimal VALOR { get; set; }

        public int ID_AGENDA { get; set; }

        public virtual AGENDA AGENDA { get; set; }
    }
}
