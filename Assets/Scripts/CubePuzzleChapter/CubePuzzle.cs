using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using Unity.VisualScripting;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class CubePuzzle : MonoBehaviour
{
    public string ObjectType;
    public int Position;
    public float OffsetFromPosY = 0.032f;
    public bool CheckPickUp = true;
    private bool _isPickedUp = false;

    public List<GameObject> VFX;

    private Throwable _throwable;

    void Start()
    {
        _throwable = GetComponent<Throwable>();
        if (CheckPickUp)
        {
            _throwable.onPickUp.AddListener(OnPickUp);
            _throwable.onDetachFromHand.AddListener(OnDetach);
        }

        foreach(Transform vfx in gameObject.transform)
        {
            if (vfx.CompareTag("VFX"))
                VFX.Add(vfx.gameObject);
        }
    }
    public bool IsPickedUp
    {
        get { return _isPickedUp; }
    }
    public void OnPickUp()
    {
        _isPickedUp = true;
        gameObject.layer = LayerMask.NameToLayer("PickedUp");
    }
    public void OnDetach()
    {
        _isPickedUp = false;
        gameObject.layer = 0;
    }

    private void _playAnimation()
    {
        foreach (var vfx in VFX)
        {
            vfx.SetActive(true);
        }
    }
    public void StayInPosition(Vector3 position, Quaternion rotation)
    {
        //transform.position.Set(position.x, position.y, position.z * (Position + 1));
        float Offset;
        if (Position == 0)
            Offset = OffsetFromPosY;
        else
            Offset = Position * OffsetFromPosY;

        _playAnimation();

        transform.position = new Vector3(position.x, position.y + Offset, position.z);
        transform.rotation = rotation;
        _throwable.attachmentFlags = 0;
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
    }
    public void Asleep()
    {
        _throwable.attachmentFlags = 0;
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
    }
}
