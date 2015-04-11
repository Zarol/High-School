using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using System.IO;

namespace ByteHunter.Screen_Manager
{
    /// <summary>
    /// Describes the varios transitional states.
    /// </summary>
    public enum State
    {
        TransitionOn,
        TransitionOff,
        Active,
        Hidden,
    }

    /// <summary>
    /// A screen is a single layer with its own update and draw logic.
    /// </summary>
    public abstract class Screen
    {
        #region Properties
        /// <summary>
        /// This property indicates that this screen is a popup.
        /// </summary>
        public bool IsPopup
        {
            get { return isPopup; }
            protected set { isPopup = value; }
        }
        bool isPopup = false;

        /// <summary>
        /// This property indicates how long it takes for the
        /// screen to transition "on" when it is activated.
        /// </summary>
        public TimeSpan TransitionOnTime
        {
            get { return transitionOnTime; }
            protected set { transitionOnTime = value; }
        }
        TimeSpan transitionOnTime = TimeSpan.Zero;

        /// <summary>
        /// This property indicates how long it takes for the
        /// screen to transition "off" when it is deactivated.
        /// </summary>
        public TimeSpan TransitionOffTime
        {
            get { return transitionOffTime; }
            protected set { transitionOffTime = value; }
        }
        TimeSpan transitionOffTime = TimeSpan.Zero;

        /// <summary>
        /// This property indicates the current position of the screen transition. 
        /// Zero (Fully Active, Transitioning, Fully Off) One.
        /// </summary>
        public float TransitionPosition
        {
            get { return transitionPosition; }
            protected set { transitionPosition = value; }
        }
        float transitionPosition = 1;

        /// <summary>
        /// This property indicates the current Alpha value of the
        /// screen transition.
        /// One (Fully Active, Transitioning, Fully Off) Zero.
        /// </summary>
        public float TransitionAlpha
        {
            get { return 1f - TransitionPosition; }
        }

        /// <summary>
        /// This property indicates the screen transition state.
        /// </summary>
        public State ScreenState
        {
            get { return screenState; }
            protected set { screenState = value; }
        }
        State screenState = State.TransitionOn;

        /// <summary>
        /// This property indicates whether the screen is either
        /// temporarily exiting or completely exiting. If set,
        /// the screen will automatically remove itself.
        /// </summary>
        public bool IsExiting
        {
            get { return isExiting; }
            protected internal set { isExiting = value; }
        }
        bool isExiting = false;

        /// <summary>
        /// This property indicates whether the screen is active.
        /// </summary>
        public bool IsActive
        {
            get{ return !isActive && (screenState == State.TransitionOn || screenState == State.Active); }
        }
        bool isActive;

        /// <summary>
        /// This property determines what Screen Manager this
        /// screen belongs to.
        /// </summary>
        public ScreenManager ScreenManager
        {
            get { return screenManager; }
            internal set { screenManager = value; }
        }
        ScreenManager screenManager;
        #endregion

        #region Methods
        /// <summary>
        /// This method loads the content for the screen.
        /// </summary>
        public virtual void LoadContent() { }

        /// <summary>
        /// This method unloads the content for the screen.
        /// </summary>
        public virtual void UnloadContent() { }

        /// <summary>
        /// This method runs the screen logic. It is called regardless
        /// of whether the screen is Active, Hidden, or Transitioning.
        /// </summary>
        /// <param name="gameTime">The original GameTime must be passed through.</param>
        /// <param name="isActive">Whether or not the screen is active.</param>
        /// <param name="covered">Whether or not the screen is covered by another screen.</param>
        public virtual void Update(GameTime gameTime, bool isActive, bool covered)
        {
            this.isActive = isActive;
            
            if (isExiting)
            {
                screenState = State.TransitionOff;

                if (!UpdateTransition(gameTime, transitionOffTime, 1))
                {
                    ScreenManager.RemoveScreen(this);
                }
            }
            else if (covered)
            {
                if (UpdateTransition(gameTime, transitionOffTime, 1))
                {
                    screenState = State.TransitionOff;
                }
                else
                {
                    screenState = State.Hidden;
                }
            }
            else
            {
                if (UpdateTransition(gameTime, transitionOnTime, -1))
                {
                    screenState = State.TransitionOn;
                }
                else
                {
                    screenState = State.Active;
                }
            }
        }

        /// <summary>
        /// This method acts as a helper method for
        /// updating screen transition position.
        /// </summary>
        /// <param name="gameTime">The original GameTime must be passed through.</param>
        /// <param name="time">The time for transitioning.</param>
        /// <param name="direction">The direction of the transition.</param>
        /// <returns>False, The screen no longer needs to be updated. True, The screen is being updated.</returns>
        bool UpdateTransition(GameTime gameTime, TimeSpan time, int direction)
        {
            float deltaTransition;

            if (time == TimeSpan.Zero)
                deltaTransition = 1;
            else
                deltaTransition = (float)(gameTime.ElapsedGameTime.TotalMilliseconds / time.TotalMilliseconds);

            transitionPosition += deltaTransition * direction;

            if (((direction < 0) && (transitionPosition <= 0)) || ((direction > 0) && (transitionPosition >= 1)))
            {
                transitionPosition = MathHelper.Clamp(transitionPosition, 0, 1);
                return false;
            }

            return true;
        }

        /// <summary>
        /// This method allows the screen to draw itself.
        /// </summary>
        /// <param name="gameTime">The original GameTime must be passed through.</param>
        public virtual void Draw(GameTime gameTime) { }

        /// <summary>
        /// Exits the screen with respect to transition timings.
        /// </summary>
        public void ExitScreen()
        {
            if (transitionOffTime == TimeSpan.Zero)
            {
                ScreenManager.RemoveScreen(this);
            }
            else
            {
                isExiting = true;
            }
        }
        #endregion
    }
}
