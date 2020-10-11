using Product.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product.API.Application.Models
{
    public class ProductPictureDto : BaseDto
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string FileName { get; set; }
        public bool IsDefault { get; set; }
        public bool Statu { get; set; }
        public string ThumbFileName { get; set; }
    }
}
