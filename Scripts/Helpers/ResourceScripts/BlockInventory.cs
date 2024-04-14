using Godot;
using System;
using System.Collections.Generic;

[GlobalClass]
public partial class BlockInventory : Node2D
{
	//[Export] private BlockInventoryItem[] _blockInventoryItems;
	[Export] private PackedScene[] _blockInventoryItemPrefabs;
	[Export] private SpawnableBlockBase[] _blockInventorySpawnableBlocks;
	
	public int CurrentSelectedInventoryItem { get; private set; }

	public void SelectFirstInventoryItem()
	{
		CurrentSelectedInventoryItem = 0;
		_blockInventorySpawnableBlocks[CurrentSelectedInventoryItem].StartSelectedAnimationInThoughtBubble(CurrentSelectedInventoryItem);
	}
	public void SetNewCurrentSelectedInventoryItem()
	{
		_blockInventorySpawnableBlocks[CurrentSelectedInventoryItem].StopAnimationInThoughtBubble();
		CurrentSelectedInventoryItem++;
		_blockInventorySpawnableBlocks[CurrentSelectedInventoryItem].StartSelectedAnimationInThoughtBubble(CurrentSelectedInventoryItem);
	}
	/*
	public void InstantiateBlockInventoryItem(Vector2 position, BlockInventoryItem newBlockInventoryItem)
	{
		foreach (var blockInventoryItem in _blockInventoryItems)
		{
			if (blockInventoryItem == newBlockInventoryItem)
			{
				blockInventoryItem.Init(position);
			}
		}
	}
	*/
}
