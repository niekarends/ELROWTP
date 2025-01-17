﻿/*
    Framework for ELRO Wants To Play
    Copyright (C) 2015 Simon Voordouw
    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.
    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.
    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <http://www.gnu.org/licenses/>.
 */

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace Framework
{
	/**
	 * Registers for location updates from a LocationProvider on the same entity. 
	 * Translates the entity based on received updates with matching color
	 */
	public class LocationListener : MonoBehaviour
	{
		public PlayerColor color;
		LocationProvider locationProvider;
		Vector3 targetLocation;

		void Start ()
		{
			locationProvider = GetComponent<LocationProvider> ();

			locationProvider.OnLocationUpdate += (object source, LocationUpdateArgs e) => {
				if ((PlayerColor)e.ObjectId == color) {
					targetLocation = e.Location;
				}
			};
			targetLocation = transform.position;
		}

		void Update ()
		{
			transform.position = Vector3.MoveTowards (transform.position, targetLocation, 0.08f);
		}
	}
}