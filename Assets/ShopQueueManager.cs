using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopQueueManager : MonoBehaviour
{
    public List<Transform> queuePoints;

    void SpawnNewCustomer() { 
        
    }

    // Update is called once per frame
    void OnGUI()
    {
        if (GUILayout.Button("Spawn new customer")) SpawnNewCustomer();
    }
}
