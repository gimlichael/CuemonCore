﻿using System;
using System.Diagnostics;
using System.Threading;
using Cuemon.Runtime;
using Cuemon.Threading;

namespace Cuemon.Extensions.Runtime.Caching.Assets
{
    public class CountdownDependency : Dependency, IDisposable
    {
        private Timer _handler;
        private TimeSpan _timer;
        private Stopwatch _sw = Stopwatch.StartNew();

        public CountdownDependency(TimeSpan timer)
        {
            _timer = timer;
        }

        private void OnCountdown()
        {
            _timer -= TimeSpan.FromSeconds(1);
            if (_timer < TimeSpan.Zero)
            {
                _timer = TimeSpan.Zero;
                _handler?.Dispose();
                _handler = null;
            }
        }

        public override bool HasChanged => _timer == TimeSpan.Zero;

        public override void Start()
        {
            _handler = TimerFactory.CreateNonCapturingTimer(state => ((CountdownDependency)state).OnCountdown(), this, TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(1));
        }

        public void Dispose()
        {
            _handler?.Dispose();
        }
    }
}