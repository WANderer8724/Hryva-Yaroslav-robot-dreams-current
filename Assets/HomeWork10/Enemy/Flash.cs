using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flash : MonoBehaviour
{
    [SerializeField] float timer;
    void Update()
    {

        if (timer <= 0)
        {
            Destroy(gameObject);
            return;
        }
        timer -= Time.deltaTime;
    }
}
