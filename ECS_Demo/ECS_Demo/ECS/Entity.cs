using System.Collections.Generic;
using System.Linq;

namespace ECS_Demo.ECS
{
    public class Entity
    {
        public string entityName;
        public string entityTag;
        public int entityID;
        public bool isActive;

        private List<Component> components = new List<Component>();


        public Entity(string _name, string _tag)
        {
            entityName = _name;
            entityTag = _tag;
            isActive = true;

            Entity_Manager.Instance.AddEntity(this);//---tell the entity_manager that a new entity is being created
        }

        public void AddComponent(Component _comp)
        {
            components.Add(_comp);//--adds to the list of components -> TODO: only allow 1 component type per entity
            Entity_Manager.Instance.ComponentAdded(this, _comp);//--tell the entity_manager a new component is being added
            _comp.entityID = this.entityID;//--setting the id for this particular component = to this particular entity
        }

        public void RemoveComponent(Component _comp)
        {
            components.Remove(_comp);//--TODO: check that this entity has this particular component before trying to remove it 
            Entity_Manager.Instance.ComponentRemoved(this, _comp);//--tell entity_manager a component is being removed
        }

        //--------------Generics = Magic--------------//
        public T GetComponent<T>() where T: Component
        {
            var comp = components.FirstOrDefault(c => c.GetType() == typeof(T));//--searches the components for a type = to the type that was passed in

            if(comp != null)
            {
                return (T)comp;//--casts the component to the type that was passed in (T)
            }

            return null;//--returns null if you dont have the correct type on this entity
        }

        public void Destroy()
        {
            Entity_Manager.Instance.RemoveEntity(this);//--tells the entity_manager this entity is wanting to be destroyed
        }


        public List<Component> GetComponents()
        {
            return components;
        }

    }
}
