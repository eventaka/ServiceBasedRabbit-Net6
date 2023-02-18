using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceBasedRabbit.Core.Dto
{
    public class UserDto
    {

        [Required]
        [RegularExpression(@"^(\d{9})$", ErrorMessage = "The Id user must be 9 digits long.")]
        public int UserId { get; set; } // Taz



    }
}
