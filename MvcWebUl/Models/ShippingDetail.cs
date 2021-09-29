using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MvcWebUl.Models
{
    public class ShippingDetail
    {
        //[Required(ErrorMessage = "İsim gerekli")]
        public string FirstName { get; set; }
        //[Required]
        public string LastName { get; set; }
       // [Required]
        //[DataType(DataType.EmailAddress)]
        public string Email { get; set; }
       // [Required]
        public string City { get; set; }
       // [Required]
        //[MinLength(10,ErrorMessage = "Minumum 10 karekter olmalıdır.")]
        public string Address { get; set; }
       // [Required]
        //[Range(18,65)]
        public int Age { get; set; }

    }
}
