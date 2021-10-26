﻿using UnityEngine;
using UnityEngine.AI;

namespace LegoInterview
{
    public class Customer : WorldInteractable
    {
        [Header("Item trade")]
        public InventoryItem demanding;
        public Sprite actionIcon;
        public SpriteRenderer demandBubble;
        public bool satisfied;

        [Header("Movement")]
        NavMeshAgent navAgent;
        public Vector3 spawnedAt;

        private void Awake()
        {
            demandBubble.sprite = demanding.icon;
            navAgent = GetComponent<NavMeshAgent>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.layer != 9) return;
            InteractionManager.focusInteractable(this);
        }

        public void SetDestinationPoint(Vector3 destination) {
            navAgent.SetDestination(destination);
        }

        public void LeaveShop() {
            demandBubble.enabled = false;
            demanding = null;
            SetDestinationPoint(spawnedAt);
        }

        public override void Interact()
        {
            if (Player.mainPlayer.carry == demanding)
            {
                Player.mainPlayer.CarryNewItem(null);
                LeaveShop();
                satisfied = true;
            }
        }

        public override Sprite InteractionIcon()
        {
            return actionIcon;
        }
    }
}
