using Godot;
using System;

public partial class PlayerMovement : CharacterBody2D
{
	[Export] private PlayerStateHandler _playerStateHandler;
	[Export] private AnimatedSprite2D _animatedSprite2D;
	[Export] private float _moveSpeed = 5f;
	[Export] private float _jumpPower = 120f;
	[Export] private float _gravity = 5f;

	
	
	/*
	private const float MoveSpeed = 200f;
	private const float JumpHeight = -500f;
	private const float Gravity = 2000f;
	private const float MaxFallSpeed = 1000f;

	private Vector2 velocity = new Vector2();
	private bool isOnGround = false;
	*/
	Vector2 _motion = Vector2.Zero;
	
	public override void _PhysicsProcess(double delta)
	{
		int direction = 0;
		if (Input.IsActionPressed(Constants.Input.MoveRight))
		{
			direction += 1;
			//Velocity = Vector2.Right;
			Flip(false);
			_playerStateHandler.HandlePlayerStateChange(PlayerState.Walk);
		}
		if (Input.IsActionPressed(Constants.Input.MoveLeft))
		{
			direction -= 1;
			//Velocity = Vector2.Left;
			Flip(true);
			_playerStateHandler.HandlePlayerStateChange(PlayerState.Walk);
		}
		if(direction == 0)
		{
			_motion.X = 0;
			_playerStateHandler.HandlePlayerStateChange(PlayerState.Idle);
		}
		else
		{
			_motion.X = direction * _moveSpeed;
		}

		if (Input.IsActionJustPressed(Constants.Input.Jump))
		{
			GD.Print("Jump!");
			_motion.Y = -_jumpPower;
			_playerStateHandler.HandlePlayerStateChange(PlayerState.Jump);
		}

		_motion.Y += _gravity;
		//Velocity *= _moveSpeed;
		
		Velocity = new Vector2(_motion.X, _motion.Y);
		MoveAndSlide();
	}

	private void Flip(bool flipH) => _animatedSprite2D.FlipH = flipH;
	
	/**

	private void ProcessInput()
	{
		velocity.x = Input.GetActionStrength("move_right") - Input.GetActionStrength("move_left");
		velocity.x *= MoveSpeed;

		if (Input.IsActionJustPressed("jump") && isOnGround)
		{
			velocity.y = JumpHeight;
			isOnGround = false;
		}
	}

	private void UpdateVelocity(float delta)
	{
		if (!isOnGround)
		{
			velocity.y += Gravity * delta;
			velocity.y = Mathf.Clamp(velocity.y, -MaxFallSpeed, Mathf.Infinity);
		}
	}

	public void _on_Player_body_entered(object body)
	{
		isOnGround = true;
	}
	**/
}
