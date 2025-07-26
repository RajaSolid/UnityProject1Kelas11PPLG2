using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Collectible : MonoBehaviour
{
    public Vector3 rotationSpeed = new Vector3(0, 100, 0);
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
    
    //Kuru-kuru
        void Update()
        {
            transform.Rotate(rotationSpeed * Time.deltaTime);
        }
}

