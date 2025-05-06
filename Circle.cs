using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace SlutprojektAstroids
{
    public class Circle: IEnemy
    {

        private Vector2 position;
        private Vector2 velocity;
        private Texture2D texture;
        private Rectangle hitbox = new Rectangle(0, 0, 0, 0);
        
        private List<Circle> enemyCs = new List<Circle>();
        
        Random ran = new Random();
        private float time;
        private float initialY;

        public Rectangle GetRectangle() => hitbox;
        
        public void Update(){
            Movement();

            foreach (var enemyC in enemyCs){
                enemyC.Update();
            }
        }
        
        public Circle(Texture2D texture){
            this.texture = texture;
            Init();
        }
        public void Movement(){
            
            position.X += velocity.X;

            position.Y = initialY + MathF.Abs(MathF.Sin(time) * 100f);
            time += 1f/60f;

            hitbox.X = (int)position.X;
            hitbox.Y = (int)position.Y;

        }

        public void Init(){

            int ranP = ran.Next(611);
            int side = ran.Next(2);
            int ranV = ran.Next(1,3);

             if(side == 0){
                position = new Vector2 (0 ,ranP);
                velocity = new Vector2 (ranV, 0);
            }
            if(side == 1){
                position = new Vector2 (790 ,ranP);
                velocity = new Vector2 (-ranV , 0);
            }

            initialY = position.Y;

            time = 0f;

            hitbox = new Rectangle((int)position.X, (int)position.Y ,50 , 50);
        }

        public void Draw(SpriteBatch _spriteBatch){
            _spriteBatch.Draw(texture, hitbox, Color.Red);
        }
    }
}