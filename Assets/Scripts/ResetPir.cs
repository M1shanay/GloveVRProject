using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPir : MonoBehaviour
{
    public List<GameObject> Cubes;
    List<Vector3> CubesPositions;
    List<Quaternion> CubesRotations;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("asd");
        CubesPositions = new List<Vector3>();
        CubesRotations = new List<Quaternion>();
        foreach (GameObject t in Cubes)
        {
            CubesPositions.Add(t.transform.position);
            CubesRotations.Add(t.transform.rotation);
        }
    }

    public void ResetCubes()
    {
        for (int i = 0; i < Cubes.Count; i++)
        {
            Debug.Log(CubesPositions[i]);
            Cubes[i].GetComponent<Rigidbody>().velocity = Vector3.zero;
            Cubes[i].transform.position = CubesPositions[i];
            Cubes[i].transform.rotation = CubesRotations[i];
        }
    }
}
