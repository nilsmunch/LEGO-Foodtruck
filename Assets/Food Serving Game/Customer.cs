using UnityEngine;
using UnityEngine.AI;


namespace LegoInterview
{
    public class Customer : WorldInteractable
    {
        [Header("Item trade")]
        public InventoryItem demanding;
        public Sprite actionIcon;
        public SpriteRenderer demandBubble;

        [Header("Movement")]
        NavMeshAgent navAgent;

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

        public void MoveToPoint(Vector3 destination) {
            navAgent.SetDestination(destination);
        }

        public override void Interact()
        {
            if (Player.mainPlayer.carry == demanding)
            {
                Player.mainPlayer.CarryNewItem(null);
            }
        }

        public override Sprite InteractionIcon()
        {
            return actionIcon;
        }
    }
}
