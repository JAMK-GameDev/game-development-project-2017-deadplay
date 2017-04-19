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
        public const float UP_DEGREES = 0;
        public const float RIGHT_DEGREES = 90;
        public const float DOWN_DEGREES = 180;
        public const float LEFT_DEGREES = 270;

        /// <summary>
        //  Perform check, so only ever valid values are assigned as facing degrees.
        /// The value must be between 0 and 360
        /// </summary>
        /// <param name="direction"></param>
        /// <param name="value"></param>
        /// <returns>true if this is a valid value for a degree</returns>
        public static bool IsValidDegree(double value)
        {
            return (value >= 0 && value <= 360);
        }

        public static ActorDirection ParseDegrees(double degrees)
        {
            ActorDirection direction;

            if (degrees < 45) direction = ActorDirection.Up;
            else if (degrees < 135) direction = ActorDirection.Right;
            else if (degrees < 225) direction = ActorDirection.Down;
            else if (degrees < 315) direction = ActorDirection.Left;
            else direction = ActorDirection.Up;

            return direction;
        }

        public static float GetDegrees(ActorDirection direction)
        {
            float degree;
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

        public static double UpDegrees(ActorDirection direction)
        {
            return UP_DEGREES;
        }
        public static double RightDegrees(ActorDirection direction)
        {
            return RIGHT_DEGREES;
        }
        public static double DownDegrees(ActorDirection direction)
        {
            return DOWN_DEGREES;
        }
        public static double LeftDegrees(ActorDirection direction)
        {
            return LEFT_DEGREES;
        }
    }
}
