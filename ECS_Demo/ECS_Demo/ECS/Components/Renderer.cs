using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace ECS_Demo.ECS.Components
{
    public class Renderer : Component
    {
        public Texture2D Texture;
        public Color DrawColor;

        //public SpriteEffects Effects;
        //public float DrawOrder;

        //i would add the SpriteEffects, and DrawOrder properties to this component. I didn't for simplicities sake during the video

        public Renderer(Texture2D texture)
        {
            Texture = texture;
            DrawColor = Color.White;
        }
    }
}
