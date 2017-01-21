﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour {

    public float cameraMoveSpeed = 10f;
    public float deadZoneX = 3f;
    public float deadZoneY = 3f;
    public GameObject playerGameObject;

    void Start () {
		
	}

	void Update () {
        /*Vector3 playerpos = c.WorldToScreenPoint(player.transform.position);
        Vector3 camerapos = c.WorldToScreenPoint(gameObject.transform.position);
        if (playerpos.x > camerapos.x + ((Screen.width / 2) * (1 - deadZoneX)))
        {
            //BatController bc = player.GetComponent<BatController>();
            gameObject.transform.position += new Vector3(-(gameObject.transform.position.x - player.transform.position.x) / 10, 0, 0);
        }
        else
        {
            //gameObject.transform.position = new Vector3(player.transform.position.x, 0, -10);
        }*/

        float dx = Mathf.Abs(playerGameObject.transform.position.x - gameObject.transform.position.x);
        float dy = Mathf.Abs(playerGameObject.transform.position.y - gameObject.transform.position.y);
        Vector3 screen = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0)) - Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0));
        Debug.Log(screen.x);
        if (dx > deadZoneX || dy > deadZoneY)
        {
            Vector3 playerLocationRef = playerGameObject.transform.position;
            playerLocationRef.z = -10;
            BatController bc = playerGameObject.GetComponent<BatController>();
            float speed = cameraMoveSpeed;//Mathf.Sqrt(bc.batVelX * bc.batVelX + bc.batVelY * bc.batVelY) + cameraMoveSpeed;
            speed *= Mathf.Sqrt(dx * dx + dy * dy) / Mathf.Sqrt(screen.x*screen.x + screen.y*screen.y);
            //Debug.Log(Mathf.Sqrt(dx * dx + dy * dy) / Mathf.Sqrt(screen.x * screen.x + screen.y * screen.y));
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, playerLocationRef, speed * Time.deltaTime);
        }
	}
}
