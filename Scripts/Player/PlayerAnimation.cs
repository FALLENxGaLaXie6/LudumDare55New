using Godot;
using System;

public partial class PlayerAnimation : Node
{
	[Export] public AnimationPlayer _animationPlayer { get; private set; }
    [Export] private float _idleAnimationSpeed = 1f;
    [Export] private float _walkAnimationSpeed = 2f;
    [Export] private float _jumpAnimationSpeed = 1f;


    public void PlayAnimation(StringName animation)
    {
	    switch (PlayerStateHandler.PlayerState)
	    {
		    case PlayerState.Idle:
			    _animationPlayer.Play(Constants.Animation.Idle, _idleAnimationSpeed);
			    break;
		    case PlayerState.Walk:
			    _animationPlayer.Play(Constants.Animation.Walk, _walkAnimationSpeed);
                break;
            case PlayerState.Jump:
	            _animationPlayer.Play(Constants.Animation.Jump, _jumpAnimationSpeed);
	            break;
	    }
    }
}
