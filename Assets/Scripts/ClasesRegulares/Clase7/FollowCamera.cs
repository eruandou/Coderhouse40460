using System;
using Cinemachine;
using UnityEngine;

namespace ClasesRegulares.Clase7
{
    public class FollowCamera : MonoBehaviour
    {
        [SerializeField] private CinemachineVirtualCamera m_camera1, m_camera2;
        [SerializeField] private GameObject m_camera1Object, m_camera2Object;

        private void Start()
        {
            m_camera1Object.SetActive(true);
            m_camera2Object.SetActive(false);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.J))
            {
                AlternateCameras();
            }
        }

        private void AlternateCameras()
        {
            m_camera1Object.SetActive(!m_camera1Object.activeSelf);
            m_camera2Object.SetActive(!m_camera2Object.activeSelf);
        }
    }
}