﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace Framework
{
	public class LocationListener : MonoBehaviour
	{
		public PlayerColor color;
		LocationProvider locationProvider;

		// Use this for initialization
		void Start ()
		{
			locationProvider = GetComponent<LocationProvider> ();

			locationProvider.OnLocationUpdate += (object source, LocationUpdateArgs e) => {
				if ((PlayerColor)e.ObjectId == color) {
					transform.position = e.Location;
                    GameObject.FindGameObjectWithTag("Cords").GetComponent<Text>().text = transform.position.ToString();
				}
			};
		}
	}
}