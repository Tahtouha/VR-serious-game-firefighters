using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject follower;
    public bool behindyou = false;

    private GameObject[] player;

    private GameObject root;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectsWithTag("MainCamera");
        root = follower.transform.root.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        fixerJoueur();
        if (behindyou)
        {
            suivreJoueur();
        }
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

    float getDistance()
    {
        Vector3 _player_pose = player[0].transform.position;
        Vector3 _follower_pose =  follower.transform.position;
        float _distance = Vector3.Distance(_follower_pose, _player_pose);
        if (_distance < 0)
        {
            _distance = -_distance;
        }

        return _distance;
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

    void suivreJoueur()
    {
        Vector3 _direction = getPlayerDirection();
        if (_direction != null)
        {
            float _distance = getDistance();
            if (_distance > 2)
            { 
                root.transform.Translate(-_direction * Time.deltaTime);
            }
        }
    }
}
