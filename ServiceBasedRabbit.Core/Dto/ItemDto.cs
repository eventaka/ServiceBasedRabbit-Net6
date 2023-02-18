using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceBasedRabbit.Core.Dto
{
    public class ItemDto
    {


        [Required]
        public int ItemId { get; set; }

        [Required]
        [StringLength(25)]
        public string Description { get; set; }
        




    }
}
