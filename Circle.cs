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
        private Rectangle hitbox = new Rectangle(0, 0, 20, 20);

        private List<Circle> enemyCs = new List<Circle>();

        Random ran = new Random();
        private float time;

        public void Update(){
            Init();
            Movement();
        }
        
        public Circle(Texture2D texture, Rectangle hitbox){
            this.texture = texture;
            this.hitbox = hitbox;
        }
        public void Movement(){
            
            position.X += velocity.X;

            position.Y = MathF.Abs(MathF.Sin(time));
            time += 1f/60f * 3;
        }

        public void Init(){

            int ranP = ran.Next(611);
            int side = ran.Next(2);
            position = new Vector2(790, ranP);

            if(side == 1){
                position.X = 0;
            }
            velocity = new Vector2 (3, 0);
            time = 0f;
        }

        public void Draw(SpriteBatch _spriteBatch){
            _spriteBatch.Draw (texture, hitbox, Color.Red);

            foreach (var enemyC in enemyCs){
                enemyC.Draw(_spriteBatch);
            }

        }
    }
}