using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.Gameplay
{
    public class Enemy : Victim
    {

        public override void DoInteract(object target)
        {
            GameObject gameObject = (target as Score).gameObject;
            if(gameObject.transform.position.x > transform.position.x)
            {
                this.Broadcast(Enums.EventID.PlayerGainMoney, this);
            }
            else
            {
                this.Broadcast(Enums.EventID.PlayerDead, this);
                this.Broadcast(Enums.EventID.PlayerHitTrap, this);

            }

            // add somebehavior
        }
    }
}

