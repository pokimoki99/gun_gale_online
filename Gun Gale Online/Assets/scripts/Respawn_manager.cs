using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn_manager : MonoBehaviour
{
    public NetworkManager _team;
    public healthbar.Health _hp;
    //public healthbar _hp;
    public Player _player;
    float check,check1;
    // Start is called before the first frame update
    void Start()
    {
        _hp = FindObjectOfType<healthbar>().health;
        //_hp = FindObjectOfType<healthbar>().health;
        //_hp = FindObjectOfType<Health>();
        //check = _hp.Hp();
    }

    // Update is called once per frame
    void Update()
    {
        check = FindObjectOfType<healthbar>().health.healthAmount;
        check1 = FindObjectOfType<healthbar>().health.healthAmount1;
        if (_team.team)//team 2
        {
            if (check <= 10)
            {
                GameObject mySpawnSpot2 = _team.spawnSpots2[Random.Range(0, _team.spawnSpots2.Length)];
                _team.player.gameObject.transform.position = new Vector3(mySpawnSpot2.transform.position.x, mySpawnSpot2.transform.position.y + 0.4f, mySpawnSpot2.transform.position.z);
            }
        }
        else if (!_team.team)//team 1
        {
            if (check1 <= 10)
            {
                GameObject MyspawnSpots1 = _team.spawnSpots1[Random.Range(0, _team.spawnSpots1.Length)];
                _team.player.gameObject.GetComponent<Rigidbody>().position = new Vector3(MyspawnSpots1.transform.position.x, MyspawnSpots1.transform.position.y + 0.4f, MyspawnSpots1.transform.position.z);

            }

        }
    }
}
