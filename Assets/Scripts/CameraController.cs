﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //с помощью скрипта камера не будет вертеться, как ненормальная
    //что она делает, если в иерархии является наследником игрока
    public GameObject player;
    private Vector3 offset;
    void Start()
    {
        offset = transform.position - player.transform.position;
    }
    
    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}
