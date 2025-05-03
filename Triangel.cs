using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using SharpDX.MediaFoundation;

namespace SlutprojektAstroids
{
    public class Triangel: IEnemy
    {

        private Vector2 position;
        private Vector2 velocity;
        private Texture2D texture;
        private Rectangle hitbox = new Rectangle(0, 0, 0, 0);

        private List <Triangel> enemyTs = new List<Triangel>();

        private Random ran = new Random();

        private float radius;
        private float time;
        private float verticalSpeed;
        private float centerX;
        private float centerY;

        public void Update(){

            time += 0.03f;
            Movement();

            foreach (var enemyT in enemyTs){
                enemyT.Update();
            }

        }

        public Triangel(Texture2D texture){
            this.texture = texture;
            Init();
        }

        public void Movement(){
            float offsetX = (float)Math.Cos(time) * radius;
            float offsetY = (float)Math.Sin(time) * radius;
            
            centerY += verticalSpeed;
            position.X = centerX + offsetX;
            position.Y = centerY + offsetY;
            
            if(position.Y <= 0){
                verticalSpeed = 0.5f;
            }
            
            if (position.Y >= 610){
                verticalSpeed = -0.5f;
            }

            hitbox.X = (int)position.X;
            hitbox.Y = (int)position.Y;
        }
        public void Init(){
            
            int ranP = ran.Next(791);
            int side = ran.Next(2);

            if(side == 0){
                position = new Vector2 (ranP, 0);
                verticalSpeed = 0.5f;
            }
            if(side == 1){
                position = new Vector2 (ranP, 610);
                verticalSpeed = -0.5f;
            }

            centerX = position.X;
            centerY = position.Y;

            time = 0f;

            radius = ran.Next(30, 80);

            hitbox = new Rectangle((int)position.X, (int)position.Y ,50 , 50);
        }

        public void Draw(SpriteBatch _spriteBatch){
            _spriteBatch.Draw(texture, hitbox, Color.BlueViolet);
        }

    }
}