﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    public GameObject player;
    public int velocidad;
    private Vector3 startPos;

    // Start is called before the first frame update
    void Start()
    {
        velocidad = 1;
        startPos = transform.localPosition;

    }

    // Update is called once per frame
    void Update()
    {
        //para que el enemigo se mueva con la plataforma 
        transform.localPosition = new Vector3(startPos.x, startPos.y + Mathf.Sin(Time.time) * velocidad, startPos.z);

    }

}
