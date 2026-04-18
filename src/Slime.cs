using Godot;
using System;

public partial class Slime : Node2D
{
	[Export] RayCast2D _rayCastRight;
	[Export] RayCast2D _rayCastLeft;
	[Export] private AnimatedSprite2D _animatedSprite;
	[Export] private int _speed = 60;
	private int _direction = -1;

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		// 1. Check collisions (Notice the Capital Letters for methods)
		if (_rayCastRight != null && _rayCastRight.IsColliding())
		{
			// Get the object the RayCast is actually hitting
			var collider = _rayCastRight.GetCollider();

			// Only flip if the thing we hit is NOT the Player
			if (collider is not Player) 
			{
				GD.Print("Hit a Wall! Turning...");
				_direction = -1;
				_animatedSprite.FlipH = true;
			}
			// _direction = -1;
			// if (_animatedSprite != null) _animatedSprite.FlipH = true;
		}

		if (_rayCastLeft != null && _rayCastLeft.IsColliding())
		{
			// Get the object the RayCast is actually hitting
			var collider = _rayCastLeft.GetCollider();

			// Only flip if the thing we hit is NOT the Player
			if (collider is not Player) 
			{
				GD.Print("Hit a Wall! Turning...");
				_direction = 1;
				_animatedSprite.FlipH = false;
			}
			// _direction = 1;
			// if (_animatedSprite != null) _animatedSprite.FlipH = false;
		}

		// Translate(new Vector2(_direction * _speed * (float)delta, 0));
		// We cast delta to float because Position.X is a float
		Vector2 currentPos = Position;
		currentPos.X += _direction * _speed * (float)delta;
		Position = currentPos;
	}

}
// using Godot;
// using System;

// public partial class Slime : CharacterBody2D // Make sure this matches your Node type!
// {
// 	[Export] private RayCast2D _rayCastRight;
// 	[Export] private RayCast2D _rayCastLeft;
// 	[Export] private AnimatedSprite2D _animatedSprite;
// 	[Export] private float _speed = 60.0f;

// 	private int _direction = -1;

// 	public override void _PhysicsProcess(double delta)
// 	{
// 		// 1. Get current velocity
// 		Vector2 velocity = Velocity;

// 		// _rayCastRight.ForceRaycastUpdate();
// 		// _rayCastLeft.ForceRaycastUpdate();
// 		if (_direction == 1 && _rayCastRight != null && _rayCastRight.IsColliding())
// 		{
// 			GD.Print("Hit Right Wall! Turning Left..."); // Add this
// 			_direction = -1;
// 			if (_animatedSprite != null) _animatedSprite.FlipH = true;
// 		}
// 		else if (_direction == -1 && _rayCastLeft != null && _rayCastLeft.IsColliding())
// 		{
// 			GD.Print("Hit Left Wall! Turning Right..."); // Add this
// 			_direction = 1;
// 			if (_animatedSprite != null) _animatedSprite.FlipH = false;
// 		}

// 		// 3. Apply horizontal movement to Velocity
// 		velocity.X = _direction * _speed;

// 		// 4. Update the internal Velocity property
// 		Velocity = velocity;

// 		// 5. This is the magic part that makes it stop at walls!
// 		MoveAndSlide();
// 	}
// }
