using BussinessObject.Models;
using System;

namespace E_Food_Admin.Models
{
    public class TransactionApiModel
    {
        public int TransactionId { get; set; }
        public int? PaymentMethodId { get; set; }
        public int? AccountId { get; set; }
        public int? Value { get; set; }
        public string TimeTrans { get; set; }
        public bool IsSuccess { get; set; }
        public string Note { get; set; }
      
    }
}
