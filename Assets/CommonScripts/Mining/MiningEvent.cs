using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiningEvent : EventComponent
{

    private bool isMining = false;
    private float _waitingTime = 0.0f;
    private float _miningTimer = 0.0f;
    private float _playerMiningDuration = 0.0f;
    private float _scaleVal = 0.0f;

    public float minMining = 3.0f;
    public float maxMining = 5.0f;
    
    public override void TriggerEvent()
    {
        isMining = !isMining;

        if (isMining == false)
        {
            return;
        }
    }
    
    protected override void Update()
    {
        if (isMining)
        {
            doMining();
        }
    }

    private void doMining()
    {
        _miningTimer += Time.deltaTime;
        _playerMiningDuration += Time.deltaTime;

        if (_miningTimer > _waitingTime)
        {
            InventorySystem.instance.GetItem(ITEM_TYPE.Ore, 1);
            InitMiningTimer();
        }

        _scaleVal += Time.deltaTime;
        float scaleVal = 1.0f - _scaleVal;
        Vector3 val = new Vector3(scaleVal,scaleVal,scaleVal);
        transform.localScale = val;
    }

    private void InitMiningTimer()
    {
        _waitingTime = Random.Range(minMining, maxMining);
        _miningTimer = 0.0f;
        _playerMiningDuration = 0.0f;
    }
}
