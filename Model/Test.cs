using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Institute.Model
{
    public class Test
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100,MinimumLength =3)]
        public string Title { get; set; }

        //Navigation Property
        public ICollection<TestQA> TestQAs { get; set; }
    }
}
