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
        List<FallingEntity> falling_entities = new List<FallingEntity>();
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
                    var entity = spawnEntity(translated_position);
                    falling_entities.Add(entity);
                }
            }

            base.onUpdate(gameTime);
        }

        public override void onButtonDown(GamePadEventArgs e)
        {
            if (e.Button == Microsoft.Xna.Framework.Input.Buttons.Back)
            {
                foreach (var entity in falling_entities)
                {
                    entity.IsExpired = true;
                }
                falling_entities.Clear();
            }
            base.onButtonDown(e);
        }

        private FallingEntity spawnEntity(Vector2 position)
        {
            Array values = Enum.GetValues(typeof(AvailableTextures));
            AvailableTextures random_texture = (AvailableTextures)values.GetValue(Utilities.Random.Next(values.Length));
            var texture = ContentHolder.Get(random_texture);
            return new FallingEntity(texture, new Vector2(position.X, position.Y));
        }

    }
}