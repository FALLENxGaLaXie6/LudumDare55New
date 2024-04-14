using Godot;
using System;
using GTweens.Easings;
using GTweens.Extensions;
using GTweens.Tweens;
using GTweensGodot.Extensions;

public partial class BlockSummoning : Node2D
{
	// Prefab for the block
	[Export] public PackedScene blockPrefab;
	
	// Block size
	[Export] private Vector2 blockSize = new Vector2(16, 16);
	
	// Mouse hover preview sprite
	[Export] private Sprite2D previewSprite;
	[Export] private float _previewSpriteScaleAnimationSpeed = 2f;
	
	[Export] AnimationPlayer _animationPlayer;

	
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		SetPreviewSpriteAlpha(0.2f);
		_animationPlayer.Play(Constants.Animation.TweenBlock, -1D, _previewSpriteScaleAnimationSpeed);
	}

	private void SetPreviewSpriteAlpha(float alpha) => previewSprite.Modulate = new Color(1, 1, 1, alpha);

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		// Get mouse position in grid coordinates
		Vector2 mousePosition = GetGlobalMousePosition();
		
		// Update preview sprite position to match mouse cursor
		
		Vector2 gridPosition = new Vector2(
			Mathf.FloorToInt(mousePosition.X / blockSize.X) * blockSize.X,
			Mathf.FloorToInt(mousePosition.Y / blockSize.Y) * blockSize.Y
		);

		// Update preview sprite position
		previewSprite.Position = gridPosition;
		
		// Check if the player wants to place a block
		if (Input.IsActionJustPressed(Constants.Input.PlaceBlock))
		{
			
		}
	}
}
