using Godot;
using System;

public partial class Coin : Area2D
{
	// private CharacterBody2D _player;

	// // Called when the node enters the scene tree for the first time.
	// public override void _Ready()
	// {
	// }

	// // Called every frame. 'delta' is the elapsed time since the previous frame.
	// public override void _Process(double delta)
	// {
	// }
	
	public void _on_body_entered(Node2D body)
	{
		if (body is Player)
		{
			GD.Print("Touch the coin!!");
			QueueFree();
		}	

	}
}
