using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;
//using System.Windows.Media;

namespace Pong
{
    //Class for the ball
    public class Ball : GameObject
    {
        //Feilds
        private Vector2 velocity = new Vector2(1, 1);
        private Vector2 position;
       // private Random rand;
        private List<Player> playerList;
        public SpriteFont font;


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

        // Has an X and Y value to decide the velocity of the ball
        public Vector2 Velocity
        {
            get { return velocity; }
            set
            {
                velocity = value;
            }
        }

        //Position
        public override Vector2 Position
        {
            get { return position; }
            set
            {
                if (value.X - Size > 800 || value.X + Size < 0)
                {
                   if (value.X > 400)
                    {
                        Game1.points[1] += 1;

                    }
                    else
                    {
                        Game1.points[0] += 1;

                    }
                    this.Init();
                 
                    return;
                }  
                    else if (value.Y + Size > 480 || value.Y < 0)
                {
                    velocity.Y  *= -1;
                    randColor();
                    return;
                }
                else
                { position = value; }
            }
        }

        //Size 
        public override float Size
        {
            get; set;
        } = 50;

        //Constructors

        //Get neccesary values when making a new Ball object
        public Ball(Random random, Game game, List<Player> playersList) : base(game)
        {
            rand = random;
            playerList = playersList;
        }


        //Methods
   

        //Runs AABBRects method in ColisionChecks to check if hitbox is colliding with the player hitbox
        public void CheckCollisions()
        {
            for (int index = 0; index < playerList.Count; index++) {
                if(CollisionChecks.AABBRects(this, playerList[index]))
                {
                    if ((playerList[index].PlayerNumber == 1 && Position.X > playerList[index].Position.X + velocity.X) || (playerList[index].PlayerNumber == 2 && Position.X < playerList[index].Position.X - velocity.X))
                    {
                        Debug.WriteLine("HIT!");
                        velocity.X *= -1f;
                        velocity *= 1.2f;
                        randColor();
                        playerList[index].randColor();
                    }

                        else
                    {
                        velocity.Y *= -1;
                    }

                }
            }

        }

        //Randomize the color of the ball

 


        //Initialize
        public override void Init()
        {
            Debug.WriteLine("aa");
            velocity = new Vector2(-2, 2);
            Position = new Vector2((800 / 2 - Size), (480 / 2 - Size));
            randColor();
        }

        //Load sprites
        public override void Load(SpriteBatch spritePatch)
        {

            sprite = game.Content.Load<Texture2D>("1x1_#ffffffff");
        }

        //Update class to be called every frame 
        public override void Update(GameTime gameTime)
        {
            CheckCollisions();
            Position += Velocity;
        }
    }
}
