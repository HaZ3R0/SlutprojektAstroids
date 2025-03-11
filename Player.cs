using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SlutprojektAstroids
{
    public class Player
    {
        private Texture2D texture;
        private Vector2 position;
        private float rotation;
        
        public Player (Texture2D texture, Vector2 position){
            this.texture = texture;
            this.position = position;
        }

        public void Update(){
            KeyboardState kstate = Keyboard.GetState();
            Vector2 velocity = Vector2.Zero;

            if(kstate.IsKeyDown(Keys.D)){
                rotation += .08f;
            }

            if (kstate.IsKeyDown(Keys.A)){
                rotation -=.08f;
            }

            if (kstate.IsKeyDown(Keys.W)){
                velocity.X = (float)Math.Cos(rotation);
                velocity.Y = (float)Math.Sin(rotation);
            }

            position += velocity * 300 * (1f/60f);
        }
       
        public void Draw(SpriteBatch _spriteBatch){
            _spriteBatch.Draw (texture
            , new Rectangle (position.ToPoint(), new Point (texture.Width, texture.Height))
            , null
            ,Color.White
            ,rotation + MathHelper.PiOver2
            , new Vector2 (texture.Width /2, texture.Height / 2)
            , SpriteEffects.None
            , 0);
        }
    }
}