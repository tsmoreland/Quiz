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

using DevQuiz.SharedKernel;
using DevQuiz.SharedKernel.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DevQuiz.CourseManagement.Domain.Model
{
    public sealed partial class Course : EntityWithGuidId
    {
        private Course() : base(Guid.NewGuid())
        {
        }
        /// <summary>intended for construction of None only</summary>
        private Course(Guid id) : base(id)
        {
            if (id != Guid.Empty)
                throw new ArgumentException("constructor intended only for None instance");
            Name = string.Empty;
        }
        public Course(string name) : this()
        {
            Name = name;
        }

        public string Name { get; private set; } = string.Empty;
        public IEnumerable<Question> Questions => QuestionModels.AsEnumerable();
        private List<Question> QuestionModels { get; set; } = List.Empty<Question>();

        public void AddQuestion(params Question[] questions)
        {
            QuestionModels.AddRange(questions);
            // raise domain event
        }

        public static Course None { get; } = new Course(Guid.Empty);
    }
}
