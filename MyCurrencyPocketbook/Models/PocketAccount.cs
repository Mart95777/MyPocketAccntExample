using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyCurrencyPocketbook.Models
{
    public class PocketAccount
    {
        public int Id { get; set; }

        [Required]
        //[StringLength(10, MinimumLength = 6)]
        [Column(TypeName ="varchar")]
        [RegularExpression(@"\d{6,10}", ErrorMessage ="Account number must be between 6 and 10 digits.")]
        [Display(Name = "Pocket Acc. #")]
        public string PocketAccountNumber { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        public string FullName
        {
            get{ return string.Format("{0} {1}", this.FirstName, this.LastName); }
        }

        [DataType(DataType.Currency)]
        public decimal Balance { get; set; }

        public virtual ApplicationUser User { get; set; }

        public string ApplicationUserId { get; set; }

        public virtual ICollection<Transaction> Transactions { get; set; }

    }
}