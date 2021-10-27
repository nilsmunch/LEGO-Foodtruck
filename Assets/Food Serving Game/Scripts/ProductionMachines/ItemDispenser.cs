using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace LegoInterview
{
    public class ItemDispenser : WorldInteractable
    {
        [Header("Production")]
        public InventoryItem dispensing;
        float productionComplete = 0f;
        public float productionStart = 0f;
        public float productionCap = 1f;
        public float productionTimeSeconds = 3f;
        bool readyForPickup;
        
        [Header("HUD")]
        public SpriteRenderer dispensingBackshadow;
        public SpriteRenderer dispensingBubble;

        private void Start()
        {
            dispensingBackshadow.sprite = dispensing.icon;
            dispensingBubble.sprite = dispensing.icon;

            productionComplete = productionStart;
            UpdateRadialBubbles();
        }

        internal void UpdateRadialBubbles()
        {
            dispensingBubble.material.SetFloat("_Arc1", radialPercentage(productionComplete));
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.layer != 9) return;
            InteractionManager.focusInteractable(this);
        }

        public void Update()
        {
            if (!GameLoopManager.InCoreLoop()) return;
            if (readyForPickup) return;

            if (productionComplete < productionCap) {
                productionComplete += Time.deltaTime / productionTimeSeconds;
                UpdateRadialBubbles();
                if (productionComplete >= productionCap)
                {
                    dispensingBubble.material.SetFloat("_Arc1", 0f);
                    readyForPickup = true;
                }
            }
        }

        public override void Interact() {
            if (readyForPickup && Player.mainPlayer.HandsFree())
            {
                Player.mainPlayer.CarryNewItem(dispensing);
                readyForPickup = false;
                productionComplete = 0f;
            }
        }

        public override Sprite InteractionIcon()
        {
            return dispensing.icon;
        }
    }
}
