using System;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media.Animation;
using System.Windows;

namespace LunchMoneyMatch
{
    class GridLengthAnimation : AnimationTimeline
    {
        private bool boolCompleted;

        //Animation completed
        public bool BoolCompleted
        {
            get { return boolCompleted; }
            set { boolCompleted = value; }
        }

        //Allows the animation to go back
        public double ReverseValue
        {
            get { return (double)GetValue(ReverseValueProperty); }
            set { SetValue(ReverseValueProperty, value); }
        }

        //Dependency property that sets the value of the second animation
        public static readonly DependencyProperty ReverseValueProperty = DependencyProperty.Register("ReverseValue", typeof(double), typeof(GridLengthAnimation), new UIPropertyMetadata(0.0));

        //Object to animate
        public override Type TargetPropertyType
        {
            get { return typeof(GridLength); }
        }

        protected override Freezable CreateInstanceCore()
        {
            return new GridLengthAnimation();
        }

        //Dependency property for the "From" property
        public static readonly DependencyProperty FromProperty = DependencyProperty.Register("From", typeof(GridLength), typeof(GridLengthAnimation));

        //Wrapper for the "From" dependency property
        public GridLength From
        {
            get
            {
                return (GridLength)GetValue(GridLengthAnimation.FromProperty);
            }
            set
            {
                SetValue(GridLengthAnimation.FromProperty, value);
            }
        }

        //Dependency property for the "To" property
        public static readonly DependencyProperty ToProperty = DependencyProperty.Register("To", typeof(GridLength), typeof(GridLengthAnimation));

        //Wrapper for the "To" property
        public GridLength To
        {
            get
            {
                return (GridLength)GetValue(GridLengthAnimation.ToProperty);
            }
            set
            {
                SetValue(GridLengthAnimation.ToProperty, value);
            }
        }

        //The clock for animations
        AnimationClock animationClock;

        //Registers the completed event of the animationClock
        void AnimationCompleted(AnimationClock animationClock)
        {
            if (this.animationClock == null)
            {
                this.animationClock = animationClock;
                this.animationClock.Completed += new EventHandler(delegate(object sender, EventArgs e) { boolCompleted = true; });
            }
        }

        /// <summary>
        /// Animates the grid length set.
        /// </summary>
        /// <param name="defaultOriginValue">The original value to animate.</param>
        /// <param name="defaultDestinationValue">The final value of the animation.</param>
        /// <param name="animationClock">The animation clock.</param>
        /// <returns>The new grid length to the set.</returns>
        public override object GetCurrentValue(object defaultOriginValue, object defaultDestinationValue, AnimationClock animationClock)
        {
            AnimationCompleted(animationClock);
            if (boolCompleted)
                return (GridLength)defaultDestinationValue;

            double fromVal = this.From.Value;
            double toVal = this.To.Value;

            if (((GridLength)defaultOriginValue).Value == toVal)
            {
                fromVal = toVal;
                toVal = this.ReverseValue;
            }
            else
            {
                if (animationClock.CurrentProgress.Value == 1.0)
                    return To;
            }

            if (fromVal > toVal)
            {
                return new GridLength((1 - animationClock.CurrentProgress.Value) * (fromVal - toVal) + toVal, this.From.IsStar ? GridUnitType.Star : GridUnitType.Pixel);
            }
            else
            {
                return new GridLength(animationClock.CurrentProgress.Value * (toVal - fromVal) + fromVal, this.From.IsStar ? GridUnitType.Star : GridUnitType.Pixel);
            }
        }
    }

    //Animate a double value
    public class ExpanderDoubleAnimation : DoubleAnimationBase
    {
        //Dependency property for the "From" property
        public static readonly DependencyProperty FromProperty = DependencyProperty.Register("From", typeof(double?), typeof(ExpanderDoubleAnimation));

        //Wrapper for the "From" property
        public double? From
        {
            get
            {
                return (double?)GetValue(ExpanderDoubleAnimation.FromProperty);
            }
            set
            {
                SetValue(ExpanderDoubleAnimation.FromProperty, value);
            }
        }

        //Dependency property for the "To" property
        public static readonly DependencyProperty ToProperty = DependencyProperty.Register("To", typeof(double?), typeof(ExpanderDoubleAnimation));

        //Wrapper for the "To" property
        public double? To
        {
            get
            {
                return (double?)GetValue(ExpanderDoubleAnimation.ToProperty);
            }
            set
            {
                SetValue(ExpanderDoubleAnimation.ToProperty, value);
            }
        }

        //Sets reverse value for second animation
        public double? ReverseValue
        {
            get { return (double)GetValue(ReverseValueProperty); }
            set { SetValue(ReverseValueProperty, value); }
        }

        //sets the reverse value for the animation
        public static readonly DependencyProperty ReverseValueProperty = DependencyProperty.Register("ReverseValue", typeof(double?), typeof(ExpanderDoubleAnimation), new UIPropertyMetadata(0.0));

        //creates instance of the animation
        protected override Freezable CreateInstanceCore()
        {
            return new ExpanderDoubleAnimation();
        }

        /// <summary>
        /// Animates the double value
        /// </summary>
        /// <param name="defaultOriginValue">The original value to animate.</param>
        /// <param name="defaultDestinationValue">The final value of the animation.</param>
        /// <param name="animationClock">The animation clock.</param>
        /// <returns>Returns the new double to the set.</returns>
        protected override double GetCurrentValueCore(double defaultOriginValue, double defaultDestinationValue, AnimationClock animationClock)
        {
            double fromVal = this.From.Value;
            double toVal = this.To.Value;

            if (defaultOriginValue == toVal)
            {
                fromVal = toVal;
                toVal = this.ReverseValue.Value;
            }

            if (fromVal > toVal)
                return (1 - animationClock.CurrentProgress.Value) *
                    (fromVal - toVal) + toVal;
            else
                return (animationClock.CurrentProgress.Value *
                    (toVal - fromVal) + fromVal);
        }
    }
}
