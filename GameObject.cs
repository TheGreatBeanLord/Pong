using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Pong
{
    //Superclass for all game objects (ie: players, ball)
    public abstract class GameObject
    {
        //Feilds
        protected static Random rand;
        public Game game;
        protected Texture2D sprite;

       // public Rectangle boudingBox;
        //Constructors
        public GameObject(Game game)
        {
            this.game = game;
        }

        //Properties
        public abstract Vector2 Position
        {
            get; set;
        }

        public abstract Rectangle BoundingBox
        {
            get; set;
        }

        public abstract float Size
        {
            get; set;
        }
        public bool IsActive
        {
            get; set;
        }



        public Color Color
        {
            get; set;
        } = Color.White;


        //Methods

        //Generate random number
        public void randColor()
        {
            this.Color = new Color(rand.Next(0, 255), rand.Next(0, 255), rand.Next(0, 255));
        }

        //Initialize

        public abstract void Init();

        //Load sprites

        public abstract void Load(SpriteBatch spritePatch);

        //Update class to be called every frame 

        public abstract void Update(GameTime gameTime);
 
        //Draws the sprite
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            Console.WriteLine(this.Position.X.ToString() + " " + this.Position.Y);
            spriteBatch.Draw(sprite, this.Position, null, Color * 1f, 0, Vector2.Zero, Size, SpriteEffects.None, 0f);
        }


    }
}
