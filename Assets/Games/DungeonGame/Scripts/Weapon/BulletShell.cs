﻿using System;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Games.DungeonGame.Scripts.Weapon
{
    public class BulletShell: MonoBehaviour
    {
        private Rigidbody2D rb;
        private SpriteRenderer re;
        public float speed;
        public float deadTime=5f;
        public float fadeSpeed=.1f;
        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
            re = GetComponent<SpriteRenderer>();
        }

        private void OnEnable()
        {
            re.color = Color.white;
            _shoot().Forget();
        }
        
        private async UniTask _shoot()
        {
            var angel = Random.Range(-30, 30);
            rb.velocity = Quaternion.AngleAxis(angel, Vector3.forward) * Vector3.up * speed;
            
            await UniTask.Delay(TimeSpan.FromSeconds(deadTime));
            //随机旋转一下transform

            rb.velocity = Vector2.zero;
            rb.gravityScale = 0;

            while (re.color.a>0)
            {//淡出
                var color = re.color;
                color = new Color(color.r, color.g, color.b, color.a - fadeSpeed);
                re.color = color;
                await UniTask.WaitForFixedUpdate();
            }
            Destroy(gameObject);
        }
        
        
    }
}