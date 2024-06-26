using Godot;
using System;

public abstract partial class SpawnableBlockBase : Node2D
{
	[Export] private float _thoughtBubbleAnimationSpeed = 1f;
	[Export] protected AnimationPlayer _animationPlayer;
	[Export] public PackedScene _blockPrefab { get; private set; }
	[Export] public Texture2D _blockTexture;
	
	[Export] public RigidBody2D RigidBody2D { get; private set; }
	
	public override void _Ready()
	{
		StartAnimationInThoughtBubble();
	}

	public virtual void Spawn(Vector2 position)
	{
		
	}

	protected virtual void StartAnimationInThoughtBubble()
	{
		_animationPlayer.Play(Constants.Animation.Idle, -1D, _thoughtBubbleAnimationSpeed);
	}

	public virtual void StartSelectedAnimationInThoughtBubble(int i)
	{
		//_animationPlayer.Stop();
		_animationPlayer.Play(Constants.Animation.SelectedItem);
	}

	public virtual void StopAnimationInThoughtBubble()
	{
		_animationPlayer.Stop();
	}

	public void DebugMethodAnimation()
	{
		
	}
}
