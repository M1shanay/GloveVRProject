using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCollider : MonoBehaviour
{
    protected int _ent = 0;
    public string EntityTag;
    public int MaxEntities;
    public int Entities
    {
        get { return _ent; }
    }
    public bool IsActive()
    {
        if (_ent > 0)
        {
            return true;
        }
        return false;
    }
    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == EntityTag)
        {
            _ent++;
        }
    }
    protected virtual void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == EntityTag)
        {  
            _ent--;
        }
    }

}
