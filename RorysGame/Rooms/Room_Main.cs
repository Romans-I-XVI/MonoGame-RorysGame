using Engine;
using Microsoft.Xna.Framework;

namespace RorysGame
{
    public class Room_Main : Room
    {
        public override void OnCreate()
        {
            new FallingEntitySpawner();
        }
    }
}

