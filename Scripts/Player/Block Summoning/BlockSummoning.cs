using Godot;
using System;

public partial class BlockSummoning : Node2D
{
	// Prefab for the block
	[Export] public PackedScene blockPrefab;
	
	// Block size
	[Export] private Vector2 blockSize = new Vector2(16, 16);
	
	// Mouse hover preview sprite
	private Sprite2D previewSprite;
	[Export] private Texture2D previewSpriteTexture;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		// Create preview sprite
		previewSprite = new Sprite2D();
		previewSprite.Texture = previewSpriteTexture;
		previewSprite.Modulate = new Color(1, 1, 1, 0.5f); // Set opacity to 50%
		AddChild(previewSprite);
	}

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
			/*
			// Check if there's already a block at the target position
			if (GetNodeOrNull<Block>(gridPosition) == null)
			{
				// Instantiate the block prefab
				Block newBlock = (Block)blockPrefab.Instance();
				AddChild(newBlock);
                
				// Snap the block to the grid position
				newBlock.Position = gridPosition;
			}
			*/
		}
	}
}
