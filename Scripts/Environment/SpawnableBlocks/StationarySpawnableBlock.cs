

using Godot;

public partial class StationarySpawnableBlock : SpawnableBlockBase
{
    [Export] public RigidBody2D RigidBody2D { get; private set; }
}