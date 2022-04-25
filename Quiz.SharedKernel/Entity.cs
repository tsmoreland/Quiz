//
// Copyright © 2020 Terry Moreland
// Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), 
// to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, 
// and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, 
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, 
// WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
// 

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Quiz.SharedKernel
{
    public abstract class Entity<TIdentifier> : IEquatable<Entity<TIdentifier>>, IEqualityComparer<TIdentifier>
    {

        protected Entity(TIdentifier id)
        {
            Id = id;
        }
        protected Entity()
        {
            Id = AnonymousId;
        }

        public TIdentifier Id { get; protected set; } 

        public override int GetHashCode() => Id?.GetHashCode() ?? 0;
        public override bool Equals(object? obj) => obj is Entity<TIdentifier> entity && Equals(entity);
        public bool Equals(Entity<TIdentifier>? other) =>
            ReferenceEquals(other, this) || other is object && Id?.Equals(other.Id) == true;

        public bool Equals([AllowNull] TIdentifier x, [AllowNull] TIdentifier y) =>
            ReferenceEquals(x, y) || 
            (x is object && x.Equals(y)) || 
            (y is object && y.Equals(x));
        public int GetHashCode(TIdentifier obj) => obj is object ? obj.GetHashCode() : 0;

        protected abstract TIdentifier AnonymousId { get; }
    }
}
