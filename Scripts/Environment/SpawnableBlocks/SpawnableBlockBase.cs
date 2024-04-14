using Godot;
using System;

public abstract partial class SpawnableBlockBase : Node2D
{
	[Export] private float _thoughtBubbleAnimationSpeed = 1f;
	[Export] private AnimationPlayer _animationPlayer;
	[Export] private PackedScene _blockPrefab;
	
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
		_animationPlayer.Stop();
		_animationPlayer.Play(Constants.Animation.SelectedItem);
		GD.Print("Hello there animation start!");
	}

	public virtual void StopAnimationInThoughtBubble()
	{
		_animationPlayer.Stop();
	}
	protected virtual void ExistInThoughtBubble()
	{
		
	}

	public void DebugMethodAnimation()
	{
		GD.Print("Why hello there!");
	}
}
