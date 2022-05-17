using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UI_HP : MonoBehaviour
{
    public Image         hp_bar;
    public GameObject    hp_separator;
    public RectTransform hp_start;
    public RectTransform hp_end;

    public HealthPoint   m_player_hp;

    private float fill = 1f;

    public void Initialize()
    {
        float width = Mathf.Abs(hp_end.transform.position.x - hp_start.transform.position.x);
        float height = Mathf.Abs(hp_end.transform.position.y - hp_start.transform.position.y);

        for (int i = 1; i < m_player_hp.m_max; i ++)
        {
            GameObject new_separator = Instantiate(hp_separator,hp_bar.gameObject.transform);

            RectTransform t = new_separator.GetComponent<RectTransform>();

            t.position = (hp_start.position - t.up*height*.5f) + (t.right * i * width * (1f / m_player_hp.m_max));

            t.sizeDelta= new Vector2(t.rect.width, height);
        }
    }

    // Update is called once per frame
    void Update()
    {
        fill = (float)m_player_hp.m_point / (float)m_player_hp.m_max;
        hp_bar.fillAmount = fill;
    }
}
