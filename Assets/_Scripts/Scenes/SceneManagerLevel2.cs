using UnityEngine;
using UnityEngine.UI;

public class SceneManagerLevel2 : MonoBehaviour
{
    [SerializeField] private GameObject _LevelPrompt;
    [SerializeField] private GameObject _HealthBar;

    AudioManagerLevel02 audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("TagAudio").GetComponent<AudioManagerLevel02>();
    }

    void Start()
    {
        _HealthBar.SetActive(false);
        Time.timeScale = 0.0f;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Return))
        {
            InitiateLevel();
        }
    }

    public void InitiateLevel()
    {
        Time.timeScale = 1.0f;
        _LevelPrompt.SetActive(false);
        _HealthBar.SetActive(true);
        audioManager.PlayBackgroundMusic();
    }
}
