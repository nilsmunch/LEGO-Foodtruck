using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace LegoInterview
{
    public class Customer : WorldInteractable
    {
        public InventoryItem demanding;
        public Sprite actionIcon;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.layer != 9) return;
            InteractionManager.focusInteractable(this);
        }

        public override Sprite interactionIcon()
        {
            return actionIcon;
        }
    }
}
