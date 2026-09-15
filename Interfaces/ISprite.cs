using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Sprint0.Models;

namespace Sprint0.Interfaces;

public interface ISprite
{
    void SetAnimation(CatAnimation animation);

    void Update(GameTime gameTime);

    void Draw(
        SpriteBatch spriteBatch,
        Vector2 position,
        SpriteEffects effects);
}