﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace LegoInterview
{
    public class InteractionManager : MonoBehaviour
    {
        static WorldInteractable interactableFocused;

        public static void focusInteractable(WorldInteractable interactable) {

            interactableFocused = interactable;
            HUDManager.DisplayInteraction(interactable.interactionIcon());
        }
        public static void clearFocus()
        {
            interactableFocused = null;
            HUDManager.ClearInteraction();
        }
    }

}