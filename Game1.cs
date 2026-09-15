using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

using Sprint0.Controllers;
using Sprint0.Interfaces;
using Sprint0.Models;

namespace Sprint0;

public class Game1 : Game
{
    private readonly GraphicsDeviceManager graphics;

    private SpriteBatch spriteBatch;

    private Texture2D catTexture;

    private Texture2D backgroundTexture;

    private Texture2D coinTexture;

    private IPlayer player;

    private IController keyboardController;

    private IController mouseController;

    private Coin currentCoin;

    //private SpriteFont font;

    private readonly Random random = new Random();

    private const int ScreenWidth = 960;

    private const int ScreenHeight = 540;

    public Game1()
    {
        graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;

        graphics.PreferredBackBufferWidth = ScreenWidth;

        graphics.PreferredBackBufferHeight = ScreenHeight;
    }

    protected override void Initialize()
    {
        keyboardController = new KeyboardController();

        mouseController = new MouseController();

        base.Initialize();
    }

    protected override void LoadContent()
    {
        spriteBatch = new SpriteBatch(GraphicsDevice);

        catTexture =
            Content.Load<Texture2D>(
                "images/catpixil");

        backgroundTexture =
            Content.Load<Texture2D>(
                "images/backgroundsprite");

        coinTexture =
            Content.Load<Texture2D>(
                "images/coinpixil");

        //font =
        //Content.Load<SpriteFont>(
        //    "GameFont.spritefont");

        ISprite catSprite =
            new CatSprite(catTexture);

        player =
            new Player(catSprite);

        SpawnCoin();
    }

    private void SpawnCoin()
    {
        int x =
            random.Next(
                50,
                ScreenWidth - 80);

        int y =
            random.Next(
                70,
                ScreenHeight - 80);

        currentCoin =
            new Coin(
                new Vector2(x, y));
    }

    protected override void Update(
        GameTime gameTime)
    {
        keyboardController.Update();

        mouseController.Update();

        if (keyboardController.IsQuitPressed())
        {
            Exit();

            return;
        }

        player.HandleInput(
            keyboardController);

        player.Update(
            gameTime,

            new Rectangle(
                0,
                0,
                ScreenWidth,
                ScreenHeight));

        if (mouseController.IsActionPressed())
        {
            player.DoAction();
        }

        CheckCoinCollection();

        base.Update(gameTime);
    }

    private void CheckCoinCollection()
    {
        if (currentCoin == null)
        {
            return;
        }

        if (player.Bounds.Intersects(
            currentCoin.Bounds))
        {

            player.CollectCoin();

            SpawnCoin();
        }
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(
            Color.CornflowerBlue);

        spriteBatch.Begin();

        spriteBatch.Draw(
            backgroundTexture,

            new Rectangle(
                0,
                0,
                ScreenWidth,
                ScreenHeight),

            Color.White);

        if (currentCoin != null)
        {
            currentCoin.Draw(
                spriteBatch,
                coinTexture);
        }

        player.Draw(
            spriteBatch);

        //DrawTitle();

        DrawScore();

        spriteBatch.End();

        base.Draw(gameTime);
    }

    /*
    private void DrawTitle()
    {
        string title =
            "Cat Collects Coins";

        Vector2 textSize =
            font.MeasureString(title);

        Vector2 position =
            new Vector2(
                (ScreenWidth - textSize.X) / 2,
                20);

        spriteBatch.DrawString(
            font,
           title,
            position,
           Color.White);
    }
    */

    private void DrawScore()
    {
        int coinSize = 28;

        int x =
            ScreenWidth -
            40 -
            coinSize;

        int y =
            20;

        for (int i = 0;
             i < player.Coins;
             i++)
        {
            spriteBatch.Draw(
                coinTexture,

                new Rectangle(
                    x -
                    i * (coinSize + 5),

                    y,

                    coinSize,
                    coinSize),

                Color.White);
        /*
        string scoreText =
            "Coins: " +
            player.Coins;

        Vector2 position =
            new Vector2(
                20,
                20);

        //spriteBatch.DrawString(
        //    font,
        //    scoreText,
        //    position,
        //    Color.White);
        }
        */
        }
    }
}
