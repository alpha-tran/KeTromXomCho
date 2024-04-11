using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.Gameplay
{
    public class Victim : MonoBehaviour, IInteractable
    {
        [SerializeField] private int _score;

        public int Score { get => _score; }

        public virtual void DoInteract(object target)
        {
            this.Broadcast(Enums.EventID.PlayerGainMoney, this);
            

            // add some behavior
        }

        
    }
}

