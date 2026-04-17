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
			KillTimer.Start();
		}	
	}
	
	public void _on_timer_timeout()
	{
		GD.Print("Timer finished! Attempting reload...");
		GetTree().ReloadCurrentScene();
	}
}
