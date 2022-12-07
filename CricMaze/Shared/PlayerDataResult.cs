using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CricMaze.Shared
{
    public class PlayerDataResult
    {
        public IEnumerable<Player> Players  { get; set; }
        public int Count { get; set; }
    }
}
