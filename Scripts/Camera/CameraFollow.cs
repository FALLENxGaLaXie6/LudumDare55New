using Godot;
using System;

public partial class CameraFollow : Camera2D
{
	// Player reference
	[Export] private Node2D player;

	// Camera offset from player
	private Vector2 offset = new Vector2(0, 0);

	// Speed at which the camera follows the player
	private float followSpeed = 5.0f;

	// Called when the node enters the scene tree for the first time
	public override void _Ready()
	{
		// Get reference to the player
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		// Calculate the target position for the camera
		Vector2 targetPosition = player.GlobalPosition + offset;

		// Smoothly interpolate the camera position towards the target position
		// Smoothly interpolate the camera position towards the target position
		Position = new Vector2(
			Mathf.Lerp(Position.X, targetPosition.X, followSpeed * (float)delta),
			Mathf.Lerp(Position.Y, targetPosition.Y, followSpeed * (float)delta)
		);
	}
}
