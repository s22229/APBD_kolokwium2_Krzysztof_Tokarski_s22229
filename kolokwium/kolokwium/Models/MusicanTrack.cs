using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kolokwium.Models
{
    public class MusicanTrack
    {
        public int IdTrack { get; set; }
        public int IdMusican { get; set; }
        public virtual Musican Musican { get; set; }
        public virtual Track Track { get; set; }
    }
}
