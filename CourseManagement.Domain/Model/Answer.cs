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

using Quiz.SharedKernel;
using System;

namespace Quiz.CourseManagement.Domain.Model
{
    public sealed class Answer : EntityWithGuidId
    {
        private Answer()
            : base(Guid.NewGuid())
        {
        }

        public Answer(string content) : this()
        {
            Content = content;
        }

        public string Content { get; private set; } = string.Empty;
        public Guid QuestionId { get; private set; } = Guid.Empty;
        public Question Question { get; private set; } = Question.None;

        public static Answer Empty { get; } = new Answer();

        public override string ToString() => Content;
    }
}
