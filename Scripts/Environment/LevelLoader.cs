using Godot;
using System;

public partial class LevelLoader : Node2D
{
	[Export] private PackedScene nextPackedLevelScene;
	[Export] private Area2D portalArea2D;

	public override void _Ready()
	{
		portalArea2D.BodyEntered += LoadNextLevel;
	}

	public override void _ExitTree()
	{
		portalArea2D.BodyEntered -= LoadNextLevel;
	}

	private void LoadNextLevel(Node2D body)
	{
		LoadLevel();
	}

	// Load a new level by its scene name
	public void LoadLevel()
	{
		// Load the scene
		if (nextPackedLevelScene != null)
		{
			//var nextScene = nextPackedLevelScene.Instantiate();
			GetTree().ChangeSceneToPacked(nextPackedLevelScene);
			//GetTree().Root.AddChild(nextScene);
		}
		else
		{
			GD.Print("Failed to load scene");
		}
	}
}
