using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LegoInterview
{
    public class CivilianDestroyerZone : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.GetComponent<Customer>() != null)
            {
                if (other.gameObject.GetComponent<Customer>().satisfied) {
                    GameObject.Destroy(other.gameObject);
                }

            }

        }
    }
}