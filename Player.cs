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
            if(kstate.IsKeyDown(Keys.D)){
                rotation += .02f;
            }

            if (kstate.IsKeyDown(Keys.A)){
                rotation -=.02f;
            }
        }
       
        public void Draw(SpriteBatch _spriteBatch){
            _spriteBatch.Draw (texture, new Vector2 (0,0), Color.White);
        }
    }
}