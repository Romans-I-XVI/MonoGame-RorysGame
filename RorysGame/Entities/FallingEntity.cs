using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Engine;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Devices.Sensors;

namespace RorysGame
{
    public class FallingEntity : Engine.Entity
    {
        public float Radius { get { return radius; } }
        private Vector2 _speed = Vector2.Zero;
        private float radius;
        private float friction;

        public FallingEntity(Texture2D texture, Vector2 position)
        {
            _sprite = new Sprite(texture);
            _sprite.AutoOrigin(DrawFrom.Center);
            Position = position;
            friction = getRandomFriction();
            var rnd_scale = getRandomScale();
            radius = ((float)texture.Width / 2f) * rnd_scale;
            _sprite.Scale = new Vector2(rnd_scale);
            _sprite.Color = getRandomColor();
        }

        public override void onUpdate(GameTime gameTime)
        {
            moveWithAccelerometer();
            checkEdgeCollision();
            base.onUpdate(gameTime);
        }

        private Color getRandomColor()
        {
            return Color.White;
        }

        private float getRandomScale()
        {
            int rnd_int = Utilities.Random.Next(5, 11);
            return (float)rnd_int / 10f;
        }

        private float getRandomFriction()
        {
            int rnd_int = Utilities.Random.Next(6500, 9001);
            return (float)rnd_int / 10000f;
        }

        private void moveWithAccelerometer()
        {
            var current_accel = AccelerometerSensor.CurrentAcceleration;
            _speed += current_accel;
            Position += _speed;
        }

        private bool checkEdgeCollision()
        {
            var bounding_rectangle = GameRoot.BoxingViewport.BoundingRectangle;
            bool in_collision = false;

            if (Position.X <= bounding_rectangle.Left + radius)
            {
                if (Position.X < bounding_rectangle.Left + radius)
                    Position.X = bounding_rectangle.Left + radius;
                _speed.X = Math.Abs(_speed.X) * friction;
                in_collision = true;
            }
            else if (Position.X >= bounding_rectangle.Right - radius)
            {
                if (Position.X > bounding_rectangle.Right - radius)
                    Position.X = bounding_rectangle.Right - radius;
                _speed.X = -Math.Abs(_speed.X) * friction;
                in_collision = true;
            }

            if (Position.Y <= bounding_rectangle.Top + radius)
            {
                if (Position.Y < bounding_rectangle.Top + radius)
                    Position.Y = bounding_rectangle.Top + radius;
                _speed.Y = Math.Abs(_speed.Y) * friction;
                in_collision = true;
            }
            else if (Position.Y >= bounding_rectangle.Bottom - radius)
            {
                if (Position.Y > bounding_rectangle.Bottom - radius)
                    Position.Y = bounding_rectangle.Bottom - radius;
                _speed.Y = -Math.Abs(_speed.Y) * friction;
                in_collision = true;
            }

            return in_collision;
        }
    }
}