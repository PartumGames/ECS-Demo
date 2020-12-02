using ECS_Demo.ECS.Components;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Linq;

namespace ECS_Demo.ECS.Systems
{
    public class Drawing_System
    {
        //--all of the components this system needs to do work on (ie: draw)
        private Dictionary<Renderer, Transform> components = new Dictionary<Renderer, Transform>();

        private List<Renderer> toRemove = new List<Renderer>();//--temp list of all the components that need to be removed

        public Drawing_System()
        {
            //--Subscribe to all the Entity_Managers events this system will need
            Entity_Manager.Instance.OnComponentAdded += Instance_OnComponentAdded;
            Entity_Manager.Instance.OnComponentRemoved += Instance_OnComponentRemoved;
            Entity_Manager.Instance.OnEntityRemoved += Instance_OnEntityRemoved;
        }

        private void Instance_OnEntityRemoved(Entity obj)
        {
            var comp = components.FirstOrDefault(c => c.Key.entityID == obj.entityID);//--checks if any of the components has an id = to the entity thats getting removed id

            if(comp.Key != null)
            {
                toRemove.Add(comp.Key);//if so then add it to the toRemove list for later
            }
        }

        private void Instance_OnComponentRemoved(Entity arg1, Component arg2)
        {
            if (arg2 is Renderer)//--is this component a Renderer?
            {
                Renderer rend = (Renderer)arg2;//--cast the component to a Renderer

                if (components.ContainsKey(rend))//--is this renderer in the dictionary
                {
                    toRemove.Add(rend);//--if so add it to the toRemove list for later
                }
            }
        }

        private void Instance_OnComponentAdded(Entity arg1, Component arg2)
        {
            if(arg2 is Renderer)//--is the component a Renderer
            {
                Renderer rend = (Renderer)arg2;//--if so cast it to a Renderer

                if (!components.ContainsKey(rend))//--does the dictionary already have this particular renderer? 
                {
                    components.Add(rend, arg1.GetComponent<Transform>());//--if now then add the renderer and the transform component to the dictiionary
                }
            }
        }



        public void Draw(SpriteBatch _spritebatch)
        {
            foreach (var item in components)//--loop through the components and draw them based on their data
            {
                //item.key = renderer
                //item.value = transform

                //TODO: check if the renderer.isActive = true
                //TODO: check if the transforms.isActive = tru;
                //TODO: check if the entity they are both sitting on is active -> if all are true then draw the component

                _spritebatch.Draw(item.Key.Texture, item.Value.Position, item.Key.DrawColor);
            }

            HandleRemove();
        }

        private void HandleRemove()
        {
            foreach (var item in toRemove)//--loop through the toRemove list
            {
                components.Remove(item);//--and remove it from the dictionary
            }

            toRemove.Clear();//--then clear out the list
        }
    }
}
