using Product.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product.API.Application.Models
{
    public class CategoryDto : BaseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
