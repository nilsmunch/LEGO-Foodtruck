using LegoInterview;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LegoInterview
{
    public class ShopQueueManager : MonoBehaviour
    {
        public List<Transform> queuePoints;
        public GameObject customer;
        public Transform startingPoint;

        void SpawnNewCustomer()
        {
            GameObject newCustomer = Instantiate(customer);
            newCustomer.transform.position = startingPoint.position;
            Customer customerObj = newCustomer.GetComponent<Customer>();
            customerObj.SetDestinationPoint(queuePoints[0].position);
            customerObj.spawnedAt = startingPoint.position;
        }

        // Update is called once per frame
        void OnGUI()
        {
            if (GUILayout.Button("Spawn new customer")) SpawnNewCustomer();
        }
    }

}