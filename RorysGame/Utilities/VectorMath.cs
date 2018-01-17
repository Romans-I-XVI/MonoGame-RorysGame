using System;
using Microsoft.Xna.Framework;

namespace RorysGame
{
    public static class VectorMath
    {
        public static float VectorToHypotenuse(Vector2 vector)
        {
            return (float)Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);
        }

        public static double VectorToAngle(Vector2 vector)
        {
            return Math.Atan2(vector.Y, vector.X);
        }

        public static Vector2 HypotenuseToVector(float hypotenuse, double angle)
        {
            float x = (float)(Math.Cos(angle) * hypotenuse);
            float y = (float)(Math.Sin(angle) * hypotenuse);
            return new Vector2(x, y);
        }

        public static float TotalDistance(Vector2 position1, Vector2 position2)
        {
            float x_distance = position1.X - position2.X;
            float y_distance = position1.Y - position2.Y;
            float total_distance = (float)Math.Sqrt(x_distance * x_distance + y_distance * y_distance);
            return total_distance;
        }

        public static Vector2 MoveTowards(Vector2 current_pos, Vector2 dest_pos, float total_speed)
        {
            float x_distance = current_pos.X - dest_pos.X;
            float y_distance = current_pos.Y - dest_pos.Y;
            float angle = (float)VectorToAngle(new Vector2(x_distance, y_distance));

            var speed_vector = HypotenuseToVector(total_speed, angle);

            return current_pos -= speed_vector;
        }
    }
}
