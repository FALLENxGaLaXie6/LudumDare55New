using Godot;

public partial class PlayerStateHandler : Node
{
    [Export] private PlayerAnimation _playerAnimation;
    public static PlayerState PlayerState = PlayerState.Idle;
    
    public void HandlePlayerStateChange(PlayerState state)
    {
        PlayerState = state;

        if (PlayerState == PlayerState.Idle)
        {
            _playerAnimation.PlayAnimation(Constants.Animation.Idle);
        }
        else if (PlayerState == PlayerState.Move)
        {
            _playerAnimation.PlayAnimation(Constants.Animation.Move);
        }
        else if (PlayerState == PlayerState.Jump)
        {
            _playerAnimation.PlayAnimation(Constants.Animation.Jump);
        }
    }
}

public enum PlayerState
{
    Idle,
    Move,
    Jump		
}