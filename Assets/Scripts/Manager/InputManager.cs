using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager: MonoBehaviour
{
    public PlayerController   m_playerController;

    // Update is called once per frame
    void Update()
    {
        if (m_playerController != null)
        {
            if (Input.GetButtonDown("Jump"))
            {
                m_playerController.JumpPressed();
            }

            if (Input.GetButton("Jump"))
            {
                m_playerController.JumpHolded();
            }

            m_playerController.MoveButtonPressed(Input.GetAxis("Horizontal"));
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale != 0f)
            {
                GameEvents.Pause();
            }
            /*else
            {
                GameEvents.Resume();
            }*/
        }
    }

}
