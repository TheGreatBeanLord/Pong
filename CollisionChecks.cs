using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Pong
{
    class CollisionChecks
    {
        //Checks if the two rectangle (hitboxes) of game object A and B are colliding, returns true if they are
        public static bool AABBRects(GameObject objectA, GameObject objectB)
        {
            //Makes sure we arn't comparing an object to itself
            if (objectA == objectB)
            {
                return false;
            }

            else
            {
                Rectangle boxA = objectA.BoundingBox;
                Rectangle boxB = objectB.BoundingBox;
                return (boxA.Left < boxB.Right &&
               boxA.Right > boxB.Left &&
               boxA.Top < boxB.Bottom &&
               boxA.Bottom > boxB.Top);
            }
        }
    }
}
