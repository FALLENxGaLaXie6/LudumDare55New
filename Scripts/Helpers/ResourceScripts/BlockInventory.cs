using Godot;
using System;
using System.Collections.Generic;

[GlobalClass]
public partial class BlockInventory : Node2D
{
	//[Export] private BlockInventoryItem[] _blockInventoryItems;
	[Export] private PackedScene[] _blockInventoryItemPrefabs;
	[Export] public SpawnableBlockBase[] _blockInventorySpawnableBlocks { get; private set; }
	[Export] private Node2D _summoningCloudNode;
	[Export] private Vector2 _spacing = new Vector2(10, 0);
	[Export] public Node2D spawnPosition { get; private set; }

	public int CurrentSelectedInventoryItem { get; private set; }

	public override void _Ready()
	{
	}

	public void SelectFirstInventoryItem()
	{
		CurrentSelectedInventoryItem = 0;
		_blockInventorySpawnableBlocks[CurrentSelectedInventoryItem].StartSelectedAnimationInThoughtBubble(CurrentSelectedInventoryItem);
	}
	public void SetNewCurrentSelectedInventoryItem()
	{
		_blockInventorySpawnableBlocks[CurrentSelectedInventoryItem].StopAnimationInThoughtBubble();
		CurrentSelectedInventoryItem++;
		if (CurrentSelectedInventoryItem >= _blockInventorySpawnableBlocks.Length)
		{
			CurrentSelectedInventoryItem = 0;
		}
		_blockInventorySpawnableBlocks[CurrentSelectedInventoryItem].StartSelectedAnimationInThoughtBubble(CurrentSelectedInventoryItem);
	}

	public void SpawnCurrentSelectedInventoryItem(Vector2 position, Node2D parent, Vector2 direction, float maxMagnitude)
	{
		//Node2D instance = (Node2D)_blockInventoryItemPrefabs[CurrentSelectedInventoryItem].Instantiate();
		Node2D instance = (Node2D)_blockInventorySpawnableBlocks[CurrentSelectedInventoryItem]._blockPrefab.Instantiate();
		instance.GlobalPosition = new Vector2(position.X, position.Y);
		parent.AddChild(instance);
		RigidBody2D instanceRigidBody2D = instance as RigidBody2D;
		CharacterBody2D instanceCharacterBody2D = instance as CharacterBody2D;
		if (instanceRigidBody2D != null)
		{
			instanceRigidBody2D.LinearVelocity = new Vector2(direction.X, direction.Y);
			SpawnableBlockBase blockBase = instance as SpawnableBlockBase;

			if (blockBase != null)
			{
				blockBase.RigidBody2D.LinearVelocity = new Vector2(direction.X, direction.Y);
			}
			
		}
		else if (instanceCharacterBody2D != null)
		{
			Vector2 newDirection = Vector2Helper.CaptMagnitude(direction, maxMagnitude);
			instanceCharacterBody2D.Velocity = new Vector2(newDirection.X, newDirection.Y);
		}
		
		
	}
}
