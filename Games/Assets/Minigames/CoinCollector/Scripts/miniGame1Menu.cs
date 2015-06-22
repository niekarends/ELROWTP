﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class miniGame1Menu : MonoBehaviour {
	
	public GameObject helpFrame;
	public Button CoinsLevel1, CoinsLevel2, CoinsLevel3;
	public Sprite CoinsLevel1Normal, CoinsLevel1Lock, CoinsLevel2Normal, CoinsLevel2Lock, CoinsLevel3Normal, CoinsLevel3Lock;
	
	/**
	*	Check the "PlayerPrefs" and set the corresponding sprites. Also disables the levels that are not achieved.
	*/
	void Start () {

		PlayerPrefs.SetInt("levelCleared", 0);

		int levelCleared = PlayerPrefs.GetInt("levelCleared");
		if (levelCleared >= 1) {
			CoinsLevel2.interactable = true;
		} else {
			CoinsLevel2.interactable = false;
			CoinsLevel2.image.sprite = CoinsLevel2Lock;
		}
		if (levelCleared >= 2) {
			CoinsLevel3.interactable = true;
		} else {
			CoinsLevel3.interactable = false;
			CoinsLevel3.image.sprite = CoinsLevel3Lock;
		}

	}

	void Update () {
		 
	}
	
	/**
	*	Toggle the help screen. The help screen is used to inform the player of the possibilities.
	*/
	public void toggleHelp() {
		if (helpFrame.activeSelf == true) {
			helpFrame.SetActive(false);
		} else {
			helpFrame.SetActive(true);
		}
	}
	
	/**
	*	Set the type of level.
	*	\param level The level to be loaded.
	*/
	public void startCoinsLevel(int level) {
		PlayerPrefs.SetString("menu", "miniGame1Menu");
        PlayerPrefs.SetInt("CurrentLevel",level);
		Application.LoadLevel("miniGame1");
	}
	
	/**
	*	Change the scene back to "main".
	*/
	public void returnToMain() {
		Application.LoadLevel("main");
	}

}