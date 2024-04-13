using Godot;

public partial class PlayerStateHandler : Node
{
    [Export] private PlayerAnimation _playerAnimation;
    public static PlayerState PlayerState = PlayerState.Idle;
    
    public void HandlePlayerStateChange(PlayerState newState)
    {
        //If it's transitioning to a new state, then play a new animation
        //if (PlayerState != newState)
        //{
        _playerAnimation._animationPlayer.Stop();
        if (newState == PlayerState.Idle)
        {
            //if(_playerAnimation._animationPlayer.CurrentAnimation != Constants.Animation.Idle)
            _playerAnimation.PlayAnimation(Constants.Animation.Idle);
        }
        else if (newState == PlayerState.Walk)
        {
            _playerAnimation.PlayAnimation(Constants.Animation.Walk);
        }
        else if (newState == PlayerState.Jump)
        {
            _playerAnimation.PlayAnimation(Constants.Animation.Jump);
        }
        //}
        
        PlayerState = newState;
    }
}

public enum PlayerState
{
    Idle,
    Walk,
    Jump		
}