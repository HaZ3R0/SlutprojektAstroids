using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SlutprojektAstroids
{
    public class Bullet
    {
        public Texture2D texture;
        public Vector2 position;
        Rectangle hitbox = new Rectangle();
        Vector2 velocity = Vector2.Zero;

        public Rectangle GetRectangle() => hitbox;

        

        public Bullet (Texture2D texture, Vector2 position, Vector2 velocity){
            this.texture = texture;
            this.position = position;
            this.velocity = velocity;
            hitbox.Width = 5;
            hitbox.Height = 5;
        }

        public void Update(){
            position += velocity * 2 * 300 * (1f/60f);
            hitbox.Location = position.ToPoint();
        }

        public void Draw(SpriteBatch _spriteBatch){
            _spriteBatch.Draw(texture, hitbox, Color.White);
        }
    }
}