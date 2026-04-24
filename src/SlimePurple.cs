using Godot;
using System;

public partial class SlimePurple : CharacterBody2D // Make sure this matches your Node type!
{
	[Export] private RayCast2D _rayCastRight;
	[Export] private RayCast2D _rayCastLeft;
	[Export] private AnimatedSprite2D _animatedSprite;
	[Export] private float _speed = 60.0f;

	private int _direction = -1;
	private float _jumpVelocity = -200.0f;

	public override void _PhysicsProcess(double delta)
	{
		// 1. Get current velocity
		Vector2 velocity = Velocity;

		// 1. Handle Gravity
		if (!IsOnFloor())
		{
			velocity += GetGravity() * (float)delta;
		}
		else
		{
			// 2. Handle Jumping (Only when on floor)
			velocity.Y = _jumpVelocity;
		}
		
		if (_direction == 1 && _rayCastRight != null && _rayCastRight.IsColliding())
		{
			GD.Print("[SlimePurple] Right wall hit, direction -> -1 (face left)");
			_direction = -1;
			if (_animatedSprite != null) _animatedSprite.FlipH = true;
		}
		else if (_direction == -1 && _rayCastLeft != null && _rayCastLeft.IsColliding())
		{
			GD.Print("[SlimePurple] Left wall hit, direction -> 1 (face right)");
			_direction = 1;
			if (_animatedSprite != null) _animatedSprite.FlipH = false;
		}

		// 3. Apply horizontal movement to Velocity
		velocity.X = _direction * _speed;

		// 4. Update the internal Velocity property
		Velocity = velocity;

		// 5. This is the magic part that makes it stop at walls!
		MoveAndSlide();
	}
}
