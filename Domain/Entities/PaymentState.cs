using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Entities
{
    public class PaymentState
    {
        [Key]
        public int ID { get; set; }
        public string Status { get; set; }
    }
}
