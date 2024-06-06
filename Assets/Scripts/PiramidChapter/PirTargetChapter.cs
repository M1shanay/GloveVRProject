using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using Valve.VR;

public class PirTargetChapter : Chapter
{
    public List<GameObject> Cubes;
    public List<GameObject> Spheres;
    List<Vector3> CubesPositions;
    List<Quaternion> CubesRotations;
    List<Vector3> SpheresPositions;
    List<Quaternion> SpheresRotations;
    public CheckCollider CheckCollider;

    public override string Title { get; } = "Разбейте пирамиду!";
    public override void StartTask()
    {
        CubesPositions = new List<Vector3>();
        CubesRotations = new List<Quaternion>();
        foreach (GameObject t in Cubes)
        {
            CubesPositions.Add(t.transform.position);
            CubesRotations.Add(t.transform.rotation);
        }
        SpheresPositions = new List<Vector3>();
        SpheresRotations = new List<Quaternion>();
        foreach (GameObject t in Spheres)
        {
            SpheresPositions.Add(t.transform.position);
            SpheresRotations.Add(t.transform.rotation);
        }
        StartChapter();
    }

    public void ButtonResetSpheres()
    {
        for (int i = 0; i < Spheres.Count; i++)
        {
            Spheres[i].GetComponent<Rigidbody>().velocity = Vector3.zero;
            Spheres[i].transform.position = SpheresPositions[i];
            Spheres[i].transform.rotation = SpheresRotations[i];
        }
    }
    protected override void ChapterRunning()
    {
        Debug.Log("processing");
        if (CheckCollider.Entities < 4)
        {
            _mark = true;
            Debug.Log("ended");
        }
    }
}
