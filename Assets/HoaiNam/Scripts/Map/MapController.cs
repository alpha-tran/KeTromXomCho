using System;
using System.Collections;
using System.Collections.Generic;
using Tools;
using UnityEngine;
using static Unity.Burst.Intrinsics.X86.Avx;


namespace Game.Map
{
    public class MapController : MonoBehaviour
    {
        private float _mapBlockWidth = 10f;

        [SerializeField] private List<MapBlock> _mapBlocks = new List<MapBlock>();
        [SerializeField] private float _speed = 5f;
        [SerializeField] private float _leftRear = -20f;



        public float Speed {
            get => _speed;
            set
            {
                _speed = (value > 0) ? value : 1f;
            }
        }

        private void Start()
        {
            InitMap();
        }

        private void Update()
        {
            MoveBlocks();
            CheckMapSquence();
        }


        private void InitMap()
        {
            foreach (var block in _mapBlocks)
            {
                DisplayNewBlock(block);
            }
        }



        private void CheckMapSquence()
        {
            // first block out of sight -> move to last
            if (_mapBlocks[0].transform.position.x < _leftRear)
            {
                var tmp = _mapBlocks[0];
                _mapBlocks.RemoveAt(0);
                _mapBlocks.Add(tmp);
                DisplayNewBlock(tmp);
            }
        }

        private void MoveBlocks()
        {
            _mapBlocks[0].transform.position += Vector3.left * _speed * Time.deltaTime;

            for(var i = 1; i < _mapBlocks.Count; i++)
            {
                Vector3 newPos = _mapBlocks[0].transform.position;
                newPos.x += (i * _mapBlockWidth);
                _mapBlocks[i].transform.position = newPos;
            }

        }


        private void DisplayNewBlock(MapBlock block)
        {
            // simple implementation
            int randomIndex = UnityEngine.Random.Range(0, 6);
            var blockPool = ResourceManager.Instance.pools[randomIndex];
            block.DisplayMapBlock(ResourceManager.Instance.GetPool(blockPool.Name).Get(parent: block.transform));

        }
    }
}
