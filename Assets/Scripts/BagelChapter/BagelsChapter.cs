using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagelsChapter : Chapter
{
    
    public BagelSlotsManager WinnableSlotsManager;
    public override string Title { get; } = "Соберите пирамиду!";
    public override void StartTask()
    {
        StartChapter();
    }
    protected override void ChapterRunning()
    {
        Debug.Log("processing");
        if (WinnableSlotsManager.Result)
        {
            _mark = true;
            Debug.Log("ended");
        }
    }
}
