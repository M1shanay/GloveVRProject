using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PirCheckCollider : MonoBehaviour
{
    private int _boxes = 0;

    public int Boxes
    {
        get { return _boxes; }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PirBlock")
        {
            _boxes++;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "PirBlock")
        {
            _boxes--;
        }
    }
}
