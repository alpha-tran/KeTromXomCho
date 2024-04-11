using Game.Audio;
using Game.UI;
using System.Collections;
using System.Collections.Generic;
using Tools;
using UnityEngine;


namespace Game.Gameplay
{
    public class InitializeState : State<GameManager>
    {
        public InitializeState(GameManager context) : base(context)
        {
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            if (ListenerManager.HasInstance)
            {
                AudioManager.Instance?.RegisterEventIDs();
                _context.ChangeState(Enums.StateName.MainMenu);
            }
        }
    }
}



