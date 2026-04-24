using Godot;
using System;


public partial class Killzone : Area2D
{
	[Export] public Timer KillTimer;
	[Export] public AudioStreamPlayer2D KilledSound;
	
	public void _on_body_entered(Node2D body)
	{

		// Automatically find a child named "Timer" if one isn't assigned
		if (KillTimer == null)
		{
			KillTimer = GetNode<Timer>("Timer");
		}

		if (body is Player)
		{
			GD.Print("[Killzone] Player entered, slow-motion + disable collision, timer start");
			Engine.TimeScale = 0.5f;
			body.GetNode<CollisionShape2D>("CollisionShape2D").QueueFree();
			KillTimer.Start();
			KilledSound?.Play();
		}
	}
	
	public void _on_timer_timeout()
	{	
		Engine.TimeScale = 1.0f;
		GD.Print("[Killzone] Reset timer finished, time scale restored, reloading current scene");
		GetTree().ReloadCurrentScene();
	}
}
