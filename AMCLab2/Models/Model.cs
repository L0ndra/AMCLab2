using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMCLab2.Models
{
    public class Model
    {
        public IterateMethod IM { get; set; }
        public TouchingMethod TM { get; set; }

        public Model()
        {
            IM = new IterateMethod();
            TM = new TouchingMethod();
        }
    }
}
