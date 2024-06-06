using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PirButton : MonoBehaviour
{
    public GameObject Struct;
    public List<GameObject> StructUnit;
    public GameObject EventStruct;


    public void ButtonEvent()
    {
        foreach (var item in StructUnit)
        {
            item.SetActive(false);
        }
        Struct.SetActive(false);
        EventStruct.SetActive(true);
    }
}
