using System.Collections;
using System.Collections.Generic;
using Tools;
using UnityEngine;

namespace Game.Map
{
    public class MapBlock : MonoBehaviour
    {
        private GameObject _currentBlock;
        public void DisplayMapBlock(GameObject blockObj)
        {
            if(blockObj != null)
            {
                blockObj.transform.SetParent(transform);
                blockObj.transform.localPosition = Vector3.zero;
                blockObj.transform.localRotation = Quaternion.identity;

                if(_currentBlock != null)
                {
                    _currentBlock.transform.SetParent(ResourceManager.InactiveObjects);
                    _currentBlock.SetActive(false);
                }
                _currentBlock = blockObj;
            }

        }
       
    }
}
