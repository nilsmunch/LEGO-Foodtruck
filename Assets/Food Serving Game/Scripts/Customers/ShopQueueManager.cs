using LegoInterview;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LegoInterview
{
    public class ShopQueueManager : MonoBehaviour
    {
        [Header("Requests")]
        public List<InventoryItem> requestTypes;
        [Header("Spawning")]
        public GameObject customer;
        public List<Transform> queuePoints;
        public Transform startingPoint;
        public float SecondsBetweenSpawns = 5f;
        public int SpawnedCap = 5;

        public void SpawnNewCustomer()
        {
            Customer[] existingCustomers = GameObject.FindObjectsOfType<Customer>();

            if (existingCustomers.Length >= SpawnedCap) return;

            GameObject newCustomer = Instantiate(customer);
            newCustomer.transform.position = startingPoint.position;
            Customer customerObj = newCustomer.GetComponent<Customer>();
            customerObj.SetDestinationPoint(queuePoints[Random.Range(0,queuePoints.Count)].position);
            customerObj.spawnedAt = startingPoint.position;
            customerObj.demanding = requestTypes[Random.Range(0, requestTypes.Count)];
        }

        // Update is called once per frame
        void OnGUI()
        {
            if (GUILayout.Button("Spawn new customer")) SpawnNewCustomer();
        }
    }

}