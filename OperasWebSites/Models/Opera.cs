using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace OperasWebSites.Models
{
    public class Opera
    {
        public int OperaID { get; set; }

        [Required]
        [StringLength(200)]
        public string Title { get; set; }

        [Required]
        [CheckValidYear]
        public int Year { get; set; }

        public string Composer { get; set; }
    }

    [AttributeUsage(AttributeTargets.Property)]
    public class CheckValidYear : ValidationAttribute
    {

        public CheckValidYear()
        {
            ErrorMessage = "The earliest Opera is Daphne, 1598, by Corsi, Peri and Rinuccini.";
        }

        public override bool IsValid(object value)
        {
            int year = (int)value;
            if( year < 1598 )
            {
                return false;
            }

            return true;
        }
    }
}