﻿using UnityEngine;
using System.Collections;

public class LevelGenerator : MonoBehaviour {
    public ArrayList levels;
    public GameObject StartSign;
    public GameObject coin;
	private Vector3 startPosition;
    private Level CurrentLevel;
    private Vector3 offset;
    public bool canStart;
    public bool isStarted;

	// Use this for initialization
	void Start () {
        isStarted = false;
        canStart = false;
        offset = new Vector3(0, 0.25f, 0);
        levels = new ArrayList();
        level1();
		startPosition = new Vector3(0f,0f,0f);
		Camera.main.transform.position = startPosition;
		CurrentLevel = (Level)levels[PlayerPrefs.GetInt("level")];

        Vector3 StartSignPos = (Vector3)CurrentLevel.coinPositions[0] + offset;
        (Instantiate(StartSign, new Vector3(StartSignPos.x * PlayerPrefs.GetFloat("width"), StartSignPos.y, StartSignPos.z * PlayerPrefs.GetFloat("length")), StartSign.transform.rotation) as GameObject).transform.parent = GameObject.FindGameObjectWithTag("LevelPlane").transform;

        
		
	}

	

	// Update is called once per frame
	void Update () {
        if (canStart)
        {
            if (!isStarted)
            {
                Debug.Log("je kan de game starten");
                startGame();
                isStarted = true;
            }
        }
	}

    float getScale(float data)
    {
        return data / 10;
    }

    private void startGame()
    {

        foreach(Vector3 v in CurrentLevel.coinPositions) {
            (Instantiate(coin, new Vector3(v.x * PlayerPrefs.GetFloat("width"), v.y + 0.10f, v.z * PlayerPrefs.GetFloat("length")), coin.transform.rotation) as GameObject).transform.parent = GameObject.FindGameObjectWithTag("LevelPlane").transform;
        }
      
    }
    private void level1()
    {
        ArrayList level1Positions = new ArrayList();
        level1Positions.Add(new Vector3(-0.38f, 0f, -0.40f));
        level1Positions.Add(new Vector3(-0.28f, 0f, -0.40f));
        level1Positions.Add(new Vector3(-0.20f, 0f, -0.40f));
        level1Positions.Add(new Vector3(-0.15f, 0f, -0.40f));
        level1Positions.Add(new Vector3(-0.10f, 0f, -0.40f));
        level1Positions.Add(new Vector3(-0.05f, 0f, -0.40f));
        level1Positions.Add(new Vector3(0f, 0f, -0.40f));
        level1Positions.Add(new Vector3(0.05f, 0f, -0.40f));
        level1Positions.Add(new Vector3(0.10f, 0f, -0.40f));
        level1Positions.Add(new Vector3(0.15f, 0f, -0.40f));
        level1Positions.Add(new Vector3(0.20f, 0f, -0.40f));
        level1Positions.Add(new Vector3(0.25f, 0f, -0.40f));
        level1Positions.Add(new Vector3(0.30f, 0f, -0.40f));
        level1Positions.Add(new Vector3(0.35f, 0f, -0.40f));
        level1Positions.Add(new Vector3(0.40f, 0f, -0.40f));
        Level level1 = new Level(1,coin, level1Positions);
        levels.Add(level1);
    }
}
