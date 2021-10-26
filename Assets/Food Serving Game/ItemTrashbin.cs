using LegoInterview;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace LegoInterview
{
    public class ItemTrashBin : WorldInteractable
    {
        public InventoryItem dispensing;
        public Sprite trashIcon;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.layer != 9) return;
            InteractionManager.focusInteractable(this);
        }

        public override void Interact()
        {
            Player.mainPlayer.CarryNewItem(null);
        }

        public override Sprite InteractionIcon()
        {
            return trashIcon;
        }
    }
}
