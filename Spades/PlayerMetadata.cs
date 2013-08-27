using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spades
{
    public class PlayerMetadata
    {
        public int Order { get; internal set; }
        public Guid Identifier { get; internal set; }
        public IPlayer Player { get; internal set; }
        public Team Team { get; internal set; }

        public PlayerMetadata(int order, IPlayer player)
        {
            Order = order;
            Player = player;
            Identifier = Guid.NewGuid();
        }

    }
}
