using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineirColliderCheck : MonoBehaviour
{
    public bool Complete = false;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Enter");
        if (other.gameObject.tag == "PlayBlock")
        {
            Complete = true;
        }
    }
}
