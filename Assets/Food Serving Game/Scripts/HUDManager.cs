using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace LegoInterview
{
    public class HUDManager : MonoBehaviour
    {
        static HUDManager _manager;
        public Image interactionImage;
        void Awake()
        {
            _manager = this;
            interactionImage.enabled = false;
        }

        public static void ClearInteraction()
        {
            _manager.interactionImage.enabled = false;
        }

        public static void DisplayInteraction(Sprite actionSprite)
        {
            _manager.interactionImage.enabled = true;
            _manager.interactionImage.sprite = actionSprite;
        }

    }
}
