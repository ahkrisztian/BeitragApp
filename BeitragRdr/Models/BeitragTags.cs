using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeitragRdr.Models
{
    public class BeitragTags
    {
        public int BeitragId { get; set; }
        public Beitrag Beitrag { get; set; }

        public int TagId { get; set; }
        public Tags Tags { get; set; }
    }
}
