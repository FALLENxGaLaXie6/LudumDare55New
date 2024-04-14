using Godot;
using System;

public partial class Main : Node2D
{
    [Export] private PlayerMovement _playerMovement;
    [Export] private Node2D _masterSceneNode;

    public override void _Ready()
    {
        _playerMovement.ReassignBubbleParent(_masterSceneNode);
    }
}
