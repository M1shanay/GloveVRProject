using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class BlockingBox : MonoBehaviour
{
    public Transform BlockRayXPosition;
    public Transform BlockRayRevXPosition;
    public Transform StartPosition;
    public Transform EndPosition;

    public bool Vertical;
    public bool Horizontal;

    public float Offset;


    Transform NewStartPosition;
    Transform NewEndPosition;
    LinearDrive drive;
    Ray _BlockRay;
    Ray _BlockRayRev;
    RaycastHit BlockHit;
    RaycastHit BlockHitRev;
    // Start is called before the first frame update
    void Start()
    {
        NewStartPosition = StartPosition;
        NewEndPosition = EndPosition;
        drive = GetComponent<LinearDrive>();
        drive.startPosition = NewStartPosition;
        drive.endPosition = NewEndPosition;
    }

    // Update is called once per frame
    void Update()
    {
        BlockFunction();
    }

    void BlockFunction()
    {
        if (Horizontal)
        {
            _BlockRay = new Ray(BlockRayXPosition.position, Vector3.right);
            _BlockRayRev = new Ray(BlockRayRevXPosition.position, -Vector3.right);
            if (Physics.Raycast(_BlockRayRev, out BlockHitRev, 10f))
            {
                if (Physics.Raycast(_BlockRay, out BlockHit, 10f))
                {
                    if (BlockHitRev.transform.tag == "PlayBlock")
                    {
                        NewEndPosition.transform.position = new Vector3(BlockHitRev.point.x + (0.12f + Offset), EndPosition.position.y, EndPosition.position.z);
                        drive.endPosition = NewEndPosition;
                    }
                    if (BlockHit.transform.tag == "PlayBlock")
                    {
                        NewStartPosition.transform.position = new Vector3(BlockHit.point.x - (0.12f + Offset), StartPosition.position.y, StartPosition.position.z);
                        drive.startPosition = NewStartPosition;
                    }
                }

            }
            Debug.DrawRay(_BlockRayRev.origin, _BlockRayRev.direction * 1000f, Color.white);
        }
        if (Vertical)
        {
            _BlockRay = new Ray(BlockRayXPosition.position, Vector3.forward);
            _BlockRayRev = new Ray(BlockRayRevXPosition.position, -Vector3.forward);
            if (Physics.Raycast(_BlockRayRev, out BlockHitRev, 10f))
            {
                if (Physics.Raycast(_BlockRay, out BlockHit, 10f))
                {
                    if (BlockHitRev.transform.tag == "PlayBlock")
                    {
                        NewEndPosition.transform.position = new Vector3(EndPosition.position.x, EndPosition.position.y, BlockHitRev.point.z + (0.12f + Offset));
                        drive.endPosition = NewEndPosition;
                    }
                    if (BlockHit.transform.tag == "PlayBlock")
                    {
                        NewStartPosition.transform.position = new Vector3(StartPosition.position.x, StartPosition.position.y, BlockHit.point.z - (0.12f + Offset));
                        drive.startPosition = NewStartPosition;
                    }
                }

            }
            Debug.DrawRay(_BlockRayRev.origin, _BlockRayRev.direction * 1000f, Color.white);
            Debug.DrawRay(_BlockRay.origin, _BlockRay.direction * 1000f, Color.white);
        }
    }
}
