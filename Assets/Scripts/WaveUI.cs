using System;
using UnityEngine;
using UnityEngine.UI;
public class WaveUI : MonoBehaviour {


    [SerializeField]
    WaveSpawner spawner;

    [SerializeField]
    Animator waveAnimator;

    [SerializeField]
    Text waveCountDownText;
    
    [SerializeField]
    Text waveCountText;


    private WaveSpawner.SpawnState previousState;

    void Start () {

        if (spawner == null)
        {
            Debug.Log("Spawner not referenced");
            this.enabled = false;

        }
        if (waveAnimator == null)
        {
            Debug.Log("Spawner not referenced");
            this.enabled = false;

        }
        if (waveCountDownText == null)
        {
            Debug.Log("Spawner not referenced");
            this.enabled = false;

        }
        if (waveCountText == null)
        {
            Debug.Log("Spawner not referenced");
            this.enabled = false;

        }


    }
	
	// Update is called once per frame
	void Update () {
		
        switch(spawner.State)
        {
            case WaveSpawner.SpawnState.Counting:
                UpdateCountingUI();
                break;

            case WaveSpawner.SpawnState.Spawning:
                UpdateSpawningUI();
                break;
        }

        previousState = spawner.State;

    }

    void UpdateCountingUI()
    {
        if(previousState != WaveSpawner.SpawnState.Counting)
        {
            waveAnimator.SetBool("WaveIncoming", false);
            waveAnimator.SetBool("WaveCountdown", true);
            Debug.Log("counting");
        }
        waveCountDownText.text = ((int)spawner.WaveCountdown).ToString();

    }

    void UpdateSpawningUI()
    {
        if (previousState != WaveSpawner.SpawnState.Spawning)
        {
            waveAnimator.SetBool("WaveCountdown", false);
            waveAnimator.SetBool("WaveIncoming", true);
            Debug.Log("spawning");

            waveCountText.text = spawner.NextWave.ToString();
        }
    }
}
