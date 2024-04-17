using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chapter : MonoBehaviour
{
    public UIManager TextManager;
    public List<GameObject> InteractableItems;
    public virtual string Title { get; } = "Задания закончены!";
    protected bool _finished = false;
    protected bool _mark = false;

    public bool IsFinished
    {
        get { return _finished; }
    }
    public virtual void StartTask()
    {

    }
    protected void StartChapter()
    {
        StartCoroutine(Processing());
    }
    private void EndChapter()
    {
        _finished = true;
        gameObject.SetActive(false);
        foreach (GameObject item in InteractableItems)
        {
            item.SetActive(false);
        }
    }

    protected virtual void ChapterRunning()
    {
        
    }
    private IEnumerator Processing()
    {
        yield return new WaitForSeconds(2f);
        while (!_mark) 
        {
            ChapterRunning();
            yield return null;
        }
        yield return new WaitForSeconds(5f);
        EndChapter();
        yield return null;
    }
}
