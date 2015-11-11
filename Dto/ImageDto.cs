using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto
{
    public class ImageDto
    {
        public int ImageId { set; get; }
        public string  ImageTitle { set; get; }
        public string ImageUrl { set; get; }
        public int ImageCategory { set; get; }
        public string ImageHref { set; get; }
        public string ImageDescription { set; get; }
        public bool ImageStatus { set; get; }
    }
}
