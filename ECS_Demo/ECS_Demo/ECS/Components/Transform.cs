using Microsoft.Xna.Framework;

namespace ECS_Demo.ECS.Components
{
    public class Transform : Component
    {
        public Vector2 Position;
        public Vector2 Scale;
        public float Rotation;

        //scale and rotation dont really need to be in this component
        //I just dont see the reason to create a "Scale_Component" , "Rotation_Component" and the associated systems

        public Transform(Vector2 position)
        {
            Position = position;
            Scale = Vector2.One;
            Rotation = 0f;
        }
    }
}
