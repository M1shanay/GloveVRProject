using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubePuzzleCCManager : MonoBehaviour
{
    public int SlotsCount;
    public List<CubePuzzleCheckCollider> BoxesCC;
    public List<CubePuzzleCheckCollider> CylindersCC;
    public List<CubePuzzleCheckCollider> TrianglesCC;
    public List<CubePuzzleCheckCollider> NgonesCC;

    public int _completedRow = 0;


    public bool CheckColliders()
    {
        for (int i = 0; i < SlotsCount; i++)
        {
            if (BoxesCC[i].IsActive() && CylindersCC[i].IsActive() && TrianglesCC[i].IsActive() && NgonesCC[i].IsActive())
            {
                _completedRow = i+1;
            }
            else return false;
        }
        if (_completedRow == SlotsCount)
        {
            return true;
        }
        return false;
    }

}
