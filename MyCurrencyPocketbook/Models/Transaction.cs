using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyCurrencyPocketbook.Models
{
    public class Transaction
    {

        public int Id { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal Amount { get; set; }

        [Required]
        public int PocketAccountId { get; set; }
        // this allows Entity Framework to set it here as a foreign key.
        public virtual PocketAccount PocketAccount { get; set; }
    }
}