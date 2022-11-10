using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject follower;

    private GameObject[] player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectsWithTag("MainCamera");
    }

    // Update is called once per frame
    void Update()
    {
        fixerJoueur();
    }

    Vector3 getPlayerDirection()
    {
        if (player.Length < 2)
        {
            Vector3 _player_pose = player[0].transform.position;
            Vector3 _follower_pose =  follower.transform.position;
            Vector3 _direction = _follower_pose - _player_pose;
            return _direction;
        }
        else
        {
            return new Vector3();
        }
    }

    void fixerJoueur()
    {
        Vector3 _direction = getPlayerDirection();
        if (_direction != null)
        {
            follower.transform.rotation = Quaternion.LookRotation(_direction);
            follower.transform.Rotate(0,90,0);

        }
    }
}
