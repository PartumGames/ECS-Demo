using System;
using System.Collections.Generic;

namespace ECS_Demo.ECS
{
    public class Entity_Manager
    {
        public static Entity_Manager Instance;

        private List<Entity> entities = new List<Entity>();


        public event Action<Entity, Component> OnComponentAdded;
        public event Action<Entity, Component> OnComponentRemoved;
        public event Action<Entity> OnEntityAdded;
        public event Action<Entity> OnEntityRemoved;



        public Entity_Manager()
        {
            Instance = this;
        }


        /// <summary>
        /// Automatically called by an Entity when it is being created
        /// Sets the Entities ID, then fires off the OnEntityAdded event
        /// </summary>
        /// <param name="_ent"></param>
        public void AddEntity(Entity _ent)
        {
            if (!entities.Contains(_ent))//--is this entiity NOT in the list already?
            {
                entities.Add(_ent);//---then add it to the list
                _ent.entityID = entities.Count - 1;//--set the _ent.ID
                OnEntityAdded?.Invoke(_ent);//--fire off the OnEntityAdded event
            }
        }

        /// <summary>
        /// Automatically called by an Entity when it is being destroyed
        /// Removes it from the entities list, then fires off the OnEntityRemoved event
        /// </summary>
        /// <param name="_ent"></param>
        public void RemoveEntity(Entity _ent)
        {
            if (entities.Contains(_ent))//--does the list contain this particular entity?
            {
                entities.Remove(_ent);//--if so remove it
                Reindex();
                OnEntityRemoved?.Invoke(_ent);//--fire off the OnEntityRemoved event;
            }
        }

        /// <summary>
        /// Automatically called by the Entity when a new component is added
        /// Fires off the OnComponentAdded event
        /// </summary>
        /// <param name="_ent"></param>
        /// <param name="_comp"></param>
        public void ComponentAdded(Entity _ent, Component _comp)
        {
            OnComponentAdded?.Invoke(_ent, _comp);
        }

        /// <summary>
        /// Automatically called by the Entity when a component is removed
        /// Fires off the OnComponentRemoved event;
        /// </summary>
        /// <param name="_ent"></param>
        /// <param name="_comp"></param>
        public void ComponentRemoved(Entity _ent, Component _comp)
        {
            OnComponentRemoved?.Invoke(_ent, _comp);
        }


        private void Reindex()//--Called when an entity is removed from the list (ie: destroyed)
        {
            for (int i = 0; i < entities.Count; i++)//--loop through all the entities
            {
                entities[i].entityID = i;//--set its new id =  i

                foreach (var item in entities[i].GetComponents())//--loop through the entities components
                {
                    item.entityID = i;//--set the components new id = i
                }
            }
        }

        /// <summary>
        /// Returns and Entity based on its EntityID
        /// </summary>
        /// <param name="_id"></param>
        /// <returns></returns>
        public Entity GetEntity(int _id)//-------helper method added after the video
        {
            return entities[_id];
        }

        /// <summary>
        /// Return all Entities the Entity_Manger has
        /// </summary>
        /// <returns></returns>
        public List<Entity> GetEntities()//-----helper method added after the video
        {
            return entities;
        }
    }
}
