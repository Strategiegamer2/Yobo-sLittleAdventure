using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

[System.Serializable]
public class WaveAction
{
    public string name;
    public float delay;
    public Transform prefab;
    public int spawnCount;
    public string message;
}

[System.Serializable]
public class Wave
{
    public string name;
    public List<WaveAction> actions;
}



public class WaveGenerator : MonoBehaviour
{
    public float difficultyFactor = 0.9f;
    public TextMeshProUGUI finalWave;
    public List<Wave> waves;
    private Wave m_CurrentWave;
    public Wave CurrentWave { get { return m_CurrentWave; } }
    private float m_DelayFactor = 1.0f;

    IEnumerator SpawnLoop()
    {
        m_DelayFactor = 1.0f;
        while (true)
        {
            foreach (Wave W in waves) // array
            {
                m_CurrentWave = W;
                foreach (WaveAction A in W.actions)
                {
                    if (A.delay > 0)
                        yield return new WaitForSeconds(A.delay * m_DelayFactor); //the wait time for new wave
                    if (A.message == "Mega Wave") //if message says Mega Wave, do this
                    {
                        finalWave.enabled = true;
                        yield return new WaitForSeconds(3);
                        finalWave.enabled = false;
                    }
                    if (A.spawnCount > 0)
                    {
                        for (int i = 0; i < A.spawnCount; i++)
                        {
                            Vector3 enemyPosition = new Vector3(Random.Range(-25.5f, 54.6f), Random.Range(-10.5f, 27.9f), 0); // random position on the map 
                            if ((enemyPosition - transform.position).magnitude < 12)
                            {
                                continue;
                            }
                            else
                            {
                                Instantiate(A.prefab, enemyPosition, A.prefab.transform.rotation); //instantiate enemies
                            }
                        }
                    }
                }
                yield return null;  // prevents crash if all delays are 0
            }
            m_DelayFactor *= difficultyFactor;
            yield return null;  // prevents crash if all delays are 0
        }
    }
    void Start()
    {
        finalWave.enabled = false;
        StartCoroutine(SpawnLoop()); //start
    }

}

