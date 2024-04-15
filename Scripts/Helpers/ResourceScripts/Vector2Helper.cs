using Godot;
using System;

public class Vector2Helper
{
    public static Vector2 CaptMagnitude(Vector2 vector, float maxMagnitude)
    {
        if (vector.LengthSquared() > maxMagnitude * maxMagnitude)
        {
            vector = vector.Normalized();
            vector *= maxMagnitude;
        }
        return vector;
    }
}