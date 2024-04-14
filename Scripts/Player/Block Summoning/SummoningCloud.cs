using Godot;
using System;

public partial class SummoningCloud : Node
{
	[Export] private Sprite2D _summoningCloudSprite;
	[Export] private PlayerAnimation _playerAnimation;

	public static bool SummoningCloudActive { get; set; } = false;

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
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

	public void ActivateSummoningCloud(bool activate = true)
	{
		if (activate)
		{
			_summoningCloudSprite.Visible = true;
		}
		else
		{
			_summoningCloudSprite.Visible = false;
		}
	}
}
