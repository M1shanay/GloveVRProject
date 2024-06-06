using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubePuzzleCheckCollider : CheckCollider
{
    public string ObjectTypeCollision;
    public int Position;
    public bool MagnetToCenter = true;
    public bool MeshRenderDisable = false;
    public bool DisableOnEnter = true;

    private Vector3 _freezePos;
    private Quaternion _freezeRot;
    private MeshRenderer _meshRenderer;
    public List<Collider> _colliders;

    void Start()
    {
        _freezePos = transform.position;
        _freezeRot = transform.rotation;
        if (MeshRenderDisable)
        {
            _meshRenderer = GetComponent<MeshRenderer>();
        }
        if(DisableOnEnter)
        foreach (Collider collider in GetComponents<Collider>())
        {
            _colliders.Add(collider);
        }
    }

    protected override void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == EntityTag)
        {
           var _entity = other.gameObject.GetComponent<CubePuzzle>();
           if (_entity.ObjectType == ObjectTypeCollision && _entity.Position == Position && !_entity.IsPickedUp)
            {
                _ent++;
                if (MagnetToCenter)
                    _entity.StayInPosition(_freezePos, _freezeRot);
                else
                    _entity.Asleep();
                if (MeshRenderDisable)
                {
                    _meshRenderer.enabled = false;
                }
                if (DisableOnEnter)
                {
                    foreach (Collider collider in _colliders)
                        collider.enabled = false;
                }
            }
        }
    }
    protected override void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == EntityTag)
        {
            var _entity = other.gameObject.GetComponent<CubePuzzle>();
            if (_entity.ObjectType == ObjectTypeCollision && _entity.Position == Position)
            {
                _ent--;
                if (MeshRenderDisable)
                {
                    _meshRenderer.enabled = true;
                }
            }
        }
    }
}
