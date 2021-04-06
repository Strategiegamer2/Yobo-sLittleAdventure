using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BattleSystem : MonoBehaviour
{
    private enum State
    {
        Idle,// Battle not started
        Active, // Battle started
    }

    [SerializeField] private ColliderTrigger colliderTrigger;
    [SerializeField] private Wave[] waveArray;

    private State state;

    private void Awake()
    {
        print("works");
        state = State.Idle;
    }

    private void Start()
    {
        colliderTrigger.OnPlayerEnterTrigger += colliderTrigger_OnPlayerEnterTrigger;
    }

    private void colliderTrigger_OnPlayerEnterTrigger(object sender, EventArgs e)
    {
        if (state == State.Idle)
        {
            StartBattle();
            colliderTrigger.OnPlayerEnterTrigger -= colliderTrigger_OnPlayerEnterTrigger;
        }
    }

    private void StartBattle()
    {
        Debug.Log("StartBattle");
        state = State.Active; 
    }

    private void Update()
    {
        switch (state)
        {
            case State.Active:
                foreach (Wave wave in waveArray)
                {
                    wave.Update();
                }
                break;
        }
    }


    [System.Serializable]
    public class Wave
    {
        [SerializeField] private EnemySpawn[] enemySpawnArray;
        [SerializeField] private float timer;
        private int waveNumber = 0;

        public void Update()
        {
            if (timer >= 0)
            {
                timer -= Time.deltaTime;
                if (timer <= 0)
                {
                    SpawnEnemies();
                }
            }
        }
        private void SpawnEnemies()
        {
            waveNumber++;
            Debug.Log(waveNumber);
            foreach (EnemySpawn enemySpawn in enemySpawnArray)
            {
                waveNumber++;
                switch (waveNumber)
                {
                    case 1:
                        enemySpawn.Spawn();
                        break;
                    case 2:
                        enemySpawn.Spawn();
                        break;
                    case 3:
                        enemySpawn.Spawn();
                        waveNumber++;
                        break;
                    case 4:
                        enemySpawn.Spawn();
                        waveNumber++;
                        break;
                    case 5:
                        enemySpawn.SpawnBoss();
                        waveNumber++;
                        break;
                    case 6:
                        enemySpawn.Spawn2();
                        waveNumber++;
                        break;
                    case 7:
                        enemySpawn.Spawn2();
                        waveNumber++;
                        break;
                    case 8:
                        enemySpawn.Spawn2();//stronger than 7
                        waveNumber++;
                        break;
                    case 9:
                        enemySpawn.Spawn2();//stronger than 7
                                                waveNumber++;
                        break;
                    case 10:
                        enemySpawn.SpawnBoss();
                        break;
                }
            }
        }
    }
}
