using UnityEngine;

namespace LegoInterview
{
    public class ItemTrashbin : WorldInteractable
    {
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
