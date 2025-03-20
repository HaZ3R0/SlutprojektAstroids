using System;
using System.Diagnostics;
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
        Vector2 velocity = Vector2.Zero;
        Rectangle hitbox = new Rectangle();        
        
        public Player (Texture2D texture, Vector2 position){
            this.texture = texture;
            this.position = position;
            hitbox.Location = position.ToPoint();
            hitbox.Size = texture.Bounds.Size;
        }

        public void Update(){
            KeyboardState kstate = Keyboard.GetState();

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
            hitbox.Location = position.ToPoint();
        }
       
        public void Draw(SpriteBatch _spriteBatch){
            _spriteBatch.Draw (texture
            , hitbox
            , null
            ,Color.White
            ,rotation + MathHelper.PiOver2
            , new Vector2 (texture.Width /2, texture.Height / 2)
            , SpriteEffects.None
            , 0);
        }
    }
}