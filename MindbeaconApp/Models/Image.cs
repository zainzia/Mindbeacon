using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MindbeaconApp.Models
{
    public class Image
    {
        public Image()
        {

        }

        public int? ID { get; set; }

        public DateTime? CreatedAt { get; set; }

        public string  Name { get; set; }

        public string ImageURL { get; set; }
    }
}
