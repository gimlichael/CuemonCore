﻿using System;

namespace Cuemon.Core.Assets
{
    public sealed class ClassDerived : ClassBase
    {
        public override int GetSomeNumber()
        {
            return Int32.MaxValue;
        }

        public override Guid Id { get; } = Guid.NewGuid();
    }
}