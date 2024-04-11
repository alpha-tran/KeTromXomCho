using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.Gameplay
{
    public interface IInteractable
    {
        public void DoInteract(object target);
    }
}

