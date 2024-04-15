using Godot;

public class Constants
{
    public static class Animation
    {
        public static readonly StringName Idle = new ("Idle");
        public static readonly StringName Walk = new ("Walk");
        public static readonly StringName Jump = new ("Jump");
        public static readonly StringName Think = new ("Think");
        public static readonly StringName TweenBlock = new ("TweenBlock");
        public static readonly StringName Run = new ("Run");
        public static readonly StringName SelectedItem = new ("SelectedItem");
        public static readonly StringName SummoningCloudWalk = new ("SummoningCloudWalk");
        public static readonly StringName SummoningCloudRun = new ("SummoningCloudRun");
        public static readonly StringName Fall = new ("Fall");
        public static readonly StringName Death = new ("Death");
    }
    
    public static class Input
    {
        public static readonly StringName MoveLeft = new ("MoveLeft");
        public static readonly StringName MoveRight = new ("MoveRight");
        public static readonly StringName Run = new ("Run");
        public static readonly StringName Jump = new ("Jump");
        public static readonly StringName PlaceBlock = new ("PlaceBlock");
        public static readonly StringName SummonCloud = new ("SummonCloud");
        public static readonly StringName RotateSelectedItem = new ("RotateSelectedItem");
    }
}