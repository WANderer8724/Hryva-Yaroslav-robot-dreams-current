using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static UnityEditor.Progress;

public class Lection3Controller : MonoBehaviour
{
    [SerializeField] private int[] _intArray;
    [SerializeField] private string x = "Element To Delete";
    [SerializeField] private int _WhichElementToDelete;
    [SerializeField] private string y = "Element To Add";
    [SerializeField] private int _WhichElementToAdd;
    [SerializeField] private int _WhereElementToAdd;

    [ContextMenu("PrintArray")]
    void PrintArray()
    {

        string str = "list: ";

        for (int i = 0; i < _intArray.Length; i++)
        {
            str += $" ,{_intArray[i]}";
        }
        str += " .";
        Debug.Log(str);
    }
    [ContextMenu("AddElement")]
    void AddElement()
    {
        if (_WhereElementToAdd <= _intArray.Length && _WhereElementToAdd > -1)
        {
            _intArray[_WhereElementToAdd] = _WhichElementToAdd;
        }
        else
        {
            Debug.Log("Incorrect _WhereElementToAdd");
        }
    }

    [ContextMenu("DelElement")]
    void DelElement()
    {
        for (int i = 0; i < _intArray.Length; i++)
        {
            if (_intArray[i] == _WhichElementToDelete)
            {
                _intArray[i] = 0;
            }
        }
    }

    [ContextMenu("DelArray")]
    void DelArray()
    {
        for (int i = 0; i < _intArray.Length; i++)
        {
            _intArray[i] = 0;
        }
    }


    [ContextMenu("SortArray")]
    void SortArray()//сортування бульбашка
    {
        for (int i = 0; i < _intArray.Length - 1; i++)
        {
            for (int j = 0; j < _intArray.Length - i - 1; j++)
            {
                if (_intArray[j] > _intArray[j + 1])
                {

                    int temp = _intArray[j];

                    _intArray[j] = _intArray[j + 1];

                    _intArray[j + 1] = temp;

                }
            }
        }
    }
}
