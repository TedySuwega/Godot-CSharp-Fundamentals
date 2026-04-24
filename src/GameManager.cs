using Godot;
using System;

public partial class GameManager : Node
{
	[Export] public Label ScoreLabel;
	private int _score = 0;

	public void AddScore()
	{
		_score++;
		ScoreLabel.Text = "You colected " + GetScore()+ " of 100 coins.";
		GD.Print("[GameManager] Score updated: ", GetScore(), " of 100 coins.");
	}

	public int GetScore()
	{
		return _score;
	}
	
	
}
