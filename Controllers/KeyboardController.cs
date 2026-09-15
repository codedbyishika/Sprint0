using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

using Sprint0.Interfaces;

namespace Sprint0.Controllers;

public class KeyboardController : IController
{
    private KeyboardState keyboardState;

    public void Update()
    {
        keyboardState = Keyboard.GetState();
    }

    public Vector2 GetMovement()
    {
        Vector2 movement = Vector2.Zero;

        if (keyboardState.IsKeyDown(Keys.A) ||
            keyboardState.IsKeyDown(Keys.Left))
        {
            movement.X -= 1;
        }

        if (keyboardState.IsKeyDown(Keys.D) ||
            keyboardState.IsKeyDown(Keys.Right))
        {
            movement.X += 1;
        }

        if (keyboardState.IsKeyDown(Keys.W) ||
            keyboardState.IsKeyDown(Keys.Up))
        {
            movement.Y -= 1;
        }

        if (keyboardState.IsKeyDown(Keys.S) ||
            keyboardState.IsKeyDown(Keys.Down))
        {
            movement.Y += 1;
        }

        return movement;
    }

    public bool IsActionPressed()
    {
        return false;
    }

    public bool IsQuitPressed()
    {
        return keyboardState.IsKeyDown(Keys.Escape);
    }
}