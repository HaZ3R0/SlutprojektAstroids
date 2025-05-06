using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.MediaFoundation;

namespace SlutprojektAstroids;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    Texture2D shipTexture;
    Texture2D bulletTexture;
    Player player;

    Texture2D enemyCTexture;
    List <Circle> enemiesC = new List<Circle>();

    Texture2D enemyTTexture;

    List<Triangel> enemiesT = new List<Triangel>();
  
    double spawnTimer = 0;
    double spawnTInterval = 2;
    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
        _graphics.ToggleFullScreen();
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        enemyCTexture = new Texture2D (GraphicsDevice,1,1);
        enemyCTexture.SetData(new Color[]{Color.White});
        enemyTTexture = new Texture2D(GraphicsDevice,1,1);
        enemyTTexture.SetData(new Color[]{Color.White});
        shipTexture = Content.Load<Texture2D>("Ship");
        bulletTexture = new Texture2D(GraphicsDevice, 1,1);
        bulletTexture.SetData(new Color[]{Color.White});
        player = new Player(shipTexture, new Vector2(400,240), bulletTexture);
        // TODO: use this.Content to load your game content here
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();
        // TODO: Add your update logic here
        
        player.Update();

        spawnTimer += gameTime.ElapsedGameTime.TotalSeconds;

        if (spawnTimer >= spawnTInterval){
            enemiesC.Add(new Circle(enemyCTexture));
            enemiesT.Add(new Triangel(enemyTTexture));
            spawnTimer = 0;
        }
        base.Update(gameTime);

        foreach(var enemyC in enemiesC){
            enemyC.Update();
        }

        foreach(var enemyT in enemiesT){
            enemyT.Update();
        }

        PlayerCircleCollision();
        PlayerTriangelColission();
        BulletCircleColission();
        BulletTriangelColossion();
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.Black);
        _spriteBatch.Begin();
        player.Draw(_spriteBatch);

        foreach(var enemyC in enemiesC){
            enemyC.Draw(_spriteBatch);
        }

        foreach( var enemyT in enemiesT){
            enemyT.Draw(_spriteBatch);
        }
        _spriteBatch.End();

        // TODO: Add your drawing code here

        base.Draw(gameTime);
    }

    void PlayerCircleCollision(){
        foreach (var enemyC in enemiesC){
            if (player.Hitbox.Intersects(enemyC.GetRectangle())){
                Exit();
            }
        }
        
    }

    void PlayerTriangelColission(){
        foreach (var enemyT in enemiesT){
            if (player.Hitbox.Intersects(enemyT.GetRectangle())){
                Exit();
            }
        }
    }

    void BulletCircleColission(){
        for (int ec = 0; ec < enemiesC.Count; ec++){
            for (int b = 0; b < player.Bullets.Count; b++){
                if(enemiesC[ec].GetRectangle().Intersects(player.Bullets[b].GetRectangle())){
                    player.Bullets.RemoveAt(b);
                    enemiesC.RemoveAt(ec);
                }
            }
        }
    }

    void BulletTriangelColossion(){
        for (int et = 0; et < enemiesT.Count; et++){
            for (int b = 0; b <player.Bullets.Count; b++){
                if(enemiesT[et].GetRectangle().Intersects(player.Bullets[b].GetRectangle())){
                    player.Bullets.RemoveAt(b);
                    enemiesT.RemoveAt(et);
                }
            }
        }
    }
}
