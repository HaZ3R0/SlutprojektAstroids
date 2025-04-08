using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml;
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
        private Vector2 velocity = Vector2.Zero;
        private Rectangle hitbox = new Rectangle();
        
        private List<Bullet> bullets = new List<Bullet>();
        private Texture2D bulletTexture;

    
        KeyboardState previousKeyState;


        
        public Player (Texture2D texture, Vector2 position, Texture2D bulletTexture){
            this.texture = texture;
            this.position = position;
            this.bulletTexture = bulletTexture;
            hitbox.Location = position.ToPoint();
            hitbox.Size = (texture.Bounds.Size.ToVector2() / 1.2f).ToPoint();
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

            if(kstate.IsKeyDown(Keys.Space)  && previousKeyState.IsKeyUp(Keys.Space)){
                Shoot();
            }

            position += velocity * 300 * (1f/60f);
            hitbox.Location = position.ToPoint();
            
            foreach (var bullet in bullets){
                bullet.Update();
            }
            previousKeyState = kstate;

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

             foreach (var bullet in bullets)
            {
                bullet.Draw(_spriteBatch);
            }
        }

        private void Shoot(){
            Vector2 bulletVelocity = new Vector2(MathF.Cos(rotation), MathF.Sin(rotation));
            bullets.Add(new Bullet(bulletTexture, position, bulletVelocity));
        }
        
    }
}