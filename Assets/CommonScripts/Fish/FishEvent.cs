using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishEvent : EventComponent
{
    public GameObject chairObject;
    private bool _isFishing = false;
    private float _waitingTime = 0.0f;
    private float _fishTimer = 0.0f;

    public float minFish = 3.0f;
    public float maxFish = 7.0f;

    public override void TriggerEvent()
    {
        _isFishing = !_isFishing;
        animController.SetBool("isSitting", _isFishing);
        chairObject.SetActive(_isFishing);

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
    }

    private void doFishing()
    {
        _fishTimer += Time.deltaTime;
        if (_fishTimer > _waitingTime)
        {
            InventorySystem.instance.GetItem(ITEM_TYPE.Fish, 1);
            InitFishTimer();
        }
    }
}
