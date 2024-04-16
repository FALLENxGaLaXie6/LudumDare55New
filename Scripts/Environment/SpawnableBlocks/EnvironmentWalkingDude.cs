using Godot;
using System;

public partial class EnvironmentWalkingDude : CharacterBody2D
{
	[Export] protected AnimationPlayer _animationPlayer;
	public float Gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();

	[Export] private Area2D wallDetectionArea;
	[Export] private AnimatedSprite2D _sprite;
	
	private float moveSpeed = 0.5f;
	private bool movingRight = true;
	
	public override void _Ready()
	{
		wallDetectionArea.BodyEntered += WallDetectionArea_BodyEntered;
		StartAnimationInThoughtBubble();
	}

	public override void _ExitTree()
	{
		wallDetectionArea.BodyEntered -= WallDetectionArea_BodyEntered;
	}

	private void WallDetectionArea_BodyEntered(Node2D body)
	{
		GD.Print("Body entered!!!!!");
		movingRight = !movingRight;
	}

	public override void _PhysicsProcess(double delta)
	{
		// Calculate movement
		CalculateMovement();

		// Move the character
		MoveCharacter((float)delta);
		
		Vector2 velocity = Velocity;

		// Add the gravity.
		velocity.Y += Gravity * (float)delta;

		_sprite.FlipH = !movingRight;
		Velocity = velocity;
		MoveAndSlide();

		for (int i = 0; i < GetSlideCollisionCount(); i++)
		{
			GetSlideCollision(i).GetCollider();
		}
	}
	
	// Calculate movement based on direction
	private void CalculateMovement()
	{
		// Move right
		if (movingRight)
		{
			MoveLocalX(moveSpeed);
		}
		// Move left
		else
		{
			MoveLocalX(-moveSpeed);
		}
	}

	// Move the character
	private void MoveCharacter(float delta)
	{
		// Move the character

		// Check for collision and change direction if necessary
		CheckChangeDirection();
	}

	// Check if the character needs to change direction
	private void CheckChangeDirection()
	{
		if (IsOnWall())
		{
			GD.Print("Got a wall!");
			movingRight = !movingRight;
		}
	}
	
	

	public virtual void Spawn(Vector2 position)
	{
		
	}

	protected virtual void StartAnimationInThoughtBubble()
	{
		_animationPlayer.Play(Constants.Animation.Idle);
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
