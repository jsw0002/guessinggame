using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GuessingGame2.Models
{
    public class Guessing
    {
        [Required]
        [MaxLength(20, ErrorMessage = "That name is too long, Do you have a nickname?")]
        [MinLength(2, ErrorMessage = "You need to input a valid name.")]
        [Display(Name = "Player Name")]
        public string PlayerName { get; set; }

        [Required]
        [Range(1, 10, ErrorMessage = "You need to enter a number between 1 and 10.")]
        public int Guess { get; set; }

        public override string ToString()
        {
            return String.Format("{0} ({1})", PlayerName, Guess);
        }
    }
}