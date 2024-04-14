using Godot;
using System;
using System.Collections.Generic;

[GlobalClass]
public partial class BlockInventory : Resource
{
	[Export] private BlockInventoryItem[] _blockInventoryItems;

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
}
