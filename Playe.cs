using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Pong
{
    public class Player : GameObject, IPlayer
    {
        //player class

        //Fields
        private Vector2 position;
        public static List<int> inputList = new List<int>() {
            0, 0, 0, 0
        };

        //Constructors
        public Player(int playerNumber, int lives, Game game) : base(game)
        {
            PlayerNumber = playerNumber;
            Lives = lives;

            if (PlayerNumber == 1)
            {
                position = new Vector2(-150, position.Y);
            }
            else if (PlayerNumber == 2)
            {
                position = new Vector2(750, position.Y);
            }




        }

        //Properties

        //Hit Box to detect collisions
        public override Rectangle BoundingBox
        {
            get
            {
                return (new Rectangle((int)Position.X, (int)Position.Y, (int)Size, (int)Size));
            }
            set
            {
                return;
            }
        }

            public float Speed
            {
                get; set;
            } = 10;

            public int PlayerNumber
            {
                get; set;
            }

                public override float Size
            {
                get; set;
            } = 200;

            public int Lives
            {
                get; set;
            }

                public override Vector2 Position
            {
                get
                {
                    return position;

                }

                set
                {


                        if (0 < value.Y && value.Y < 280)
                        {
                            position = value;
                        }

                }
            }
                //Methods
                //Initialize called once at the beginning
                    public override void Init()
                {

                }
                //Load in sprites, called once at the beginning
                public override void Load(SpriteBatch spriteBatch)
                {
                    sprite = game.Content.Load<Texture2D>("blackpixel");
                }
                //Update, called once every frame
                public override void Update(GameTime gameTime)
                {
                    if (inputList[PlayerNumber - 1] == 1)
                    {
                        Position = new Vector2(Position.X, Position.Y - Speed);
                    }
                    else if (inputList[PlayerNumber - 1] == -1)
                    {
                        Position = new Vector2(Position.X, Position.Y + Speed);
                    }

                    inputList[PlayerNumber - 1] = 0;
                }
    }
}