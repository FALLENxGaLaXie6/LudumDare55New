using Godot;
using System;

[GlobalClass]
public partial class BlockInventoryItem : Resource
{
	[Export] private PackedScene _blockInventoryItem;

	public void Init(Vector2 position)
	{
		//Control blockInventoryItemControl = (Control)_blockInventoryItem.Instance();
	}
}
