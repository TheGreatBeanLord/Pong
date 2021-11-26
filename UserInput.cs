using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Pong
{
    //Class to handle user input
    class UserInput
    {

        public static bool hasStarted = false;

        public static void Update(GameTime gameTime)
        {

            //Keyboard Input
            KeyboardState state = Keyboard.GetState();
            Vector2 Direction = new Vector2();
            if (state.IsKeyDown(Keys.W))
            {
                Player.inputList[0] = 1;
            }
            else if (state.IsKeyDown(Keys.S))
            {
                Player.inputList[0] = -1;
            }
            if (state.IsKeyDown(Keys.Up))
            {
                Player.inputList[1] = 1;

            }
            if (state.IsKeyDown(Keys.Down))
            {
                Player.inputList[1] = -1;

            }
         }
    }
}