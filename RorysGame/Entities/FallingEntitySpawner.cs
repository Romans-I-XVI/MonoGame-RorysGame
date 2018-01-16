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
using Microsoft.Xna.Framework.Input.Touch;
using Engine;

namespace RorysGame
{
    public class FallingEntitySpawner : Engine.Entity
    {
        public FallingEntitySpawner()
        {

        }

        public override void onUpdate(GameTime gameTime)
        {
            TouchCollection touchCollection = TouchPanel.GetState();

            for (int i = 0; i < touchCollection.Count; i++)
            {
                var touch = touchCollection[i];
                if (touch.State == TouchLocationState.Pressed)
                {
                    var translated_position = Utilities.GetTranslatedTouchPosition(touch.Position);
                    spawnEntity(translated_position);
                }
            }

            base.onUpdate(gameTime);
        }

        private void spawnEntity(Vector2 position)
        {
            var texture = ContentHolder.Get(AvailableTextures.star);
            new FallingEntity(texture, new Vector2(position.X, position.Y));
        }

    }
}