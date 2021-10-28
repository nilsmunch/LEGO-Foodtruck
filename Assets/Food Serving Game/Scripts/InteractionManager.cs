using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LegoInterview
{
    public class InteractionManager : MonoBehaviour
    {
        static WorldInteractable _interactableFocused;

        public static void FocusInteractable(WorldInteractable interactable) {
            _interactableFocused = interactable;
            HUDManager.DisplayInteraction(interactable.InteractionIcon());
        }

        public static void InteractWithActiveObject() {
            if (_interactableFocused == null) return;
            _interactableFocused.Interact(); 
        }

        public static void ClearFocus()
        {
            _interactableFocused = null;
            HUDManager.ClearInteraction();
        }
    }

}