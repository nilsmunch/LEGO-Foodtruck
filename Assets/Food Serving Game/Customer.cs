using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace LegoInterview
{
    public class Customer : WorldInteractable
    {
        public InventoryItem demanding;
        public Sprite actionIcon;
        public SpriteRenderer demandBubble;

        private void Awake()
        {
            demandBubble.sprite = demanding.icon;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.layer != 9) return;
            InteractionManager.focusInteractable(this);
        }


        public override void Interact()
        {
            if (Player.mainPlayer.carry == demanding)
            {
                Player.mainPlayer.CarryNewItem(null);
            }
        }

        public override Sprite interactionIcon()
        {
            return actionIcon;
        }
    }
}
