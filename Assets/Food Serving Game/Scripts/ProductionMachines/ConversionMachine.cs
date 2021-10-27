using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace LegoInterview
{
    public class ConversionMachine : WorldInteractable
    {
        [Header("Production In")]
        public InventoryItem demanding;
        float productionFuel = 0f;
        public float productionFuelStart = 0f;
        public float fuelToProductionRate = 1f;

        [Header("Production Out")]
        public InventoryItem dispensing;
        float productionComplete = 0f;
        public float productionStart = 0f;
        public float productionCap = 1f;
        public float productionTimeSeconds = 3f;
        bool readyForPickup;

        [Header("HUD")]
        public SpriteRenderer demandingBackshadow;
        public SpriteRenderer demandingBubble;

        public SpriteRenderer dispensingBackshadow;
        public SpriteRenderer dispensingBubble;

        private void Start()
        {
            demandingBackshadow.sprite = demanding.icon;
            dispensingBackshadow.sprite = dispensing.icon;
            demandingBubble.sprite = demanding.icon;
            dispensingBubble.sprite = dispensing.icon;

            productionFuel = productionFuelStart;
            productionComplete = productionStart;
            UpdateRadialBubbles();
        }

        internal void UpdateRadialBubbles()
        {
            demandingBubble.material.SetFloat("_Arc1", radialPercentage(productionFuel));
            dispensingBubble.material.SetFloat("_Arc1", radialPercentage(productionComplete));
        }

        public void Update()
        {
            if (!GameLoopManager.InCoreLoop()) return;
            if (readyForPickup) return;

            if (productionFuel <= 0) return;

            if (productionComplete < productionCap)
            {
                productionComplete += Time.deltaTime / productionTimeSeconds;
                productionFuel -= (Time.deltaTime / productionTimeSeconds) * fuelToProductionRate;
                UpdateRadialBubbles();
                if (productionComplete >= productionCap)
                {
                    dispensingBubble.material.SetFloat("_Arc1", 0f);
                    readyForPickup = true;
                }
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.layer != 9) return;
            InteractionManager.focusInteractable(this);
        }

        public override void Interact()
        {
            if (readyForPickup && Player.mainPlayer.HandsFree())
            {
                Player.mainPlayer.CarryNewItem(dispensing);
                readyForPickup = false;
                productionComplete = 0f;
                UpdateRadialBubbles();
                return;
            }

            if (Player.mainPlayer.CarriesItem(demanding)) {
                productionFuel = 1f;
                Player.mainPlayer.ClearCarriedItem();
                UpdateRadialBubbles();
                return;
            }
        }

        public override Sprite InteractionIcon()
        {
            return dispensing.icon;
        }
    }
}
