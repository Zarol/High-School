using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace ByteHunter.Screen_Manager
{

    /// <summary>
    /// The screen manager is a component that manages screens.
    /// It maintains a stack of screens, calls their Update and
    /// Draw methods, as well as routing input to the active screen.
    /// </summary>
    public class ScreenManager : DrawableGameComponent
    {
        #region Properties

        List<Screen> screens = new List<Screen>();
        List<Screen> screensToUpdate = new List<Screen>();


        SpriteBatch spriteBatch;
        Texture2D alphaFader;

        bool isInitialized;
        bool debugTrace;

        /// <summary>
        /// The default SpriteBatch shared across all screens.
        /// </summary>
        public SpriteBatch SpriteBatch
        {
            get { return spriteBatch; }
        }

        /// <summary>
        /// The debug property that prints out the list
        /// of screens being updated.
        /// </summary>
        public bool DebugTrace
        {
            get { return debugTrace; }
            set { debugTrace = value; }
        }

        #endregion

        #region Initialization
        /// <summary>
        /// The constructor method for ScreenManager.
        /// </summary>
        /// <param name="game">The original game must be passed through.</param>
        public ScreenManager(Game game)
            : base(game)
        {

        }

        /// <summary>
        /// Initializes the Screen Manager.
        /// </summary>
        public override void Initialize()
        {
            base.Initialize();

            isInitialized = true;
        }

        /// <summary>
        /// Loads the graphic content.
        /// </summary>
        protected override void LoadContent()
        {
            ContentManager content = Game.Content;

            spriteBatch = new SpriteBatch(GraphicsDevice);
            alphaFader = content.Load<Texture2D>("Misc/AlphaFader");

            foreach (Screen screen in screens)
            {
                screen.LoadContent();
            }
        }

        /// <summary>
        /// Unloads the graphic content.
        /// </summary>
        protected override void UnloadContent()
        {
            foreach (Screen screen in screens)
            {
                screen.UnloadContent();
            }
        }

        #endregion

        #region Update & Draw

        /// <summary>
        /// Traverses each screen and Updates them.
        /// </summary>
        /// <param name="gameTime">The original GameTime must be passed through.</param>
        public override void Update(GameTime gameTime)
        {

            screensToUpdate.Clear();

            foreach (Screen screen in screens)
                screensToUpdate.Add(screen);

            bool isActive = !Game.IsActive;
            bool covered = false;

            while (screensToUpdate.Count > 0)
            {
                Screen screen = screensToUpdate[screensToUpdate.Count - 1];
                screensToUpdate.RemoveAt(screensToUpdate.Count - 1);
                screen.Update(gameTime, isActive, covered);

                if (screen.ScreenState == State.TransitionOn || screen.ScreenState == State.Active)
                {
                    if (!isActive)
                    {
                        isActive = true;
                    }
                    if (!screen.IsPopup)
                        covered = true;
                }
            }
            if (debugTrace)
                TraceScreens();
        }

        /// <summary>
        /// Prints a list of all the screens being updated.
        /// </summary>
        private void TraceScreens()
        {
            List<string> screenNames = new List<string>();
            foreach (Screen screen in screens)
                screenNames.Add(screen.GetType().Name);

            Debug.WriteLine(string.Join(", ", screenNames.ToArray()));
        }

        /// <summary>
        /// Traverses each screen and Draws them.
        /// </summary>
        /// <param name="gameTime">The original GameTime must be passed through.</param>
        public override void Draw(GameTime gameTime)
        {
            foreach (Screen screen in screens)
            {
                if (screen.ScreenState == State.Hidden)
                    continue;
                screen.Draw(gameTime);
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// The method to add a screen to the screen manager.
        /// </summary>
        /// <param name="screen">The screen to be managed.</param>
        public void AddScreen(Screen screen)
        {
            screen.ScreenManager = this;
            screen.IsExiting = false;

            if (isInitialized)
            {
                screen.LoadContent();
            }

            screens.Add(screen);
        }

        /// <summary>
        /// The method to instantly remove the screen.
        /// Screen.ExitScreen() should be used for transitioning the removal.
        /// </summary>
        /// <param name="screen">The screen to be removed.</param>
        public void RemoveScreen(Screen screen)
        {
            if (isInitialized)
            {
                screen.UnloadContent();
            }
            screens.Remove(screen);
            screensToUpdate.Remove(screen);
        }

        /// <summary>
        /// This method exposes a copy of an array holding all the screens.
        /// </summary>
        /// <returns>A copy of all the screens within ScreenManager.</returns>
        public Screen[] GetScreens()
        {
            return screens.ToArray();
        }

        /// <summary>
        /// The helper method used for fading screens and darkening backgroudns.
        /// </summary>
        /// <param name="alpha">The intensity of the blackness.</param>
        public void FadeBackBufferToBlack(float alpha)
        {
            Viewport viewport = GraphicsDevice.Viewport;

            spriteBatch.Begin();
            spriteBatch.Draw(alphaFader,new Rectangle(0,0,viewport.Width,viewport.Height),Color.Black * alpha);
            spriteBatch.End();
        }

        #endregion
    }
}
