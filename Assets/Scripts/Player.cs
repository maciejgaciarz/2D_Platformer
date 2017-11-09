using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	[System.Serializable]
	public class PlayerStats
	{
		public int maxHealth = 100;


        private int _curHealth;
        public int curHealth
        {
            get { return _curHealth; }
            set { _curHealth = Mathf.Clamp(value, 0, maxHealth); }
        }

        public void Init()
        {
            _curHealth = maxHealth;
        }
	}

	public PlayerStats stats = new PlayerStats();


	public float fallBoundary = -20f;


    [SerializeField]
    private StatusIndicator statusIndicator;

    private void Start()
    {
        stats.Init();

        if(statusIndicator == null)
        {
            Debug.Log("PLAYER: No status indicator referenced");
        }
        else
        {
            statusIndicator.SetHealth(stats.curHealth, stats.maxHealth);
        }

    }



    void Update()
	{
		if(transform.position.y <= fallBoundary)
			DamagePlayer(10000);
	}

	public void DamagePlayer(int dmg)
	{
		stats.curHealth -= dmg;
		if(stats.curHealth <= 0)
		{
			GameMaster.KillPlayer(this);
		}

        statusIndicator.SetHealth(stats.curHealth, stats.maxHealth);
    }

}
