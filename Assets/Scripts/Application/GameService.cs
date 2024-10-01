using System;
using System.Collections.Generic;
using UnityEngine;

namespace Application
{
    public class GameService : MonoBehaviour
    {
        [SerializeReference, SubclassSelector] public List<IService> services = new();


        public T GetService<T>() where T : IService
        {
            foreach (var service in services)
            {
                if (service is not T a) continue;
                return a;
            }

            throw new NullReferenceException($"No service reference with type: {nameof(T)}");
        }
    }
}