using EasyMaintain.DataAccess;
using EasyMaintain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyMaintain.Business
{
   public class ComponentsLogic
    {

      

        public ComponentsLogic()
        {

        }
        Component mComponent = new Component();
        /// <summary>
        /// Get data
        /// </summary>
        /// <returns></returns>
        public object GetData()
        {
            List<Component> result = new List<Component>();
            DataProvidor dp = new DataProvidor();

            foreach (DTO.Component component in dp.GetComponentData())
            {
                Component _component = new Component();
                _component.ComponentID = component.ComponentID;
                _component.Category = component.Category;
                _component.ComponentName = component.ComponentName;
                _component.Manufacturer = component.Manufacturer;
                _component.Description = component.Description;
                _component.ImagePath = component.ImagePath;
                _component.AdditionalData = component.AdditionalData;
               

                result.Add(_component);
            }

            return result;
        }


        /// <summary>
        /// Add new record
        /// </summary>
        /// <param name="component"></param>
        /// <returns></returns>

        public int Insert(object component)
        {
            this.mComponent = component as Component;
            DataProvidor dp = new DataProvidor();
            return dp.AddComponent(mComponent.ComponentID,mComponent.Category,mComponent.ComponentName,mComponent.Manufacturer,mComponent.Description,mComponent.ImagePath,mComponent.AdditionalData);

        }

        /// <summary>
        /// Delete one record
        /// </summary>
        /// <param name="component"></param>
        public void DeleteOne(object component)
        {
            this.mComponent = component as Component;

            DataProvidor dp = new DataProvidor();
            dp.DeleteComponent(mComponent.ComponentID);
        }
        /// <summary>
        /// Update one record
        /// </summary>
        /// <param name="component"></param>
        /// <returns></returns>
        public bool UpdateOne(object component)
        {
            this.mComponent = component as Component;
            DataProvidor dp = new DataProvidor();
            return dp.UpdateComponent(mComponent.ComponentID, mComponent.Category, mComponent.ComponentName, mComponent.Manufacturer, mComponent.Description, mComponent.ImagePath, mComponent.AdditionalData);
        }

        public Component Find(object componentID)
        {
            List<Component> result = new List<Component>();
            return result
                .Where(e => e.ComponentID.Equals(componentID))
                .SingleOrDefault();
        }

    }
}
