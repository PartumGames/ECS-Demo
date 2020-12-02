using ECS_Demo.ECS.Components;
using System.Collections.Generic;

namespace ECS_Demo.ECS.Systems
{
    public class Script_System
    {
        private List<Script> components = new List<Script>();

        private List<Script> toRemove = new List<Script>();

        private bool hasStarted = false;


        public Script_System()
        {
            Entity_Manager.Instance.OnComponentAdded += Instance_OnComponentAdded;
            Entity_Manager.Instance.OnComponentRemoved += Instance_OnComponentRemoved;
            Entity_Manager.Instance.OnEntityRemoved += Instance_OnEntityRemoved;
        }

        private void Instance_OnEntityRemoved(Entity obj)
        {
            var comps = components.FindAll(c => c.entityID == obj.entityID);

            foreach (var item in comps)
            {
                toRemove.Add(item);
            }
        }

        private void Instance_OnComponentRemoved(Entity arg1, Component arg2)
        {
            if(arg2 is Script)
            {
                Script script = (Script)arg2;

                if (components.Contains(script))
                {
                    toRemove.Add(script);
                }
            }
        }

        private void Instance_OnComponentAdded(Entity arg1, Component arg2)
        {
            if(arg2 is Script)
            {
                Script script = (Script)arg2;
                if (!components.Contains(script))
                {
                    components.Add(script);
                }
            }
        }

        public void Update()
        {
            if (!hasStarted)
            {
                HandleStart();
            }

            foreach (var item in components)
            {
                item.Update();
            }

            HandleRemove();
        }

        private void HandleStart()
        {
            foreach (var item in components)
            {
                item.Start();
            }

            hasStarted = true;
        }

        private void HandleRemove()
        {
            foreach (var item in toRemove)
            {
                components.Remove(item);
            }

            toRemove.Clear();
        }
    }
}
