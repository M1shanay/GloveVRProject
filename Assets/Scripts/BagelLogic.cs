using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagelLogic : MonoBehaviour
{
    public GameObject Bagel;

    public int IdNumber;

    private BagelSlot _slot;
    private Vector3 _position;
    private Quaternion _rotation;
    private Rigidbody _rb;


    public List<BagelSlotsManager> slotsManager;

    private void Start()
    {
        _rb = Bagel.GetComponent<Rigidbody>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "BagelSlot")
        {
            _slot = other.GetComponent<BagelSlot>();
            if (!_slot.Used)
            {
                _slot.Used = true;
                _slot.UsedBy = IdNumber;
                _rb.constraints = RigidbodyConstraints.FreezeAll;
                _position = _slot.FreezeePoint.transform.position;
                _rotation = _slot.FreezeePoint.transform.rotation;
                Bagel.transform.rotation = _rotation;
                Bagel.transform.position = _position;
                slotsManager[_slot.Type].UpdateStack();
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "BagelSlot")
        {
            _slot = other.GetComponent<BagelSlot>();
            if(_slot.UsedBy == IdNumber)
            {
                Debug.Log("asdads");
                _slot.Used = false;
                _rb.constraints = RigidbodyConstraints.None;
                slotsManager[_slot.Type].PopStack();
            }
        }
    }
}
