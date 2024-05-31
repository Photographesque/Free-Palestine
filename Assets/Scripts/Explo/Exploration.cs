using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Exploration : MonoBehaviour
{
    public Vector3 StartPos;

    public int moveModifier;

    void Start()
    {
        StartPos = transform.position;
    }

    void Update()
    {
        Vector3 pz = Camera.main.ScreenToWorldPoint(Input.mousePosition)*-1;

        transform.position = new Vector3(StartPos.x + (pz.x * moveModifier), StartPos.y + (pz.y * moveModifier), 0);
    }
}