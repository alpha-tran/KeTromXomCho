using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.Gameplay
{
    public class Trap : MonoBehaviour, IInteractable
    {
        [SerializeField] private int _minusPoint;

        public int MinusPoint { get => _minusPoint; }

        public void DoInteract(object target)
        {
            this.Broadcast(Enums.EventID.PlayerLoseMoney, this);
            this.Broadcast(Enums.EventID.PlayerHitTrap, this);
            // add some behavior
        }
    }
}

