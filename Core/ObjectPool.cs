﻿using OpenTK.Windowing.Desktop;

namespace Core
{
    public class ObjectPool <T> where T : GameObject, new()
    {
        public List<ObjectPoolItem<T>> Pool { get; set; }
        public bool IsAllObjectDisabled => IsAllDisabled();

        public ObjectPool()
        {
            Pool = new List<ObjectPoolItem<T>>();
        }

        public virtual void InitItems(int number, GameWindow window)
        {
            Pool.Clear();

            for (int i = 0; i < number; i++)
            {
                Pool.Add(new ObjectPoolItem<T>());
            }
        }

        public T GetObject()
        {
            var obj = Pool.First(obj => obj.State == ItemState.Enable).Object;

            DisableObject(obj);

            return obj;
        }

        public void EnableObject(T obj)
        {
            Pool.First(pObj => pObj.Object == obj).State = ItemState.Enable;
        }
        
        public void DisableObject(T obj)
        {
            Pool.First(pObj => pObj.Object == obj).State = ItemState.Disable;
        }

        private bool IsAllDisabled()
        {
            foreach (var el in Pool)
            {
                if (el.State == ItemState.Enable || el.State == ItemState.Rendering)
                {
                    return false;
                }
            }

            return true;
        }
    }

    public class ObjectPoolItem <T> where T : GameObject, new()
    {
        public T Object { get; set; }
        public ItemState State { get; set; }

        public ObjectPoolItem()
        {
            Object = new T();
            State = ItemState.Enable;
        }
    }

    public enum ItemState
    {
        Enable, 
        Disable,
        Rendering
    }
}
