using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Pong
{
    //Interface for players
    interface IPlayer
    {
        public int PlayerNumber { get; set; }
        public int Lives { get; set; }
        public Vector2 Position { get; set; }

    }
}
