using Godot;
using System;

public partial class SlingShotController : Node2D
{
	private Vector2 startDragPosition = Vector2.Zero;
	private Vector2 endDragPosition = Vector2.Zero;
	
	//private Line2D line;

	[Export] private float flingForce = 100f;
	[Export] private float maxforce = 50f;

	public static event Action<Vector2, float> SpawnBlockWithForceDirection;
	[Export] private Line2D slingshotLine;

	public bool slingActive { get; private set; } = false;
	
	public override void _Ready()
	{
		//line = getnod
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (!SummoningCloud.SummoningCloudActive)
		{
			slingActive = false;
			return;
		}

		
		
		if (Input.IsActionJustPressed(Constants.Input.PlaceBlock))
		{
			startDragPosition = GetGlobalMousePosition();
			slingActive = true;
		}
		else if (Input.IsActionJustReleased(Constants.Input.PlaceBlock))
		{
			endDragPosition = GetGlobalMousePosition();
			Vector2 direction = (startDragPosition - endDragPosition) * flingForce;
			SpawnBlockAndApplyFlingForce(direction);
			slingActive = false;
		}
		
		if (slingActive)
		{
			slingshotLine.Visible = true;
			slingshotLine.Points[0] = new Vector2(startDragPosition.X, startDragPosition.Y);
			Vector2 newGlobalMousePosition = GetGlobalMousePosition();
			slingshotLine.Points[1] = new Vector2(newGlobalMousePosition.X, newGlobalMousePosition.Y);
		}
		else
		{
			slingshotLine.Visible = false;
		}
	}

	private void SpawnBlockAndApplyFlingForce(Vector2 direction)
	{
		SpawnBlockWithForceDirection?.Invoke(direction, maxforce);
	}

	public override void _Input(InputEvent @event)
	{
		
	}
}
