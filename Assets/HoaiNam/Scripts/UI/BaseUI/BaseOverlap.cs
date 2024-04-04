using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.UI
{
    public class BaseOverlap : BaseUIElement
    {
        public override void Hide()
        {
            base.Hide();
        }

        public override void Init()
        {
            base.Init();
            uiType = Enums.UIType.Overlap;
        }

        public override void Show(object data)
        {
            base.Show(data);
        }
    }
}