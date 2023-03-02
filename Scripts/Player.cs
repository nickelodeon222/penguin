using Godot;
using System;

public class Player : KinematicBody2D
{
    [Export]
    public float Speed;
    public Vector2 velocity;

    private float mouseMove = 0;

    public override void _Input(InputEvent @event)
    {
        if (@event is InputEventMouseMotion mouseEvent) {
            mouseMove += Mathf.Atan(mouseEvent.Relative.y * 0.05f) * 0.5f * Mathf.Cos(Rotation * 0.2f);
        }
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _PhysicsProcess(float delta)
    {
        Rotate(mouseMove);
        mouseMove = 0;

        Rotation = Mathf.Clamp(Rotation, -Mathf.Pi/2, Mathf.Pi/2);
        velocity = (Transform.x + Vector2.Right / 2) * Speed;

        var collision = MoveAndCollide(velocity * delta);

        if (collision != null) {
            GameOver();
        }

    }
    
    public void GameOver()
    {
        throw new NotImplementedException();
    }
}
