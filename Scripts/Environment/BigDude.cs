using Godot;
using System;

public partial class BigDude : Node
{
	[Export] private AnimationPlayer _animationPlayer;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_animationPlayer.Play(Constants.Animation.Idle);
	}
}
