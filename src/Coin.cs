using Godot;
using System;

public partial class Coin : Area2D
{
	[Export] public GameManager GameManager;
	[Export] public AudioStreamPlayer2D PickUpSound;
	public void _on_body_entered(Node2D body)
	{
		if (body is Player player)
		{
			GD.Print("[Coin] Collected: ", player.Name, " (Player)");
			GameManager.AddScore();

			var scene = GetTree().CurrentScene;
			if (PickUpSound != null && scene != null)
			{
				PickUpSound.Reparent(scene);
				PickUpSound.GlobalPosition = GlobalPosition;
				PickUpSound.Finished += () => PickUpSound.QueueFree();
				PickUpSound.Play();
			}

			QueueFree();
		}	

	}
}
