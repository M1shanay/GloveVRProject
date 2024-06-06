using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BagelSlotsManager : MonoBehaviour
{
    public List<BagelSlot> Slots;
    public bool Winnable;
    public bool Result = false;
    private int _stackCounter;

    private void Start()
    {
        _stackCounter = Slots.Count - 1;
        InitStack();
    }

    private void CheckWin()
    {

        int count = 0;
        for (int i = 0; i < Slots.Count; i++)
        {
            if (Slots[i].UsedBy == i+1)
                count++;
        }
        if (count == Slots.Count)
        {
            Debug.Log("Win");
            Result = true;
        }
        else
        {
            Debug.Log("Lose");
        }
    }
    private void InitStack()
    {
        for(int i = 0; i < _stackCounter; i++)
        {
            Slots[i].Disable();
        }
    }
    public void UpdateStack()
    {
        if (_stackCounter == 0)
        {
            _stackCounter--;
            if(Winnable)
              CheckWin();
        }
        if (_stackCounter > 0)
        {
            Slots[_stackCounter - 1].Enable();
            _stackCounter--;
        }
        Debug.Log(_stackCounter);
    }
    public void PopStack()
    {
        if (_stackCounter < Slots.Count-1 && _stackCounter > -1)
        {
            Slots[_stackCounter].Disable();
            _stackCounter++;
        }
        if (_stackCounter == -1)
        {
            _stackCounter++;
        }
        Debug.Log(_stackCounter);
    }
}
