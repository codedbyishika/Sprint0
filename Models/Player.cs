using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Sprint0.Interfaces;

namespace Sprint0.Models;

public class Player : IPlayer
{
    private readonly ISprite sprite;

    private Vector2 velocity;

    private bool facingLeft;

    private double actionTimer;

    public Vector2 Position { get; private set; }

    public int Coins { get; private set; }

    public Rectangle Bounds
    {
        get
        {
            return new Rectangle(
                (int)Position.X + 10,
                (int)Position.Y + 10,
                70,
                70);
        }
    }

    public Player(ISprite sprite)
    {
        this.sprite = sprite;

        Position =
            new Vector2(440, 240);
    }

    public void HandleInput(IController controller)
    {
        Vector2 movement =
            controller.GetMovement();

        if (movement.LengthSquared() > 1)
        {
            movement.Normalize();
        }

        velocity =
            movement * 200f;

        if (movement.X < 0)
        {
            facingLeft = true;
        }
        else if (movement.X > 0)
        {
            facingLeft = false;
        }

        // Don't change the animation while
        // the mouse-click animation is playing.
        if (actionTimer <= 0)
        {
            if (movement.X != 0)
            {
                sprite.SetAnimation(
                    CatAnimation.Walk);
            }
            else
            {
                sprite.SetAnimation(
                    CatAnimation.Idle);
            }
        }
    }

    public void DoAction()
    {
        actionTimer = 0.5;

        sprite.SetAnimation(CatAnimation.Attack);
    }

    public void Update(
        GameTime gameTime,
        Rectangle screenBounds)
    {
        float deltaTime =
            (float)gameTime
                .ElapsedGameTime
                .TotalSeconds;

        Position +=
            velocity * deltaTime;

        // Keep cat inside the screen.
        Position = new Vector2(
            MathHelper.Clamp(
                Position.X,
                0,
                screenBounds.Width - 96),

            MathHelper.Clamp(
                Position.Y,
                0,
                screenBounds.Height - 96));

        if (actionTimer > 0)
        {
            actionTimer -= deltaTime;
        }

        sprite.Update(gameTime);
    }

    public void CollectCoin()
    {
        Coins++;
    }

    public void Draw(
        SpriteBatch spriteBatch)
    {
        SpriteEffects effects;

        if (facingLeft)
        {
            effects = SpriteEffects.FlipHorizontally;
        }
        else
        {
            effects = SpriteEffects.None;
        }

        sprite.Draw(
            spriteBatch,
            Position,
            effects);
    }
}