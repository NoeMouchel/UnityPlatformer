using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(TryPoint))]
public class PlayerSpawn : MonoBehaviour
{
    public GameObject m_playerOriginal;
    public GameObject m_camera;
    public GameObject m_inputManager;
    public GameObject m_PlayerUI;

    private TryPoint m_tp;

    [Range(1, 10)]
    public int m_life;

    [Range(1, 10)]
    public int m_max_life;

    private GameObject m_playerInstance;


    // Camera Save
    private float m_offset;
    private float m_height;
    private float m_speed;
    private bool m_camera_saved;

    private void Awake()
    {
        m_tp = GetComponent<TryPoint>();
    }

    // Start is called before the first frame update
    void Start()
    {
        SpawnPlayer();

        m_PlayerUI.GetComponent<UI_HP>().Initialize();
        m_PlayerUI.GetComponent<UI_TP>().Initialize();
    }

    private void Update()
    {
        if(m_tp.IsMin())
        {
            GameEvents.GameOver();
        }
    }

    private void OnEnable()
    {
        GameEvents.OnPlayerDestroy += DestroyInstance;
    }

    private void OnDisable()
    {
        GameEvents.OnPlayerDestroy -= DestroyInstance;
    }

    private void DestroyInstance()
    {
        if (m_playerInstance != null) Destroy(m_playerInstance);
        m_tp.Decrement();
        if (m_tp.IsMin() == false)
        {
            SpawnPlayer(); 
        }
    }
    private void SpawnPlayer()
    {
        m_playerInstance = Instantiate(m_playerOriginal, transform.position, Quaternion.identity);

        HealthPoint player_hp = m_playerInstance.GetComponent<HealthPoint>();

        player_hp.m_point = m_life;
        player_hp.m_max = m_max_life;

        m_camera.GetComponent<CameraFollows>().LinkTo(m_playerInstance);

        PlayerController pc = m_playerInstance.GetComponent<PlayerController>(); ;
        pc.m_tp = m_tp;
        m_inputManager.GetComponent<InputManager>().m_playerController = pc;

        m_PlayerUI.GetComponent<UI_HP>().m_player_hp = player_hp;
        m_PlayerUI.GetComponent<UI_TP>().m_player_tp = m_tp;

        GameEvents.PlayerSpawn();

        if(m_camera_saved)
        {
            if(m_camera.TryGetComponent<CameraFollows>(out CameraFollows cf))
            {
                cf.CameraModifyNow(m_offset, m_height, m_speed);
            }
        }
    }

    public void SaveCamera()
    {
        if (m_camera.TryGetComponent<CameraFollows>(out CameraFollows cf))
        {
            m_offset = cf.m_offset;
            m_height = cf.m_height;
            m_speed = cf.m_speed;
            m_camera_saved = true;
        }
    }
}

