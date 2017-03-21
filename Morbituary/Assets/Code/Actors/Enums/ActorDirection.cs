using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Code.Actors.Enums
{
    public enum ActorDirection
    {
        Up, Down, Left, Right
    }

    /// <summary>
    /// Helper class for Actor Direction
    /// </summary>
    public static class ActorDirectionMethods
    {
        public const double UP_DEGREES = 0;
        public const double RIGHT_DEGREES = 90;
        public const double DOWN_DEGREES = 180;
        public const double LEFT_DEGREES = 270;

        /// <summary>
        //  Perform check, so only ever valid values are assigned as facing degrees.
        /// The value must be between 0 and 360
        /// </summary>
        /// <param name="direction"></param>
        /// <param name="value"></param>
        /// <returns>true if this is a valid value for a degree</returns>
        public static bool IsValidDegree(this ActorDirection direction, double value)
        {
            return (value >= 0 && value <= 360);
        }

        public static ActorDirection ParseDegrees(this ActorDirection self, double degrees)
        {
            ActorDirection direction;

            if (degrees < 45) direction = ActorDirection.Up;
            else if (degrees < 135) direction = ActorDirection.Right;
            else if (degrees < 225) direction = ActorDirection.Down;
            else if (degrees < 315) direction = ActorDirection.Left;
            else direction = ActorDirection.Up;

            return direction;
        }

        public static double GetDegrees(this ActorDirection direction)
        {
            double degree;
            switch (direction)
            {
                case ActorDirection.Up:
                    degree = UP_DEGREES;
                    break;
                case ActorDirection.Right:
                    degree = RIGHT_DEGREES;
                    break;
                case ActorDirection.Down:
                    degree = DOWN_DEGREES;
                    break;
                case ActorDirection.Left:
                    degree = LEFT_DEGREES;
                    break;
                default: throw new ArgumentException("ActorDirection may not be null!");
            }
            return degree;
        }

        public static double UpDegrees(this ActorDirection direction)
        {
            return UP_DEGREES;
        }
        public static double RightDegrees(this ActorDirection direction)
        {
            return RIGHT_DEGREES;
        }
        public static double DownDegrees(this ActorDirection direction)
        {
            return DOWN_DEGREES;
        }
        public static double LeftDegrees(this ActorDirection direction)
        {
            return LEFT_DEGREES;
        }
    }
}
