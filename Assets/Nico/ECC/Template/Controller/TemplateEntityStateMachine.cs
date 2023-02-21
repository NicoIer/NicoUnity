﻿using System;
using System.Collections.Generic;

namespace Nico.ECC.Template
{
    public abstract class TemplateEntityStateMachine<T> : IStateMachine<T>
    {
        public T owner { get; protected set; }
        public IState<T> curState { get; protected set; }
        protected readonly Dictionary<Type, IState<T>> states = new();

        protected TemplateEntityStateMachine(T owner)
        {
            this.owner = owner;
        }

        protected void Add(IState<T> state)
        {
            states.TryAdd(state.GetType(), state);
        }
        #region IStateMachine

        public abstract void Start();

        public void Update()
        {
            curState?.Update();
        }

        public void FixedUpdate()
        {
            curState?.FixedUpdate();
        }


        public abstract void OnEnable();

        public abstract void OnDisable();

        public void Change<T1>() where T1 : IState<T>
        {
            curState?.Exit();
            curState = states[typeof(T1)];
            curState?.Enter();
        }

        #endregion
    }
}