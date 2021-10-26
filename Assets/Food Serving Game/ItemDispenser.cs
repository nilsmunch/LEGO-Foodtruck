using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace LegoInterview
{
    public class ItemDispenser : WorldInteractable
    {
        public InventoryItem dispensing;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.layer != 9) return;
            InteractionManager.focusInteractable(this);
        }

        public override void Interact() {
            Player.mainPlayer.CarryNewItem(dispensing);
        }

        public override Sprite InteractionIcon()
        {
            return dispensing.icon;
        }
    }
}
