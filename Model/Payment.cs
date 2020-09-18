using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Institute.Model
{
    public class Payment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Column(TypeName ="money")]
        public decimal Amount { get; set; }

        public string PaidBy { get; set; }

        [Required]
        public string Medium { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Column(TypeName ="date")]
        public DateTime PaymentedDate { get; set; }

        [Required]
        [DefaultValue(false)]
        public bool Confirmed { get; set; }
    }
}
