using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using RecursiveMazeGeneration;

namespace MazeGame
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>

    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D WSEN, WSE, WSN, WS, WEN, WE, WN, W, SEN, SE, SN, S, EN, E, N, Blank;
        MazeGrid mazeGrid;
        MazeCell[,] allGridCells;
        Texture2D[,] cellTexutres;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            //mazeGrid = new MazeGrid(new Point(137,77), 14);
            mazeGrid = new MazeGrid(new Point(240, 135), 8);
            cellTexutres = new Texture2D[mazeGrid.getGridSize().X, mazeGrid.getGridSize().Y];
            graphics.PreferredBackBufferHeight = 1080;
            graphics.PreferredBackBufferWidth = 1920;
            graphics.IsFullScreen = false;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            mazeGrid.generate();
            allGridCells = mazeGrid.getGrid();
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            WSEN = Content.Load<Texture2D>("WSEN");
            WSE = Content.Load<Texture2D>("WSE");
            WSN = Content.Load<Texture2D>("WSN");
            WS = Content.Load<Texture2D>("WS");
            WEN = Content.Load<Texture2D>("WEN");
            WE = Content.Load<Texture2D>("WE");
            WN = Content.Load<Texture2D>("WN");
            W = Content.Load<Texture2D>("W");
            SEN = Content.Load<Texture2D>("SEN");
            SE = Content.Load<Texture2D>("SE");
            SN = Content.Load<Texture2D>("SN");
            S = Content.Load<Texture2D>("S");
            EN = Content.Load<Texture2D>("EN");
            E = Content.Load<Texture2D>("E");
            N = Content.Load<Texture2D>("N");
            Blank = Content.Load<Texture2D>("Blank");

            assignCellTextures();
            // TODO: use this.Content to load your game content here
        }

        private void assignCellTextures()
        {
            for (int x = 0; x < mazeGrid.getGridSize().X; x++)
            {
                for (int y = 0; y < mazeGrid.getGridSize().Y; y++)
                {
                    switch (allGridCells[x, y].getWalls())
                    {
                        case 15:
                            cellTexutres[x, y] = WSEN;
                            break;
                        case 14:
                            cellTexutres[x, y] = WSE;
                            break;
                        case 13:
                            cellTexutres[x, y] = WSN;
                            break;
                        case 12:
                            cellTexutres[x, y] = WS;
                            break;
                        case 11:
                            cellTexutres[x, y] = WEN;
                            break;
                        case 10:
                            cellTexutres[x, y] = WE;
                            break;
                        case 9:
                            cellTexutres[x, y] = WN;
                            break;
                        case 8:
                            cellTexutres[x, y] = W;
                            break;
                        case 7:
                            cellTexutres[x, y] = SEN;
                            break;
                        case 6:
                            cellTexutres[x, y] = SE;
                            break;
                        case 5:
                            cellTexutres[x, y] = SN;
                            break;
                        case 4:
                            cellTexutres[x, y] = S;
                            break;
                        case 3:
                            cellTexutres[x, y] = EN;
                            break;
                        case 2:
                            cellTexutres[x, y] = E;
                            break;
                        case 1:
                            cellTexutres[x, y] = N;
                            break;
                        case 0:
                            cellTexutres[x, y] = Blank;
                            break;
                        default:
                            throw new Exception("YOU DUN GOOFED");
                    }
                }
            }
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                this.Exit();
            if (Keyboard.GetState().IsKeyDown(Keys.R))
            {
                mazeGrid = new MazeGrid(new Point(240, 135), 8);
                mazeGrid.generate();
                allGridCells = mazeGrid.getGrid();
                assignCellTextures();
            }

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            for (int x = 0; x < mazeGrid.getGridSize().X; x++)
            {
                for (int y = mazeGrid.getGridSize().Y - 1; y >= 0; y--)
                {
                    spriteBatch.Draw(cellTexutres[x, y], new Rectangle(allGridCells[x, y].getPosition().X, allGridCells[x, y].getPosition().Y, mazeGrid.getCellLength(), mazeGrid.getCellLength()), Color.White);
                }
            }
            spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
