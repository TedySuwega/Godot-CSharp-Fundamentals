using Godot;
using System;


public partial class Killzone : Area2D
{
	[Export] public Timer KillTimer;
	
	public void _on_body_entered(Node2D body)
	{
		if (body is Player)
		{
			GD.Print("Dead!!");
			Engine.TimeScale = 	0.5f;
			body.GetNode<CollisionShape2D>("CollisionShape2D").QueueFree();
			KillTimer.Start();
		}	
	}
	
	public void _on_timer_timeout()
	{	
		Engine.TimeScale = 1.0f;
		GD.Print("Timer finished! Attempting reload...");
		GetTree().ReloadCurrentScene();
	}
}
