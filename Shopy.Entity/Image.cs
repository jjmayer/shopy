using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopy.Entity
{
    public class Image : Entity
    {
        public byte[] Content { get; set; }
        public string ContentType { get; set; }
        public long ContentLength { get; set; }
    }
}
