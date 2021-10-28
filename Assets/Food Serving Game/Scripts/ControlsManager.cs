using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LegoInterview
{
    public class ControlsManager : MonoBehaviour
    {
        public Player controlledPlayer;
        void Update()
        {
            if (!GameLoopManager.InCoreLoop()) return;
            Vector3 movement = new Vector3(0, 0, 0);
            if (Input.GetKey(KeyCode.W))
            {
                movement += new Vector3(0, 0, 1);
            }
            if (Input.GetKey(KeyCode.S))
            {
                movement += new Vector3(0, 0, -1);
            }
            if (Input.GetKey(KeyCode.A))
            {
                movement += new Vector3(-1, 0, 0);
            }
            if (Input.GetKey(KeyCode.D))
            {
                movement += new Vector3(1, 0, 0);
            }

            if (Input.GetKeyDown(KeyCode.Space)) {
                InteractionManager.InteractWithActiveObject();
            }

            controlledPlayer.MoveInDirection(movement);
        }
    }
}