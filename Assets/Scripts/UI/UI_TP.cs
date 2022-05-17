using UnityEngine.UI;
using UnityEngine;

public class UI_TP : MonoBehaviour
{
    public Image tp_bar;
    public GameObject tp_separator;
    public RectTransform tp_start;
    public RectTransform tp_end;

    public TryPoint m_player_tp;

    private float fill = 1f;

    public void Initialize()
    {
        float width = Mathf.Abs(tp_end.transform.position.x - tp_start.transform.position.x);
        float height = Mathf.Abs(tp_end.transform.position.y - tp_start.transform.position.y);

        for (int i = 1; i < m_player_tp.m_max; i++)
        {
            GameObject new_separator = Instantiate(tp_separator, tp_bar.gameObject.transform);
            RectTransform t = new_separator.GetComponent<RectTransform>();
            t.position = (tp_start.position - t.up * height * .5f) + (t.right * i * width * (1f / m_player_tp.m_max));
            t.sizeDelta = new Vector2(t.rect.width, height);
        }
    }

    // Update is called once per frame
    void Update()
    {
        fill = (float)m_player_tp.m_point / (float)m_player_tp.m_max;
        tp_bar.fillAmount = fill;
    }
}
