
namespace ECS_Demo.ECS
{
    public class Component
    {
        public int entityID;//---the id of the entity this component is sitting on -> setting the id is handled by the entity automatically
        public bool isActive = true;

        /// <summary>
        /// Returns the Entity this component is sitting on
        /// </summary>
        /// <returns></returns>
        public Entity GetEntity()//-----helper method added after the video
        {
            return Entity_Manager.Instance.GetEntity(this.entityID);
        }
    }
}
