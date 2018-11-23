namespace Barbearia.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ESTOQUE")]
    public partial class ESTOQUE
    {
        public int ID { get; set; }

        public int QUANTIDADE { get; set; }

        [Column(TypeName = "date")]
        public DateTime VALIDADE { get; set; }

        public int ID_PRODUTO { get; set; }

        public virtual PRODUTO PRODUTO { get; set; }
    }
}
