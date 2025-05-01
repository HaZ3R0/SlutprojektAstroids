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
    double spawnTimer = 0;
    double spawnTInterval = 3;

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
            spawnTimer = 0;
        }
        base.Update(gameTime);

        foreach(var enemyC in enemiesC){
            enemyC.Update();
        }
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.Black);
        _spriteBatch.Begin();
        player.Draw(_spriteBatch);

        foreach(var enemyC in enemiesC){
            enemyC.Draw(_spriteBatch);
        }
        _spriteBatch.End();

        // TODO: Add your drawing code here

        base.Draw(gameTime);
    }
}
