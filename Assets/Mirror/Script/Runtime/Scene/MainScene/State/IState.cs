using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mirror.Runtime.Scene.MainScene
{
    public interface IState
    {
        void OnEnterState();
        void Update(float deltaTime);
        void OnExitState();
    }
}
