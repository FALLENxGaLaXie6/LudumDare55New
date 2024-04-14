using Godot;
using System;
using System.Numerics;
using Vector2 = Godot.Vector2;

public partial class SummoningCloud : Node
{
	[Export] private Sprite2D _summoningCloudSprite;
	[Export] private PlayerAnimation _playerAnimation;
	[Export] private Node2D _summoningCloudNode;
	[Export] private Node2D _summoningCloudPositionLeft;
	[Export] private Node2D _summoningCloudPositionRight;
	[Export] private Vector2 _summoningCloudOffsetFromPlayer = new Vector2(21, -16);
	[Export] private float _summoningCloudSpeed = 2f;
	[Export] private AnimatedSprite2D _playerAnimatedSprite;
	[Export] private Node2D _playerNode;
	[Export] private float _summoningCloudGrowSpeed = 5f;

	public static bool SummoningCloudActive { get; set; } = false;

	public override void _Ready()
	{
		_summoningCloudPositionLeft.Position =
			new Vector2(-_summoningCloudOffsetFromPlayer.X * 5, _summoningCloudOffsetFromPlayer.Y);
		_summoningCloudPositionRight.Position =
			new Vector2(_summoningCloudOffsetFromPlayer.X, _summoningCloudOffsetFromPlayer.Y);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		
		MoveSummoningCloud(delta);
		HandleSummoningCloudVisuals();
	}

	private void HandleSummoningCloudVisuals()
	{
		if (Input.IsActionJustPressed(Constants.Input.SummonCloud))
		{
			_summoningCloudSprite.Visible = !_summoningCloudSprite.Visible;
			SummoningCloudActive = _summoningCloudSprite.Visible;
			if (_summoningCloudSprite.Visible)
			{
				_playerAnimation.PlayAnimation(Constants.Animation.Think);
			}
			else
			{
				_playerAnimation.PlayAnimation(Constants.Animation.Idle);
			}
		}
	}

	private void MoveSummoningCloud(double delta)
	{
		Vector2 targetPosition;
		if (_playerAnimatedSprite.FlipH)
		{ 
			targetPosition = new Vector2(_summoningCloudPositionLeft.Position.X + _playerNode.GlobalPosition.X, _summoningCloudPositionLeft.Position.Y + _playerNode.GlobalPosition.Y);
			_summoningCloudSprite.FlipH = true;
		}
		else
		{
			targetPosition = new Vector2(_summoningCloudPositionRight.Position.X + _playerNode.GlobalPosition.X, _summoningCloudPositionRight.Position.Y + _playerNode.GlobalPosition.Y);
			_summoningCloudSprite.FlipH = false;
		}

		Vector2 targetScale = new Vector2(1, 1);
		if (!SummoningCloudActive)
		{
			targetPosition = new Vector2(_playerNode.GlobalPosition.X, _playerNode.GlobalPosition.Y);
			targetScale = Vector2.Zero;
		}
		
		// Smoothly interpolate the camera position towards the target position
		// Smoothly interpolate the camera position towards the target position
		_summoningCloudNode.Position = new Vector2(
			Mathf.Lerp(_summoningCloudNode.GlobalPosition.X, targetPosition.X, _summoningCloudSpeed * (float)delta),
			Mathf.Lerp(_summoningCloudNode.GlobalPosition.Y, targetPosition.Y, _summoningCloudSpeed * (float)delta)
		);

		_summoningCloudNode.Scale = new Vector2(
			Mathf.Lerp(_summoningCloudNode.Scale.X, targetScale.X, _summoningCloudGrowSpeed * (float)delta),
			Mathf.Lerp(_summoningCloudNode.Scale.Y, targetScale.Y, _summoningCloudGrowSpeed * (float)delta)
		);
	}

	public void ActivateSummoningCloud(bool activate = true)
	{
		_summoningCloudSprite.Visible = activate;
		SummoningCloudActive = activate;
	}
}
