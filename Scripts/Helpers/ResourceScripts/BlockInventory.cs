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

	public void SpawnCurrentSelectedInventoryItem(Vector2 position, Node2D parent)
	{
		Node2D instance = (Node2D)_blockInventoryItemPrefabs[CurrentSelectedInventoryItem].Instantiate();
		instance.GlobalPosition = new Vector2(position.X, position.Y);
		parent.AddChild(instance);
	}
}
