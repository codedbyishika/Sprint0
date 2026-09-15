using Microsoft.Xna.Framework;

namespace Sprint0.Interfaces;

public interface IController
{
    void Update();

    Vector2 GetMovement();

    bool IsActionPressed();

    bool IsQuitPressed();
}