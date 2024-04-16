using Godot;
using System;
using GTweens.Easings;
using GTweens.Extensions;
using GTweens.Tweens;
using GTweensGodot.Extensions;

public partial class BlockSummoning : Node2D
{
	// Block size
	[Export] private Vector2 blockSize = new Vector2(16, 16);
	
	// Mouse hover preview sprite
	[Export] private Sprite2D previewSprite;
	[Export] private float _previewSpriteScaleAnimationSpeed = 2f;
	
	[Export] AnimationPlayer _animationPlayer;
	[Export] PlayerMovement _playerMovement;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		SetPreviewSpriteAlpha(0.2f);
		_animationPlayer.Play(Constants.Animation.TweenBlock, -1D, _previewSpriteScaleAnimationSpeed);
		SlingShotController.SpawnBlockWithForceDirection += SpawnBlockWithForceDirection;
	}


	public override void _ExitTree()
	{
		SlingShotController.SpawnBlockWithForceDirection -= SpawnBlockWithForceDirection;
	}

	private void SetPreviewSpriteAlpha(float alpha) => previewSprite.Modulate = new Color(1, 1, 1, alpha);

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		// Get mouse position in grid coordinates
		Vector2 mousePosition = GetGlobalMousePosition();

		
		//Vector2 closestBlockSpawnLocation = GetClosestBlockSpawnLocation(mousePosition);
		Vector2 gridPosition = new Vector2(
			Mathf.FloorToInt(mousePosition.X / blockSize.X) * blockSize.X,
			Mathf.FloorToInt(mousePosition.Y / blockSize.Y) * blockSize.Y
		);
		

		// Update preview sprite position
		previewSprite.Position = gridPosition;
		previewSprite.Texture = _playerMovement._blockInventory
			._blockInventorySpawnableBlocks[_playerMovement._blockInventory.CurrentSelectedInventoryItem]._blockTexture;
		previewSprite.Visible = SummoningCloud.SummoningCloudActive;
		// Check if the player wants to place a block
		
		/*
		if (Input.IsActionJustPressed(Constants.Input.PlaceBlock) && SummoningCloud.SummoningCloudActive)
		{
			_playerMovement._blockInventory.SpawnCurrentSelectedInventoryItem(gridPosition, this);
		}
		*/
	}
	
	private void SpawnBlockWithForceDirection(Vector2 direction, float maxMagnitude)
	{
		_playerMovement._blockInventory.SpawnCurrentSelectedInventoryItem(_playerMovement._blockInventory.spawnPosition.GlobalPosition, this, direction, maxMagnitude);
	}


	private Vector2 GetClosestBlockSpawnLocation(Vector2 mousePosition)
	{
		Vector2 closestBlockSpawnLocation = new Vector2(_playerMovement.BlockSpawnLocations[0].X + _playerMovement.GlobalPosition.X, _playerMovement.BlockSpawnLocations[0].Y + _playerMovement.GlobalPosition.Y);
		for (int i = 1; i < _playerMovement.BlockSpawnLocations.Length; i++)
		{
			float distanceNew = mousePosition.DistanceTo(_playerMovement.BlockSpawnLocations[i] + _playerMovement.GlobalPosition);
			
			if (distanceNew < mousePosition.DistanceTo(closestBlockSpawnLocation))
			{
				closestBlockSpawnLocation = new Vector2(_playerMovement.BlockSpawnLocations[i].X + _playerMovement.GlobalPosition.X, _playerMovement.BlockSpawnLocations[i].Y + _playerMovement.GlobalPosition.Y);
			}
		}
		return new Vector2(closestBlockSpawnLocation.X, closestBlockSpawnLocation.Y);
	}
}
