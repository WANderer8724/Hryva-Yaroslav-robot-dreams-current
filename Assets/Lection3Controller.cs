using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static UnityEditor.Progress;

public class Lection3Controller : MonoBehaviour
{
    [SerializeField] private List<int> _intList;
    [Header("Видалення елементу")]
    [SerializeField] private int _WhichElementToDelete;
    [Header("Додавання елименту")]
    [SerializeField] private int _WhichElementToAdd;


    [ContextMenu("PrintArray")]
    void PrintArray()
    {

        string str = "list: ";

        for (int i = 0; i < _intList.Count; i++)
        {
            str += $" ,{_intList[i]}";
        }
        str += " .";
        Debug.Log(str);
    }
    [ContextMenu("AddElement")]
    void AddElement()
    {

        _intList.Add(_WhichElementToAdd);

    }

    [ContextMenu("DelElement")]
    void DelElement()
    {
        _intList.Remove(_WhichElementToDelete);
    }

    [ContextMenu("DelList")]
    void DelList()
    {
        for (int i = 0; i < _intList.Count; i++)
        {
            _intList.Clear();
        }
    }


    [ContextMenu("SortList")]
    void SortList()//сортування бульбашка
    {
        for (int i = 0; i < _intList.Count - 1; i++)
        {
            for (int j = 0; j < _intList.Count - i - 1; j++)
            {
                if (_intList[j] > _intList[j + 1])
                {

                    int temp = _intList[j];

                    _intList[j] = _intList[j + 1];

                    _intList[j + 1] = temp;

                }
            }
        }
    }
}
