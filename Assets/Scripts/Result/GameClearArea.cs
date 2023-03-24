using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Constants;

namespace Result
{
    public class GameClearArea : MonoBehaviour
    {

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(TagName.Player))
            {
                GameClearPresenter.OpenClearWindow();
            }
        }
    }
}