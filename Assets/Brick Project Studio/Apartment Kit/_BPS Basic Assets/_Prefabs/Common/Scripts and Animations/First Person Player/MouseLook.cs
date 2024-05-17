﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SojaExiles

{
    public class MouseLook : MonoBehaviour
    {
        public bool mouseLock = false;

        public float mouseXSensitivity = 100f;

        public Transform playerBody;

        float xRotation = 0f;

        // Start is called before the first frame update
        void Start()
        {
            //Cursor.lockState = CursorLockMode.Locked;
        }

        // Update is called once per frame
        void Update()
        {
            if (!mouseLock && Input.GetMouseButton(1))
            {
                float mouseX = Input.GetAxis("Mouse X") * mouseXSensitivity * Time.deltaTime;
                float mouseY = Input.GetAxis("Mouse Y") * mouseXSensitivity * Time.deltaTime;

                xRotation -= mouseY;
                xRotation = Mathf.Clamp(xRotation, -90f, 90f);

                transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
                playerBody.Rotate(Vector3.up * mouseX);
            }
        }


        //singleton
        private static MouseLook _Instance;
        public static MouseLook Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = FindAnyObjectByType<MouseLook>();
                }
                return _Instance;
            }
        }
    }
}