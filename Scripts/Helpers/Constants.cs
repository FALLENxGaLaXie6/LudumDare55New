using Godot;

public class Constants
{
    public static class Animation
    {
        public static readonly StringName Idle = new ("Idle");
        public static readonly StringName Move = new ("Move");
    }
    
    public static class Input
    {
        public static readonly StringName MoveLeft = new ("MoveLeft");
        public static readonly StringName MoveRight = new ("MoveRight");
        public static readonly StringName Jump = new ("Jump");
    }
}