using System.Collections;
using System.Collections.Generic;
using Tools;
using UnityEngine;


namespace Game.Map
{
    public class MapTest : MonoBehaviour
    {
        public MapController controller;

        private void Start()
        {
            foreach(var pool in ResourceManager.Instance.pools)
            {
                pool.Prepare(5);
            }
        }
    }
}
