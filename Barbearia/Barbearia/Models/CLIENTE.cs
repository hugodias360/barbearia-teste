namespace Barbearia.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CLIENTE")]
    public partial class CLIENTE
    {
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
    }
}
