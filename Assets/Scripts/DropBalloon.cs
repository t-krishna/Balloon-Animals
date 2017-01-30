﻿using UnityEngine;
using System.Collections;

public class DropBalloon : MonoBehaviour {

    public string dropControl = "Drop";
    public int balloonCount = 100;
    bool dropped = false;
    GameObject balloon;
    Sprite[] balloonSprites;

    // Use this for initialization
    void Start () {
        balloon = Resources.Load<GameObject>("Balloon");
        balloonSprites = Resources.LoadAll<Sprite>("Sprites/balloons");
        PlayerPrefs.SetInt("bCount", balloonCount); //sets the text for the total number of starting balloons
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetAxis(dropControl) == 0)
            dropped = false;
        else if (!dropped) {
            dropped = true;
            dropBallon();
        }
        balloonCount = PlayerPrefs.GetInt("bCount"); //Sets the balloonCount to the number displayed
    }

    void dropBallon() {
        if (balloonCount > 0) {
            --balloonCount;
            GameObject spawned = Instantiate<GameObject>(balloon);
            spawned.transform.position = transform.position;
            spawned.transform.Translate(Vector3.down * 1.8f);
            spawned.transform.Rotate(new Vector3(0, 0, Random.Range(1, 360)));

            spawned.GetComponent<BalloonBehaviour>().sprite = balloonSprites[Random.Range(0, 3)];
            PlayerPrefs.SetInt("bCount", balloonCount--); //Subtracts a balloon on the display
        }
    }
}
