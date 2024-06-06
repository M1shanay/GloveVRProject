using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;

public class StructureFloor : MonoBehaviour
{
    public List<CubePuzzleCheckCollider> Floor;
    public GameObject NextFloor;

    private bool _ended = false;

    public bool IsEnded
    {
        get { return _ended; }
    }

    void Awake()
    {
        foreach (var f in GetComponentsInChildren<CubePuzzleCheckCollider>())
        {
            Floor.Add(f);
        }
    }
    void Start()
    {
        StartCoroutine(CheckComplited());
    }
    private IEnumerator CheckComplited()
    {
        while (!_ended)
        {
            var temp = 0;
            foreach (var c in Floor)
            {
                if (c.Entities == c.MaxEntities)
                {
                    temp++;
                }
            }
            if (temp == Floor.Count)
            {
                _ended = true;
                if (NextFloor)
                {
                    Debug.Log("NextFloor");
                    NextFloor.SetActive(true);
                }
            }
            yield return null;
        }
        yield return null;
    }
}
