using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    
    public Action OnGrounded;

    // private void OnCollisionEnter(Collision collision)
    // {
    //     if (collision.gameObject.CompareTag("Ground"))
    //     {
    //         Debug.Log("Grounded");
    //         OnGrounded?.Invoke();
    //     }
    // }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ground"))
        {
            // Debug.Log("Grounded");
            OnGrounded?.Invoke();
        }
        
    }

}
