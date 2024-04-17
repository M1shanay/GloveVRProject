using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ChapterManager : MonoBehaviour
{
    public UIManager TextManager;
    public List<Chapter> Chapters;
    public GameObject StartButton;
    private bool _start = false;


    void Start()
    {
        TextManager.ChangeMenuText("��� ������ ������� ������!");
        StartCoroutine(ChapterChanger());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartButtonFunction()
    {
        _start = true;
        StartButton.SetActive(false);
    }
    private IEnumerator ChapterChanger()
    {
        foreach (var chapter in Chapters)
        {

            yield return new WaitUntil(() => _start);
            yield return new WaitForSeconds(2f);
            chapter.gameObject.SetActive(true);
            TextManager.ChangeChapterText(chapter.Title);
            yield return new WaitForSeconds(2f);
            chapter.StartTask();
            yield return new WaitUntil(() => chapter.IsFinished);
            _start = false;
            StartButton.SetActive(true);
            TextManager.ChangeMenuText("��� ���������� ������� ������� ������!");

        }
        yield return null;
    }
}
