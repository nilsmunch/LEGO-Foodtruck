using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace LegoInterview
{
    public class HUDManager : MonoBehaviour
    {
        static public HUDManager manager;
        public Image interactionImage;
        void Awake()
        {
            manager = this;
            interactionImage.enabled = false;
        }

        public static void ClearInteraction()
        {
            manager.interactionImage.enabled = false;
        }

        public static void DisplayInteraction(Sprite actionSprite)
        {
            manager.interactionImage.enabled = true;
            manager.interactionImage.sprite = actionSprite;
        }

    }
}
