using Godot;
using System;

public partial class Player : CharacterBody2D
{
	// Using [Export] lets you tweak these in the Godot Inspector
	[Export] public float Speed = 130.0f;
	[Export] public float JumpVelocity = -300.0f;
	[Export] public AnimatedSprite2D PlayerVisuals;

	// Use a field so all methods can access the current velocity
	private Vector2 _velocity;

	public override void _PhysicsProcess(double delta)
	{
		// 1. Get current velocity from the built-in property
		_velocity = Velocity;

		// 2. Run our logic blocks
		ApplyGravity(delta);
		HandleJump();
		HandleMovement();

		// 3. Apply the modified velocity back and move
		Velocity = _velocity;
		MoveAndSlide();
	}

	private void ApplyGravity(double delta)
	{
		if (!IsOnFloor())
		{
			_velocity += GetGravity() * (float)delta;
		}
	}

	private void HandleJump()
	{
		if (Input.IsActionJustPressed("jump") && IsOnFloor())
		{
			_velocity.Y = JumpVelocity;
		}
	}

	private void HandleMovement()
	{
		Vector2 direction = Input.GetVector("move_left", "move_right", "ui_up", "ui_down");

		if (direction != Vector2.Zero)
		{
			_velocity.X = direction.X * Speed;
			UpdateVisuals(direction.X);
		}
		else
		{
			_velocity.X = Mathf.MoveToward(_velocity.X, 0, Speed);
		}
		
		// Call this here so it checks for Idle even when direction is 0
		UpdateVisuals(direction.X);
	}

	private void UpdateVisuals(float directionX)
	{
		if (PlayerVisuals == null)
		{
			return;
		}
		
		// 1. Handle Facing
		if (directionX != 0)
		{
			PlayerVisuals.FlipH = directionX < 0;
		}
		
		// 2. Handle Animations
		if (IsOnFloor())
		{
			if (directionX == 0)
			{
				PlayerVisuals.Play("idle");
			}
			else
			{
				PlayerVisuals.Play("run");
			}
		}
		else
		{
			// Use Capital 'P' for Play
			PlayerVisuals.Play("jump");
		}
	}
}
