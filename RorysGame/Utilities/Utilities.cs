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
using Microsoft.Xna.Framework;
using Engine;

namespace RorysGame
{
    static class Utilities
    {
        static public Vector2 GetTranslatedTouchPosition(Vector2 global_position)
        {
            Vector2 position_scale = new Vector2();
            position_scale.X = (float)GameRoot.BoxingViewport.VirtualWidth / (float)GameRoot.BoxingViewport.ViewportWidth;
            position_scale.Y = (float)GameRoot.BoxingViewport.VirtualHeight / (float)GameRoot.BoxingViewport.ViewportHeight;
            var new_position = global_position * position_scale;
            return new_position;
        }

        public static readonly Random Random = new Random();
    }
}