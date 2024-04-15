using Godot;
using System;

public partial class PlayerMovement : CharacterBody2D
{
	[Export] private PlayerAnimation _playerAnimation;
	[Export] private AnimatedSprite2D _animatedSprite2D;
	[Export] private SummoningCloud _summoningCloud;
	[Export] private Node2D _summoningCloudNode;
	[Export] private float _walkSpeed = 5f;
	[Export] private float _runSpeed = 10f;
	[Export] private float _jumpPower = 120f;

	[Export] private float _jumpHeight = 100f;
	[Export] private float _jumpTimeToPeek = 0.5f;
	[Export] private float _jumpTimeToDescent = 0.4f;

	//[Export] public Node2D[] BlockSpawnLocations { get; private set; }
	public Vector2[] BlockSpawnLocations {get; private set;}
	[Export] private float magicBlockLocationNumber = 24f;
	
	[Export] public BlockInventory _blockInventory;
	
	float JumpVelocity => ((2f * _jumpHeight) / _jumpTimeToPeek) * -1f;
	float jumpGravity => ((-2f * _jumpHeight) / (_jumpTimeToPeek * _jumpTimeToPeek)) * -1f;
	float fallGravity => ((-2f * _jumpHeight) / (_jumpTimeToDescent * _jumpTimeToDescent)) * -1f;

	public override void _Ready()
	{
		base._Ready();
		BlockSpawnLocations = new Vector2[8];
		//Up
		BlockSpawnLocations[0] = new Vector2(0, -magicBlockLocationNumber);
		//Right
		BlockSpawnLocations[1] = new Vector2(magicBlockLocationNumber, 0);
		//Down
		BlockSpawnLocations[2] = new Vector2(0, magicBlockLocationNumber);
		//Left
		BlockSpawnLocations[3] = new Vector2(-magicBlockLocationNumber, 0);
		//Up Right
		BlockSpawnLocations[4] = new Vector2(magicBlockLocationNumber, -magicBlockLocationNumber);
		//Down Right
		BlockSpawnLocations[5] = new Vector2(magicBlockLocationNumber, magicBlockLocationNumber);
		//Down Left
		BlockSpawnLocations[6] = new Vector2(-magicBlockLocationNumber, magicBlockLocationNumber);
		//Up Left
		BlockSpawnLocations[7] = new Vector2(-magicBlockLocationNumber, -magicBlockLocationNumber);
	}

	public override void _PhysicsProcess(double delta)
	{
		Vector2 newVeclocity = new Vector2(Velocity.X, Velocity.Y);

		newVeclocity.Y += GetGravity() * (float)delta;

		if (Input.IsActionPressed(Constants.Input.Run))
			newVeclocity.X = GetInputVelocity() * _runSpeed;
		else 
			newVeclocity.X = GetInputVelocity() * _walkSpeed;
		

		float horizontalDirection = HandleSpriteFlip();
		Velocity = new Vector2(newVeclocity.X, newVeclocity.Y);
		HandleJump();
		MoveAndSlide();
		
		UpdateAnimations(horizontalDirection);
	}

	private void HandleJump()
	{
		if (Input.IsActionJustPressed(Constants.Input.Jump) && IsOnFloor())
			Jump();
	}

	private float HandleSpriteFlip()
	{
		float horizontalDirection = Input.GetAxis(Constants.Input.MoveLeft, Constants.Input.MoveRight);
		if (horizontalDirection != 0) _animatedSprite2D.FlipH = (horizontalDirection < 0);
		return horizontalDirection;
	}

	private float GetInputVelocity()
	{
		float horizontal = 0f;
		if (Input.IsActionPressed(Constants.Input.MoveLeft)) horizontal -= 1;
		if (Input.IsActionPressed(Constants.Input.MoveRight)) horizontal += 1;
		
		return horizontal;
	}
	
	private float GetGravity()
	{
		if (Velocity.Y < 0)
			return jumpGravity;
		return fallGravity;
	}

	private void Jump() => Velocity = new Vector2(Velocity.X, JumpVelocity);

	private void UpdateAnimations(float horizontalDirection)
	{
		if (IsOnFloor())
		{
			if (horizontalDirection == 0 && !SummoningCloud.SummoningCloudActive) _playerAnimation.PlayAnimation(Constants.Animation.Idle);
			else if (!SummoningCloud.SummoningCloudActive)
			{
				HandleMovementAnimations();
			}

			if (horizontalDirection != 0 && SummoningCloud.SummoningCloudActive)
			{
				SummoningCloud.SummoningCloudActive = false;
				HandleMovementAnimations();
				_summoningCloud.ActivateSummoningCloud(false);
			}
		}
		else
		{
			if (Velocity.Y < 0)
			{
				_playerAnimation.PlayAnimation(Constants.Animation.Jump);
			}
			else
			{
				//TODO: replace with fall animation
				_playerAnimation.PlayAnimation(Constants.Animation.Jump);
			}
			_summoningCloud.ActivateSummoningCloud(false);
		}
	}

	private void HandleMovementAnimations()
	{
		if (Input.IsActionPressed(Constants.Input.Run))
			_playerAnimation.PlayAnimation(Constants.Animation.Run, 2f);
		else
			_playerAnimation.PlayAnimation(Constants.Animation.Walk);
	}

	public void ReassignBubbleParent(Node2D nodeParent) => _summoningCloudNode.Reparent(nodeParent);
}
