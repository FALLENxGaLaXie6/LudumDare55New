using Godot;

public partial class EnvironmentStationaryDude : CharacterBody2D
{
	[Export] private float _thoughtBubbleAnimationSpeed = 1f;
	[Export] protected AnimationPlayer _animationPlayer;
	
	public float Gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();
	
	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;

		// Add the gravity.
		velocity.Y += Gravity * (float)delta;
		Velocity = velocity;
		MoveAndSlide();
	}
	
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
