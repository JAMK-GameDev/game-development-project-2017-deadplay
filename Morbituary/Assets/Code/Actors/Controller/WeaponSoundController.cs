using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Code.Actors.Controller
{
    [RequireComponent(typeof(AudioSource))]
    public class WeaponSoundController : MonoBehaviour
    {
        private static WeaponSoundController instance;
        public AudioSource source;
        public AudioClip Weapon1Sound;
        public AudioClip Weapon2Sound;
        public AudioClip Weapon3Sound;
        public AudioClip Weapon1Slash;
        public AudioClip Weapon2Slash;
        public AudioClip Weapon3Slash;
        public static WeaponSoundController Instance
        {
            get
            {
                return instance;
            }
        }

        void Awake()
        {
            if (instance == null && Weapon1Sound != null) instance = this;
        }


        public void PlayWeaponSound(AudioClip sound)
        {
            source.PlayOneShot(sound);
            source.Play();
        }

        public void PlayWeapon1Sound()
        {
            PlayWeaponSound(Weapon1Sound);
        }

        public void PlayWeapon2Sound()
        {
            PlayWeaponSound(Weapon2Sound);
        }

        public void PlayWeapon3Sound()
        {
            PlayWeaponSound(Weapon3Sound);
        }
        public void PlayWeapon1Slash()
        {
            PlayWeaponSound(Weapon1Slash);
        }
        public void PlayWeapon2Slash()
        {
            PlayWeaponSound(Weapon2Slash);
        }
        public void PlayWeapon3Slash()
        {
            PlayWeaponSound(Weapon3Slash);
        }
    }
}
