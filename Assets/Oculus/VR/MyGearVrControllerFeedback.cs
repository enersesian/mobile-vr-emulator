/************************************************************************************
Copyright : Copyright (c) Facebook Technologies, LLC and its affiliates. All rights reserved.

Licensed under the Oculus Utilities SDK License Version 1.31 (the "License"); you may not use
the Utilities SDK except in compliance with the License, which is provided at the time of installation
or download, or which otherwise accompanies this software in either electronic or hard copy form.

You may obtain a copy of the License at
https://developer.oculus.com/licenses/utilities-1.31

Unless required by applicable law or agreed to in writing, the Utilities SDK distributed
under the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF
ANY KIND, either express or implied. See the License for the specific language governing
permissions and limitations under the License.
************************************************************************************/

using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Text;

public class MyGearVrControllerFeedback : MonoBehaviour
{
	public Text uiTriggerText, uiTouchpadText;
    public Image uiTriggerPanel, uiTouchpadPanel;
    private Vector2 primaryTouchpad;
    private StringBuilder data;

    private void Start()
    {
        data = new StringBuilder(2048);
    }

    void Update()
	{
        data.Length = 0;
        data.AppendFormat("Touchpad\n");
		primaryTouchpad = OVRInput.Get(OVRInput.Axis2D.PrimaryTouchpad);
		data.AppendFormat("({0:F1}, {1:F1})", primaryTouchpad.x, primaryTouchpad.y);


        if(uiTouchpadText != null)
        {
            uiTouchpadText.text = data.ToString();
        }

        //Index trigger click event
        if (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger) || (Application.isEditor && Input.GetMouseButton(0))) //touchpad click also counts as a left click
        {
            uiTriggerPanel.color = new Color(0f, 1f, 0f, 1f);
        }
   
        if (OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger) || (Application.isEditor && Input.GetMouseButtonUp(0)))
        {
            uiTriggerPanel.color = new Color(1f, 1f, 1f, 1f); ;
        }

        //Touchpad touch event, no keyboard/mouse emulation
        if (OVRInput.Get(OVRInput.Touch.PrimaryTouchpad))
        {
            uiTouchpadPanel.color = new Color(0.5f, 1f, 0.5f, 1f);
        }

        //Touchpad click event mapped to right mouse click, technically touch needs to happen before click but not emulating that sequence
        if (OVRInput.Get(OVRInput.Button.PrimaryTouchpad) || (Application.isEditor && Input.GetMouseButton(1)))
        {
            uiTouchpadPanel.color = new Color(0f, 1f, 0f, 1f);
        }

        if (OVRInput.GetUp(OVRInput.Touch.PrimaryTouchpad) || (Application.isEditor && Input.GetMouseButtonUp(1)))
        {
            uiTouchpadPanel.color = new Color(1f, 1f, 1f, 1f); ;
        }

        if (OVRInput.Get(OVRInput.Button.Up) || Input.GetKey(KeyCode.W))
        { 
            //Set timer to replace x,y info with up 
        }

        if (OVRInput.Get(OVRInput.Button.Right) || Input.GetKey(KeyCode.D))
        {
            //Set timer to replace x,y info with up 
        }

        if (OVRInput.Get(OVRInput.Button.Down) || Input.GetKey(KeyCode.S))
        {
            //Set timer to replace x,y info with up 
        }

        if (OVRInput.Get(OVRInput.Button.Left) || Input.GetKey(KeyCode.A))
        {
            //Set timer to replace x,y info with up 
        }

    }
}
