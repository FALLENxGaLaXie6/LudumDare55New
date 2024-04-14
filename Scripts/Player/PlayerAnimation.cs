using Godot;
using System;

public partial class PlayerAnimation : Node
{
	[Export] public AnimationPlayer _animationPlayer { get; private set; }
	[Export] private float _idleAnimationSpeed = 1f;
	[Export] private float _walkAnimationSpeed = 2f;
	[Export] private float _jumpAnimationSpeed = 1f;


	public void PlayAnimation(StringName animation, float speed = 1f) => _animationPlayer.Play(animation, -1D, speed);
}
