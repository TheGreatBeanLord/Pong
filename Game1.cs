using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System;
using System.Diagnostics;

namespace Pong
{
    public class Game1 : Game
    {
        //Main game/functionality class
        
        //Declare graphics variables
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        //Declare game objects and stats
        public static List<Player> playerList;
        public static List<GameObject> gameObjects;
        public static int[] points = { 0, 0 };

        public static Random rand;

        //Declare font variables
        public SpriteFont font;

        //Main Method, called when game starts
        public Game1()
        {
            rand = new Random();

            //Graphics stuff idk
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            //Create new lists for game objects
            playerList = new List<Player>();
            gameObjects = new List<GameObject>();
    }

        //Initialization, called once at beginning
        protected override void Initialize()
        {
            //Create game objects
            playerList.Add(new Player(1, 3, this));
            playerList.Add(new Player(2, 3, this));

            gameObjects.Add(new Ball(rand, this, playerList));


            gameObjects.AddRange(playerList);

            //Initialize game objects
            foreach (GameObject element in gameObjects)
            {
                element.Init();
            }

            base.Initialize();
        }

        //Loads in content, called once at beginning
        protected override void LoadContent()
        {
            //graphics
            font = Content.Load<SpriteFont>("myFont");
            _spriteBatch = new SpriteBatch(GraphicsDevice);

       


            //Call load method in gameobjects
            foreach (GameObject element in gameObjects)
            {
                element.Load(_spriteBatch);
            }
        }

        //Update method, called once per frame
        protected override void Update(GameTime gameTime)
        {

            //Check user input
            UserInput.Update(gameTime);

            //Exit if escape is pressed
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            //Calls update method in each gameobject 
            foreach (GameObject element in gameObjects)
            {
                element.Update(gameTime);
            }



            base.Update(gameTime);
        }

        //Draw method, called once per frame after update
        protected override void Draw(GameTime gameTime)
        {
            //clear canvas
            GraphicsDevice.Clear(Color.GhostWhite);

            //Start drawing
            _spriteBatch.Begin();

            //Call draw in each gameobject
            foreach (GameObject element in gameObjects)
            {
                element.Draw(_spriteBatch);
            }

            //Draw scores
            _spriteBatch.DrawString(font, points[0].ToString(), new Vector2(300, 20), Color.Black);

            _spriteBatch.DrawString(font, points[1].ToString(), new Vector2(450, 20), Color.Black);

            //Stop drawing
            _spriteBatch.End();


            base.Draw(gameTime);
        }
        //Add points
        public static void AddPoint(int pointsChange, int playerNum)
        {
            points[playerNum] += pointsChange;
            
        }

      
    }
}
