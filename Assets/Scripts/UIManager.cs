using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject ManagerUI;
    public TMP_Text textManager;

    public void ChangeChapterText(string text)
    {
        textManager.SetText(text);
    }
    public void ChangeMenuText(string text)
    {
        textManager.SetText(text);
    }
    public void Disable()
    {
        ManagerUI.gameObject.SetActive(false);
    }
    public void Enable()
    {
        ManagerUI.gameObject.SetActive(true);
    }
}
