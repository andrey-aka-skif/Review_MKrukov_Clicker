using System.Collections.Generic;
using UnityEngine;

namespace Assets.Project.Scripts.GameManagement
{
    public class CustomUpdater : MonoBehaviour
    {
        private List<ITicked> _tickeds;

        public void Init(List<ITicked> tickeds)
        {
            _tickeds = tickeds;
        }

        private void Update()
        {
            foreach (var item in _tickeds)
            {
                item.Tick(Time.deltaTime);
            }
        }
    }
}
