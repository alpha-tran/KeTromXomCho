using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.UI
{
    public class BaseScreen : BaseUIElement
    {
        public override void Hide()
        {
            base.Hide();
        }

        public override void Init()
        {
            base.Init();
            this.uiType = Enums.UIType.Screen;

            RectTransform rectTransform = GetComponent<RectTransform>();
            rectTransform.offsetMin = Vector3.zero;
            rectTransform.offsetMax = Vector3.zero;

        }

        public override void Show(object data)
        {
            base.Show(data);
        }
    }
}