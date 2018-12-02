using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{
    public bool fallIn;
    public bool IsFallIn {
        get{
            return fallIn;
        }
    }


    /// <summary>
    /// Tags to Activate
    /// </summary>
    public string activeTag;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == activeTag)
        {
            this.fallIn = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == activeTag) {
            this.fallIn = false;
        }
    }



    private void OnTriggerStay(Collider other)
    {
        Rigidbody r = other.gameObject.GetComponent<Rigidbody>();

        Vector3 direction = this.transform.position - other.gameObject.transform.position;
        direction.Normalize();

        if (other.gameObject.tag == activeTag)
        {
            r.velocity *= 0.9f;
            r.AddForce(direction * r.mass * 20.0f);
        }
        else
        {
            r.AddForce(-direction * r.mass * 80.0f);
        }
    }
}
