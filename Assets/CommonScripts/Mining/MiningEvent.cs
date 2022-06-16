using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiningEvent : EventComponent
{
    public Animator animController;
    private static bool _isPlayerEvent = false;
    private bool _isMining = false;
    private float _waitingTime = 0.0f;
    private float _miningTimer = 0.0f;
    private float _playerMiningDuration = 0.0f;
    private float _scaleVal = 0.0f;

    public float minMining = 3.0f;
    public float maxMining = 5.0f;
    public int _minLevel = 1;
    public int _maxLevel = 3;

    public void Start()
    {
        _isPlayerEvent = false;
        _isMining = false;
    }

    public override void TriggerEvent()
    {
        SwitchMiningState();

        if (_isMining == false)
        {
            return;
        }

        InitMiningTimer();
    }
    
    protected override void Update()
    {
        if (_isPlayerEvent == false){
            _isMining = false;
        }

        if (_isMining)
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
            int level = Random.Range(_minLevel+CharacterManager.data._MiningLevel,_maxLevel);
            InventorySystem.instance.GetItem(ITEM_TYPE.Ore, level);
            InitMiningTimer();
            CharacterManager.data.ChangeStress(13);
        }

        if (_scaleVal > 0.6f)
        {
            SwitchMiningState();
            gameObject.SetActive(false);
        }

        _scaleVal += Time.deltaTime / 10.0f;
        float scaleVal = 1.0f - _scaleVal;
        Vector3 val = new Vector3(scaleVal, scaleVal, scaleVal);
        transform.localScale = val;
    }

    private void InitMiningTimer()
    {
        _waitingTime = Random.Range(minMining, maxMining);
        _miningTimer = 0.0f;
        _playerMiningDuration = 0.0f;
    }

    private void SwitchMiningState()
    {
        _isMining = !_isMining;
        _isPlayerEvent = _isMining;
        animController.SetBool("isMining", _isMining);
    }

    public void InitScale()
    {
        gameObject.SetActive(true);
        _scaleVal = 0.0f;
        float scaleVal = 1.0f - _scaleVal;
        Vector3 val = new Vector3(scaleVal, scaleVal, scaleVal);
        transform.localScale = val;
    }

    public static bool isPlayerEvent()
    {
        return _isPlayerEvent;
    }

    public static void setPlayerEvent(bool value)
    {
        _isPlayerEvent = value;
    }
}
