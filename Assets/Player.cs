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
            transform.position += movement * Time.deltaTime * movementSpeed;

            float singleStep = movementSpeed * Time.deltaTime;
            Vector3 newDirection = Vector3.RotateTowards(transform.forward, movement, singleStep, 0.0f);
            Debug.DrawRay(transform.position, newDirection, Color.red);
            transform.rotation = Quaternion.LookRotation(newDirection);
        }

    }
}