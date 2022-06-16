using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishEvent : EventComponent
{
    public Animator animController;
    public GameObject chairObject;
    private bool _isFishing = false;
    private float _waitingTime = 0.0f;
    private float _fishTimer = 0.0f;
    private float _playerFishDuration = 0.0f;

    public float minFish = 3.0f;
    public float maxFish = 7.0f;
    public float fishMaxDuration = 10.0f;
    public int _minLevel = 1;
    public int _maxLevel = 4;

    public override void TriggerEvent()
    {
        if (!IsStartFishing())
        {
             return;
        }

        SwitchFishState();

        if (_isFishing == false)
        {
            return;
        }

        InitFishTimer();
    }

    protected override void Update()
    {
        if (_isFishing)
        {
            doFishing();
        }
    }

    private void InitFishTimer()
    {
        _waitingTime = Random.Range(minFish, maxFish);
        _fishTimer = 0.0f;
        //_playerFishDuration = 0.0f;
    }

    private void doFishing()
    {
        _fishTimer += Time.deltaTime;
        //_playerFishDuration += Time.deltaTime;
        
        if (_fishTimer > _waitingTime)
        {
            int level = Random.Range(_minLevel +  CharacterManager.data._FishingLevel, _maxLevel);
            InventorySystem.instance.GetItem(ITEM_TYPE.Fish, level);
            CharacterManager.data.ChangeStress(10);

            if (InventorySystem.instance.useItem(ITEM_TYPE.Bait))
                InitFishTimer();
            else
                SwitchFishState();
        }

        // if (_playerFishDuration > fishMaxDuration)
        // {
        //     SwitchFishState();
        // }
    }

    private void SwitchFishState()
    {
        _isFishing = !_isFishing;
        animController.SetBool("isFishing", _isFishing);
        chairObject.SetActive(_isFishing);
    }

    private bool IsStartFishing()
    {
        if (_isFishing)
        {
            return true;
        }
        return InventorySystem.instance.useItem(ITEM_TYPE.Bait);
    }
}