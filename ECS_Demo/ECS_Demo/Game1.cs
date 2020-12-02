using ECS_Demo.ECS;
using ECS_Demo.ECS.Components;
using ECS_Demo.ECS.Systems;
using ECS_Demo.Scripts;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ECS_Demo
{

    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        private Drawing_System drawSystem;
        private Script_System scriptsSystem;


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }


        protected override void Initialize()
        {
            base.Initialize();
        }


        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            Texture2D texture = Content.Load<Texture2D>("Color");


            new Entity_Manager();
            drawSystem = new Drawing_System();
            scriptsSystem = new Script_System();


            Entity first = new Entity("First", "Default");//--create an entity and give it a name, and a tag
            first.AddComponent(new Transform(new Vector2(300, 300)));//--add a new transform component and give it a position
            first.AddComponent(new Renderer(texture));//--add a new renderer component and give it a texture
            first.AddComponent(new Mover());

            Entity second = new Entity("Second", "Default");
            second.AddComponent(new Transform(new Vector2(500, 0)));
            second.AddComponent(new Renderer(texture));


            //first.Destroy();//--this is how you "Destroy" an entity
        }


        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }


        protected override void Update(GameTime gameTime)
        {
            scriptsSystem.Update();//--------update the Scripts_System

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);



            spriteBatch.Begin();

            drawSystem.Draw(spriteBatch); //--call the drawing systems "Draw()" method

            spriteBatch.End();



            base.Draw(gameTime);
        }
    }
}
