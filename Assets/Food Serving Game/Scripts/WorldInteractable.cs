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
            InteractionManager.clearFocus();
        }

        internal float radialPercentage(float floatPercentage) {
           float result = 360f - ((floatPercentage / 1f) * 360f);
            if (result > 360f) result = 360f;
            return result;
        }

        public virtual Sprite InteractionIcon() {
            return null;
        }

        public virtual void Interact()
        {
            throw new NotImplementedException();
        }
    }
}