using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Institute.Model
{
    public class EnrollmentPayment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int EnrollmentId { get; set; }

        [Required]
        public int PaymentDetailId { get; set; }

        [Required]
        [Column(TypeName ="decimal(4,2)")]
        public decimal Discount { get; set; }

        //Navigation Property
        public PendingEnrollment Enrollment { get; set; }

        public Payment PaymentDetail { get; set; }
    }
}
