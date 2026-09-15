using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Interfaces;

namespace Sprint0.Models;

public enum CatAnimation
{
    Idle = 0,
    Walk = 1,
    Attack = 5
}

public class CatSprite : ISprite
{
    private readonly Texture2D texture;

    private CatAnimation animation = CatAnimation.Idle;

    private int currentFrame = 0;

    private double animationTimer = 0;

    private const int FrameWidth = 72;
    private const int FrameHeight = 72;

    private const int FramesInWalk = 4;

    private const double FrameTime = 0.12;

    public CatSprite(Texture2D texture)
    {
        this.texture = texture;
    }

    public void SetAnimation(CatAnimation nextAnimation)
    {
        // Idle should always stay on frame 0.
        if (nextAnimation == CatAnimation.Idle)
        {
            animation = CatAnimation.Idle;
            currentFrame = 0;
            animationTimer = 0;
            return;
        }

        if (animation != nextAnimation)
        {
            animation = nextAnimation;
            currentFrame = 0;
            animationTimer = 0;
        }
    }

    public void Update(GameTime gameTime)
    {
        if (animation == CatAnimation.Idle)
        {
            currentFrame = 0;
        }

        animationTimer +=
            gameTime.ElapsedGameTime.TotalSeconds;

        if (animationTimer >= FrameTime)
        {
            animationTimer -= FrameTime;

            currentFrame++;

            if (currentFrame >= FramesInWalk)
            {
                currentFrame = 0;
            }
        }
    }

    public void Draw(
        SpriteBatch spriteBatch,
        Vector2 position,
        SpriteEffects effects)
    {
        Rectangle sourceRectangle =
            new Rectangle(
                currentFrame * FrameWidth,
                (int)animation * FrameHeight,
                FrameWidth,
                FrameHeight);

        spriteBatch.Draw(
            texture,
            position,
            sourceRectangle,
            Color.White,
            0f,
            Vector2.Zero,
            1.5f,
            effects,
            0f);
    }
}