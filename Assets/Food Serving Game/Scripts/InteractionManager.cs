using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace LegoInterview
{
    public class InteractionManager : MonoBehaviour
    {
        static WorldInteractable interactableFocused;

        public static void focusInteractable(WorldInteractable interactable) {

            interactableFocused = interactable;
            HUDManager.DisplayInteraction(interactable.InteractionIcon());
        }

        public static void interactWithActiveObject() {
            if (interactableFocused == null) return;
            interactableFocused.Interact(); 
        }

        public static void clearFocus()
        {
            interactableFocused = null;
            HUDManager.ClearInteraction();
        }
    }

}