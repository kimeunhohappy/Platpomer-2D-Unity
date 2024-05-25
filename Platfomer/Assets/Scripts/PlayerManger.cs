using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManger : MonoBehaviour
{
    private GameObject Player;
    public GameObject PlayerPrefab;
    public Transform SpawnTransform;
    private PlayerControler playerControler;
    [SerializeField] private PlayerCam PlayerCam;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            Respawnplayer();
        }
        //if (Player != null)
        //{
        //    Player = Instantiate(Player, SpawnTransform.position, Quaternion.identity);
        //}
    }
    public void Respawnplayer()
    {
        Player = Instantiate(Player, SpawnTransform.position, Quaternion.identity);
        playerControler = Player.GetComponent<PlayerControler>();
        PlayerCam.PlayerTransform = Player.transform;
    }
}
