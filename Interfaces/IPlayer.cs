using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.Interfaces;

public interface IPlayer
{
    Vector2 Position { get; }

    Rectangle Bounds { get; }

    int Coins { get; }

    void HandleInput(IController controller);

    void DoAction();

    void Update(
        GameTime gameTime,
        Rectangle screenBounds);

    void CollectCoin();

    void Draw(SpriteBatch spriteBatch);
}