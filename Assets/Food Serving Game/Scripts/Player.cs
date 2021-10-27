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
        
        public bool CarriesItem(InventoryItem checkCarry)
        {
            // Checks if the input matches the item currently carried.
            return (carry == checkCarry);
        }
        
        public bool HandsFree()
        {
            // Checks if the player has their hands free
            return (carry == null);
        }

        public void CarryNewItem(InventoryItem newCarry) {
            // Places a new item in the players hand.
            carry = newCarry;
            if (carry == null)
            {
                carryBubble.sprite = emptyBubble;
                return;
            }
            carryBubble.sprite = carry.icon;
        }
        
        public void ClearCarriedItem() {
            // Remove the item from the players hand.
            carry = null;
            carryBubble.sprite = emptyBubble;
        }

        public void MoveInDirection(Vector3 movement)
        {
            // Moves the player in a desired direction.
            if (movement == Vector3.zero) return;

            float singleStep = movementSpeed * Time.deltaTime;
            Vector3 newDirection = Vector3.RotateTowards(transform.forward, movement, singleStep, 0.0f);

            // Rotate to face new direction
            transform.rotation = Quaternion.LookRotation(newDirection);

            // Raycast to check for bumping into things, ray drawn for transparency.
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