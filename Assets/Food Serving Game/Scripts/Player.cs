using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LegoInterview
{

    public class Player : MonoBehaviour
    {
        static public Player mainPlayer;
        [Header("Movement")]
        public float movementSpeed = 10f;
        public Transform baseOfMotion;

        [Header("Inventory")]
        public InventoryItem carry;
        public SpriteRenderer carryBubble;
        public Sprite emptyBubble;

        private void Awake()
        {
            mainPlayer = this;
        }
        public void CarryNewItem(InventoryItem newCarry) {
            carry = newCarry;
            if (carry == null)
            {
                carryBubble.sprite = emptyBubble;
                return;
            }
            carryBubble.sprite = carry.icon;
        }

        public void MoveInDirection(Vector3 movement)
        {
            if (movement == Vector3.zero) return;

            float singleStep = movementSpeed * Time.deltaTime;
            Vector3 newDirection = Vector3.RotateTowards(transform.forward, movement, singleStep, 0.0f);

            // Rotate to face new direction
            transform.rotation = Quaternion.LookRotation(newDirection);

            // Raycast to check for bumping into things
            RaycastHit hit;
            int layerMask = 1 << 9;
            layerMask = ~layerMask;
            float scanDistance = 3f;
            if (Physics.Raycast(baseOfMotion.position, newDirection, out hit, scanDistance, layerMask))
            {
                Debug.DrawRay(baseOfMotion.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            }
            else
            {
                Debug.DrawRay(baseOfMotion.position, transform.TransformDirection(Vector3.forward) * scanDistance, Color.white);
                transform.position += movement * Time.deltaTime * movementSpeed;
            }

        }

    }
}