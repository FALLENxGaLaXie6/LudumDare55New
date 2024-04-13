using Godot;
using System;

public partial class PlayerAnimation : Node
{
	[Export] private AnimationPlayer _animationPlayer;
    [Export] private float _animationSpeed = 1f;


    public void PlayAnimation(StringName animation)
    {
	    _animationPlayer.Play(animation, _animationSpeed);
    }
}
