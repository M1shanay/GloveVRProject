using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PiroChapter : Chapter
{
    public CheckCollider CheckCollider;
    public PirStructure PirStructure;
    public GameObject BoomButton;
    public override string Title { get; } = "Постройте и разбейте пирамиду!";
    // Start is called before the first frame update
    public override void StartTask()
    {
        StartChapter();
    }
    protected override void ChapterRunning()
    {
        Debug.Log("processing");
        if (PirStructure.IsComplited && !BoomButton.activeSelf)
        {
            BoomButton.SetActive(true);
        }
        else if (BoomButton.activeSelf)
        {
            if (CheckCollider.Entities < CheckCollider.MaxEntities)
            {
                _mark = true;
                Debug.Log("ended");
            }
        }
    }
}
