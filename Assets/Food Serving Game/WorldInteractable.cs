using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace LegoInterview
{
    public class WorldInteractable : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.layer != 9) return;
            Debug.Log(other.gameObject.name);
        }
        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.layer != 9) return;
            Debug.Log("Left");
            InteractionManager.clearFocus();
        }

        public virtual Sprite interactionIcon() {
            return null;
        }

        public virtual void Interact()
        {
            throw new NotImplementedException();
        }
    }
}