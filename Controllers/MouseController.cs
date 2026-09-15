using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

using Sprint0.Interfaces;

namespace Sprint0.Controllers;

public class MouseController : IController
{
    private MouseState currentMouse;
    private MouseState previousMouse;

    public void Update()
    {
        previousMouse = currentMouse;

        currentMouse = Mouse.GetState();
    }

    public Vector2 GetMovement()
    {
        return Vector2.Zero;
    }

    public bool IsActionPressed()
    {
        return currentMouse.LeftButton ==
                   ButtonState.Pressed
               &&
               previousMouse.LeftButton ==
                   ButtonState.Released;
    }

    public bool IsQuitPressed()
    {
        return false;
    }
}