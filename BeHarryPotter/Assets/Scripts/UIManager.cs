using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Slider playerHP;
    [SerializeField]
    private Slider enemyFrontHP;
    [SerializeField]
    private Slider enemyLeftHP;
    [SerializeField]
    private Slider enemyRightHP;

    private int maxHP = 100;
    private int playerCurrentHP;
    private int enemyFrontCurrentHP;
    private int enemyLeftCurrentHP;
    private int enemyRightCurrentHP;

    // Start is called before the first frame update
    void Start()
    {
        playerHP = GameObject.Find("PlayerHPBar").GetComponent<Slider>();
        enemyFrontHP = GameObject.Find("EnemyFrontHPBar").GetComponent<Slider>();
        enemyLeftHP = GameObject.Find("EnemyLeftHPBar").GetComponent<Slider>();
        enemyRightHP = GameObject.Find("EnemyRightHPBar").GetComponent<Slider>();

        playerHP.value = (float)playerCurrentHP / (float)maxHP;
        enemyFrontHP.value = (float)enemyFrontCurrentHP / (float)maxHP;
        enemyLeftHP.value = (float)enemyLeftCurrentHP/ (float)maxHP;
        enemyRightHP.value = (float)enemyRightCurrentHP/(float)maxHP;
    }

    // Update is called once per frame
    void Update()
    {
        playerCurrentHP = (int)GameObject.Find("OVRPlayerController").GetComponent<Player>().health;
        enemyFrontCurrentHP = (int)GameObject.Find("Necromancer").GetComponent<Enemy>().health;
        enemyLeftCurrentHP = (int)GameObject.Find("Necromancer").GetComponent<Enemy>().health;
        enemyRightCurrentHP = (int)GameObject.Find("Necromancer").GetComponent<Enemy>().health;
        HandleHP();
    }

    void HandleHP()
    {
        playerHP.value = (float)playerCurrentHP / (float)maxHP;
        enemyFrontHP.value = (float)enemyFrontCurrentHP / (float)maxHP;
        enemyLeftHP.value = (float)enemyLeftCurrentHP / (float)maxHP;
        enemyRightHP.value = (float)enemyRightCurrentHP / (float)maxHP;
    }
}
