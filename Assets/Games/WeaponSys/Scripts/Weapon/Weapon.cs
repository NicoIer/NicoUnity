﻿using Nico.Template;
using Sirenix.OdinInspector;
using UnityEngine;
using WeaponSys.WeaponSys;

namespace WeaponSys
{
    public class Weapon : TemplateEntityMonoBehavior<Weapon>
    {
        [ShowInInspector] public WeaponData data;

        #region Component

        public AnimationEventHandler animationEventHandler { get; private set; }

        #endregion

        #region Controller

        public BaseAnimController baseAc { get; private set; }

        #endregion

        #region Mono Components

        public Animator ac { get; private set; }
        public Rigidbody2D rb { get; private set; }
        GameObject baseObj;
        SpriteRenderer baseRenderer;
        GameObject weaponSpriteObj;
        SpriteRenderer weaponRenderer;
        public Player player { get; private set; }

        #endregion

        #region Init

        protected override void _get_mono_components()
        {
            baseObj = transform.Find("Base").gameObject;
            baseRenderer = baseObj.GetComponent<SpriteRenderer>();
            ac = baseObj.GetComponent<Animator>();

            animationEventHandler = baseObj.GetComponent<AnimationEventHandler>();

            weaponSpriteObj = transform.Find("WeaponSprite").gameObject;
            weaponRenderer = weaponSpriteObj.GetComponent<SpriteRenderer>();

            rb = GetComponentInParent<Rigidbody2D>();
            player = GetComponentInParent<Player>();
        }

        protected override void _init_components()
        {
        }

        protected override void _init_controller()
        {
            baseAc = new BaseAnimController(this,baseRenderer);
            controllers.Add(baseAc);

            var weaponSprite = new WeaponAnimController(this, baseRenderer, weaponRenderer);
            controllers.Add(weaponSprite);

            var weaponMove = new AttackMoveController(this, rb);
            controllers.Add(weaponMove);
        }

        #endregion
    }
}