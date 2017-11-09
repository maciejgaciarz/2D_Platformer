using UnityEngine;
using System.Collections;

public class GameMaster : MonoBehaviour {

	public static GameMaster gm;

	void Awake()
	{
		if (gm == null)
			gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
	}

	public Transform player;
	public Transform spawnPoint;
    public float spawnDelay = 2f;
	public Transform spawnPrefab;


    public CameraShake cameraShake;

    private void Start()
    {
        if(cameraShake == null)
        {
            Debug.LogError("No camera shake referenced in GameMaster");
        }
    }

    public IEnumerator _RespawnPlayer()
	{
		GetComponent<AudioSource>().Play ();
		yield return new WaitForSeconds(spawnDelay);
		Instantiate(player, spawnPoint.position, spawnPoint.rotation);
		Transform clone = (Transform)Instantiate(spawnPrefab, spawnPoint.position, spawnPoint.rotation);

		Destroy(clone.gameObject, 3f);
	}

	public static void KillPlayer(Player player)
	{
		Destroy (player.gameObject);
		gm.StartCoroutine(gm._RespawnPlayer());
	}



    public static void KillEnemy(Enemy enemy)
    {
        gm._KillEnemy(enemy);
    }

    public void _KillEnemy(Enemy _enemy)
    {
        Transform _clone = Instantiate(_enemy.deathParticles, _enemy.transform.position, Quaternion.identity) as Transform;
        Destroy(_clone.gameObject, 5f);
        cameraShake.Shake(_enemy.shakeAmt, _enemy.shakeAmt);
        Destroy(_enemy.gameObject);
    }
}
