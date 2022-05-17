using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionButton : MonoBehaviour
{
    public GameObject m_back_menu;
    public GameObject m_option_menu;

    public void ToOptionMenu()
    {
        m_back_menu.SetActive(false);
        m_option_menu.SetActive(true);
    }

    public void Back()
    {
        m_back_menu.SetActive(true);
        m_option_menu.SetActive(false);
    }
}
