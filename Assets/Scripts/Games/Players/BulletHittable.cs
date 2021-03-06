﻿using Fireworks;
using Stores;
using UnityEngine;
using Zenject;

namespace Games.Players
{
    public class BulletHittable : MonoBehaviour, IFireworksEnterHandler
    {
        [Inject]
        StateStore stateStore;

        bool IFireworksEnterHandler.IFireworksEnter()
        {
            stateStore.State.Value = State.Dead;
            return true;
        }
    }
}
