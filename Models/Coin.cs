using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.Models;

public class Coin
{
    public Vector2 Position { get; }

    public Rectangle Bounds =>
        new Rectangle(
            (int)Position.X,
            (int)Position.Y,
            32,
            32);

    public Coin(Vector2 position)
    {
        Position = position;
    }

    public void Draw(
        SpriteBatch spriteBatch,
        Texture2D coinTexture)
    {
        spriteBatch.Draw(
            coinTexture,
            Bounds,
            Color.White);
    }
}