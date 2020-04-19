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
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DevQuiz.CourseManagement.Domain.Model
{
    public sealed class Question : EntityWithGuidId
    {
        private Question() : base(Guid.NewGuid())
        {
        }

        public string Content { get; private set; } = string.Empty;

        public Guid CorrectAnswerId { get; private set; } = Guid.Empty;
        public IEnumerable<Answer> Answers => AnswerModels.AsEnumerable();
        private IList<Answer> AnswerModels { get; set; } = List.Empty<Answer>();

        public void AddAnswer(params Answer[] answers)
        {
            AnswerModels.AddRange(answers);
            // raise domain event
        }

        public void SetCorrectAnswer(Guid id)
        {
            if (CorrectAnswerId == id)
                return;
            CorrectAnswerId = id;
            // raise event
        }

        public static IEntityTypeConfiguration<Question> BuildConfiguration() => new QuestionConfiguration();

        internal class QuestionConfiguration : IEntityTypeConfiguration<Question>
        {
            public void Configure(EntityTypeBuilder<Question> builder)
            {
                builder.Property(q => q.Content);
                builder.Property(q => q.CorrectAnswerId);
                builder.Property(q => q.AnswerModels);
            }
        }
    }
}
