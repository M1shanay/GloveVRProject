using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagelSlot : MonoBehaviour
{
    private bool _used = false;
    public int UsedBy;
    public int Type;
    public GameObject FreezeePoint;
    public bool Used
    {
        get { return _used; }
        set { _used = value; }
    }
    public void Enable()
    {
        gameObject.SetActive(true);
    }
    public void Disable()
    {
        gameObject.SetActive(false);
    }
}
