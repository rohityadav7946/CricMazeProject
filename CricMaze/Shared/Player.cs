using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CricMaze.Shared
{
    public class Player
    {
        public int PlayerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Country { get; set; }
        public int Matches { get; set; }
        public int Runs { get; set; }
        public int Highest { get; set; }
        public int Wickets { get; set; }
        
        public Role Role { get; set; }
        public int TeamId { get; set; }
        

        public Team Team { get; set; }
    }
}
