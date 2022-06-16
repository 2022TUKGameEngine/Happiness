using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiningSpot : EventComponent
{
    public float _maxSpotTime = 20.0f;
    public float _currentSpotTime = 20.0f;
    public GameObject targetObject;
    public GameObject playerObject;
    private Rigidbody _playerBody;

    void Start()
    {
        _playerBody = playerObject.GetComponent<Rigidbody>();
    }

    protected override void FixedUpdate()
    {
        if (MiningEvent.isPlayerEvent() == false){
            return;
        }

        _currentSpotTime -= Time.deltaTime;
        if (_currentSpotTime <= 0.0f)
        {
            MiningEvent.setPlayerEvent(false);
            Animation.SetBool("isMining", false);
            _currentSpotTime = _maxSpotTime;
            _playerBody.position = targetObject.transform.position;
        }
    }
}
