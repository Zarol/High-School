using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MMTEvaluationSystem
{
    public class DataEvaluationResult
    {
        public int EvaluationNumber { get; private set; }
        public int EmployeeNumber  {  get; private set; }
        public int EmployerNumber { get; private set; }
        public DateTime EvaluationDate;
        public DateTime EvaluationDateNext;
        public byte WorkQualityScore;
        public string WorkQualityComment;
        public byte WorkHabitScore;
        public string WorkHabitComment;
        public byte JobKnowledgeScore;
        public string JobKnowledgeComment;
        public byte BehaviorScore;
        public string BehaviorComment;
        public double AverageScore;
        public double OverallProgressScore;
        public string OverallProgressComment;
        public bool EmployerRecommendation;

        /// <summary>
        /// Constructor for the evaluation result data structure.
        /// </summary>
        /// <param name="EvaluationNumber">The unique number.</param>
        /// <param name="EmployeeNumber">The employee's number.</param>
        /// <param name="EmployerNumber">The employer's number.</param>
        /// <param name="EvaluationDate">The date of the evaluation.</param>
        public DataEvaluationResult(int EvaluationNumber,int EmployeeNumber, int EmployerNumber, DateTime EvaluationDate)
        {
            this.EvaluationNumber = EvaluationNumber;
            this.EmployeeNumber = EmployeeNumber;
            this.EmployerNumber = EmployerNumber;
            this.EvaluationDate = ValidDate(EvaluationDate);
            this.EvaluationDateNext = ValidDate(new DateTime()); //SqlCE does not support dates before January 1, 1753
            this.WorkQualityScore = 1;
            this.WorkQualityComment = "";
            this.WorkHabitScore = 1;
            this.WorkHabitComment = "";
            this.JobKnowledgeScore = 1;
            this.JobKnowledgeComment = "";
            this.BehaviorScore = 1;
            this.BehaviorComment = "";
            this.AverageScore = 1;
        }

        /// <summary>
        /// Constructor for the evaluation result data structure.
        /// </summary>
        /// <param name="EvaluationNumber">The unique number.</param>
        /// <param name="EmployeeNumber">The employee's number.</param>
        /// <param name="EmployerNumber">The employer's number.</param>
        /// <param name="EvaluationDate">The date of the evaluation.</param>
        /// <param name="EvaluationDateNext">The date of the next evaluation.</param>
        /// <param name="WorkQualityScore">The work quality score.</param>
        /// <param name="WorkQualityComment">The work quality comment.</param>
        /// <param name="WorkHabitScore">The work habit score.</param>
        /// <param name="WorkHabitComment">The work habit comment.</param>
        /// <param name="JobKnowledgeScore">The job knowledge score.</param>
        /// <param name="JobKnowledgeComment">The job knowledge comment.</param>
        /// <param name="BehaviorScore">The behavior score.</param>
        /// <param name="BehaviorComment">The behavior comment.</param>
        /// <param name="AverageScore">The average score of the evaluation.</param>
        /// <param name="OverallProgressScore">The overall progress score of the evaluations.</param>
        /// <param name="OverallProgressComment">The overall progress comment of the evaluations.</param>
        /// <param name="EmployerRecommendation">The employer's recommendation.</param>
        public DataEvaluationResult(int EvaluationNumber, int EmployeeNumber, int EmployerNumber, DateTime EvaluationDate, DateTime EvaluationDateNext, byte WorkQualityScore, string WorkQualityComment, byte WorkHabitScore, string WorkHabitComment, byte JobKnowledgeScore, string JobKnowledgeComment, byte BehaviorScore, string BehaviorComment, double AverageScore, double OverallProgressScore, string OverallProgressComment, bool EmployerRecommendation)
        {
            this.EvaluationNumber = EvaluationNumber;
            this.EmployeeNumber = EmployeeNumber;
            this.EmployerNumber = EmployerNumber;
            this.EvaluationDate = ValidDate(EvaluationDate);
            this.EvaluationDateNext = ValidDate(EvaluationDateNext);
            this.WorkQualityScore = WorkQualityScore;
            this.WorkQualityComment = WorkQualityComment;
            this.WorkHabitScore = WorkHabitScore;
            this.WorkHabitComment = WorkHabitComment;
            this.JobKnowledgeScore = JobKnowledgeScore;
            this.JobKnowledgeComment = JobKnowledgeComment;
            this.BehaviorScore = BehaviorScore;
            this.BehaviorComment = BehaviorComment;
            this.AverageScore = AverageScore;
            this.OverallProgressScore = OverallProgressScore;
            this.OverallProgressComment = OverallProgressComment;
            this.EmployerRecommendation = EmployerRecommendation;
        }

        /// <summary>
        /// Helper method designed to assure a valid SQLCE DateTime.
        /// Values earlier than January 1, 1753 are not permitted.
        /// </summary>
        /// <param name="Date">The date to be checked.</param>
        /// <returns>A valid DateTime if the check was invalid. The parameter if the check was valid.</returns>
        public DateTime ValidDate(DateTime Date)
        {
            if (Date.Year.CompareTo(1753) == -1)
            {
                return new DateTime(1753, 1, 1);
            }
            else
                return Date;
        }
    }
}
