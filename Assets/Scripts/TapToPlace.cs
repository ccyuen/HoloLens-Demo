﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using HoloToolkit.Unity.InputModule;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Enumeration containing the surfaces on which a GameObject
/// can be placed.  For simplicity of this sample, only one
/// surface type is allowed to be selected.
/// </summary>

namespace HoloToolkit.Unity.SpatialMapping
{
    /// <summary>
    /// The TapToPlace class is a basic way to enable users to move objects 
    /// and place them on real world surfaces.
    /// Put this script on the object you want to be able to move. 
    /// Users will be able to tap objects, gaze elsewhere, and perform the
    /// tap gesture again to place.
    /// This script is used in conjunction with GazeManager, GestureManager,
    /// and SpatialMappingManager.
    /// TapToPlace also adds a WorldAnchor component to enable persistence.
    /// </summary>

    public class TapToPlace : MonoBehaviour, IInputClickHandler
    {
       
        [Tooltip("Supply a friendly name for the anchor as the key name for the WorldAnchorStore.")]
        public string SavedAnchorFriendlyName = "SavedAnchorFriendlyName";

        [Tooltip("Place parent on tap instead of current game object.")]
        public bool PlaceParentOnTap;

        [Tooltip("Specify the parent game object to be moved on tap, if the immediate parent is not desired.")]
        public GameObject ParentGameObjectToPlace;

        /// <summary>
        /// Keeps track of if the user is moving the object or not.
        /// Setting this to true will enable the user to move and place the object in the scene.
        /// Useful when you want to place an object immediately.
        /// </summary>
        [Tooltip("Setting this to true will enable the user to move and place the object in the scene without needing to tap on the object. Useful when you want to place an object immediately.")]
        public bool IsBeingPlaced;

        /// <summary>
        /// Manages persisted anchors.
        /// </summary>
        protected WorldAnchorManager anchorManager;
        public AudioClip place;
        public AudioClip pickup;
        public Camera mainCamera;

        /// <summary>
        /// Controls spatial mapping.  In this script we access spatialMappingManager
        /// to control rendering and to access the physics layer mask.
        /// </summary>
        protected SpatialMappingManager spatialMappingManager;

        protected virtual void Start()
        {
            // Make sure we have all the components in the scene we need.
            anchorManager = WorldAnchorManager.Instance;
            if (anchorManager == null)
            {
                Debug.LogError("This script expects that you have a WorldAnchorManager component in your scene.");
            }

            spatialMappingManager = SpatialMappingManager.Instance;
            if (spatialMappingManager == null)
            {
                Debug.LogError("This script expects that you have a SpatialMappingManager component in your scene.");
            }

            if (anchorManager != null && spatialMappingManager != null)
            {
                anchorManager.AttachAnchor(gameObject, SavedAnchorFriendlyName);
            }
            else
            {
                // If we don't have what we need to proceed, we may as well remove ourselves.
                Destroy(this);
            }

            if (PlaceParentOnTap)
            {
                if (ParentGameObjectToPlace != null && !gameObject.transform.IsChildOf(ParentGameObjectToPlace.transform))
                {
                    Debug.LogError("The specified parent object is not a parent of this object.");
                }

                DetermineParent();
            }

            spatialMappingManager.DrawVisualMeshes = false;
        }

        protected virtual void Update()
        {
            // If the user is in placing mode,
            // update the placement to match the user's gaze.
            if (IsBeingPlaced)
            {
                gameObject.layer = 0;
                if (gameObject.tag.Equals("Platform"))
                {
                    gameObject.transform.parent.Find("deskLamp/Lamp/Base").gameObject.layer = 0; 
                }
                else if (gameObject.tag.Equals("ChessBoard"))
                {
                    Debug.Log("Stack layer set to 0");
                    gameObject.transform.parent.Find("Stack").gameObject.layer = 0;
                }

                // Do a raycast into the world that will only hit the Spatial Mapping mesh.
                Vector3 headPosition = Camera.main.transform.position;
                Vector3 gazeDirection = Camera.main.transform.forward;

                RaycastHit hitInfo;
                if (Physics.Raycast(headPosition, gazeDirection, out hitInfo, 30.0f, spatialMappingManager.LayerMask))
                {
                    if (gameObject.tag.Equals("Platform1"))
                    {
                        gameObject.SendMessageUpwards("Moving", hitInfo.point);
                    }
                    // Rotate this object to face the user.
                    Quaternion toQuat = Camera.main.transform.localRotation;
                    toQuat.x = 0;
                    toQuat.z = 0;

                    // Move this object to where the raycast
                    // hit the Spatial Mapping mesh.
                    // Here is where you might consider adding intelligence
                    // to how the object is placed.  For example, consider
                    // placing based on the bottom of the object's
                    // collider so it sits properly on surfaces.
                    if (PlaceParentOnTap)
                    {
                        // Place the parent object as well but keep the focus on the current game object
                        Vector3 currentMovement = hitInfo.point - gameObject.transform.position;
                        ParentGameObjectToPlace.transform.position += currentMovement;
                        ParentGameObjectToPlace.transform.rotation = toQuat;
                    }
                    else
                    {
                        gameObject.transform.position = hitInfo.point;
                        gameObject.transform.rotation = toQuat;
                    }
                }
            }
            else
            {
                gameObject.layer = 31;
            }
        }

        public virtual void OnInputClicked(InputEventData eventData)
        {
            // if the user is in shooting mode and or the user is already holding an object, disable tapping and placing objects
            if (!SpeechHandler.shooting)
            {
                // On each tap gesture, toggle whether the user is in placing mode.
                if (!this.IsBeingPlaced && !GazeManager.Instance.isAlreadyPlacing)
                {
                    IsBeingPlaced = true;
                    GazeManager.Instance.isAlreadyPlacing = true;
                    AudioSource.PlayClipAtPoint(pickup, mainCamera.transform.position, 1f);
                }
                else if (this.IsBeingPlaced)
                {
                    IsBeingPlaced = false;
                    GazeManager.Instance.isAlreadyPlacing = false;
                    AudioSource.PlayClipAtPoint(place, mainCamera.transform.position, 1f);
                }
                    

                // If the user is in placing mode, display the spatial mapping mesh.
                if (IsBeingPlaced)
                {
                    spatialMappingManager.DrawVisualMeshes = true;

                    Debug.Log(gameObject.name + " : Removing existing world anchor if any.");

                    anchorManager.RemoveAnchor(gameObject);
                }
                // If the user is not in placing mode, hide the spatial mapping mesh.
                else
                {
                    spatialMappingManager.DrawVisualMeshes = false;
                    // Add world anchor when object placement is done.
                    anchorManager.AttachAnchor(gameObject, SavedAnchorFriendlyName);
                }
            }
        }

        private void DetermineParent()
        {
            if (ParentGameObjectToPlace == null)
            {
                if (gameObject.transform.parent == null)
                {
                    Debug.LogError("The selected GameObject has no parent.");
                    PlaceParentOnTap = false;
                }
                else
                {
                    Debug.LogError("No parent specified. Using immediate parent instead: " + gameObject.transform.parent.gameObject.name);
                    ParentGameObjectToPlace = gameObject.transform.parent.gameObject;
                }
            }
        }
    }
}
