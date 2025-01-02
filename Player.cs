using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuntTheWumpus1
{
    public class Player
    {
        public bool canSee { get; set; }
        public Sound Hear { get; set; }
        public bool canSmell { get; set; }
    }

    public enum Sound { dripping, rushing };
}