using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    #region Singleton
    public static PlayerManager instance;
    private void Awake()
    {
        PlayerManager.instance = this;
    }
    #endregion
    public GameObject player;
    public CharacterCombat playerCombat;
    public PlayerStats playerStats;

    private void Start()
    {
        playerStats.OnHealthReachedZero += Die;
    }

    private void Die()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
